import React, { useState } from 'react';

export interface IPersonModel {
  id: string;
  name: string;
  lastName: string;
  date: string;
}

export const PersonCard: React.FC<{ person: IPersonModel }> = ({ person }) => {
  const birthDate = new Date(person.date);
  const age = new Date().getFullYear() - birthDate.getFullYear();
  const formattedDate = birthDate.toLocaleDateString('ru-RU');

  return (
    <div className="bg-white rounded-lg shadow-md overflow-hidden transition-transform duration-300 hover:-translate-y-1 hover:shadow-lg">
      <div className="bg-blue-600 text-white p-4">
        <h3 className="text-xl font-semibold m-0">{person.name} {person.lastName}</h3>
      </div>
      <div className="p-4">
        <p className="text-gray-700 mb-2">
          <span className="font-medium">Дата рождения:</span> {formattedDate}
        </p>
        <p className="text-gray-700">
          <span className="font-medium">Возраст:</span> {age} лет
        </p>
      </div>
      <div className="bg-gray-100 px-4 py-2 text-sm text-gray-600">
        <small>ID: {person.id}</small>
      </div>
    </div>
  );
};

const PersonSearchPage: React.FC = () => {
  const [id, setId] = useState<string>('');
  const [person, setPerson] = useState<IPersonModel | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const fetchPerson = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError(null);
    
    try {
      const response = await fetch(`https://localhost:7130/api/Persons/${id}`);
      
      if (!response.ok) {
        throw new Error(response.status === 404 
          ? 'Пользователь не найден' 
          : `Ошибка сервера: ${response.status}`);
      }
      
      const data: IPersonModel = await response.json();
      setPerson(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Неизвестная ошибка');
      setPerson(null);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 py-12 px-4 sm:px-6 lg:px-8">
      <div className="max-w-md mx-auto bg-white rounded-xl shadow-md overflow-hidden md:max-w-2xl">
        <div className="p-8">
          <div className="text-center mb-8">
            <h1 className="text-2xl font-bold text-gray-900">Поиск пользователя</h1>
            <p className="mt-2 text-sm text-gray-600">
              Введите ID пользователя для получения информации
            </p>
          </div>

          <form onSubmit={fetchPerson} className="space-y-6">
            <div>
              <label htmlFor="id" className="block text-sm font-medium text-gray-700">
                ID пользователя
              </label>
              <div className="mt-1">
                <input
                  id="id"
                  name="id"
                  type="text"
                  required
                  value={id}
                  onChange={(e) => setId(e.target.value)}
                  className="appearance-none block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                  placeholder="Введите ID"
                />
              </div>
            </div>

            <div>
              <button
                type="submit"
                disabled={loading}
                className={`w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 ${loading ? 'opacity-50 cursor-not-allowed' : ''}`}
              >
                {loading ? (
                  <>
                    <svg className="animate-spin -ml-1 mr-3 h-5 w-5 text-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                      <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                      <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                    </svg>
                    Загрузка...
                  </>
                ) : 'Найти пользователя'}
              </button>
            </div>
          </form>

          {error && (
            <div className="mt-6 p-4 bg-red-50 rounded-md">
              <div className="flex">
                <div className="flex-shrink-0">
                  <svg className="h-5 w-5 text-red-400" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                    <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clipRule="evenodd" />
                  </svg>
                </div>
                <div className="ml-3">
                  <h3 className="text-sm font-medium text-red-800">{error}</h3>
                </div>
              </div>
            </div>
          )}

          {person && (
            <div className="mt-8">
              <PersonCard person={person} />
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default PersonSearchPage;