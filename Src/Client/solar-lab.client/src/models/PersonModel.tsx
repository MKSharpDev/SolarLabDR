import React from 'react';

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