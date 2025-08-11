import React, { useEffect, useState } from 'react';
import { IPersonModel, PersonCard} from "../models/PersonModel";



// Форма для создания персоны.
function PersonForm(){
  const [formData, setFormData] = useState({
    name: '',
    lastName: '',
    date: '',
    email: ''
  });
  const [isSuccess, setIsSuccess] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const response = await fetch('https://localhost:7130/api/Persons', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData)
      });

      if (response.ok) {
        setIsSuccess(true);
        setFormData({ name: '', lastName: '', date: '',   email: ''}); // Очищаем форму
        
        // Через 3 секунды убираем подсветку
        setTimeout(() => setIsSuccess(false), 3000);
      }
    } catch (error) {
      console.error('Error submitting form:', error);
    }
  };

  return (
    <div className="container mx-auto px-4 py-8">
      <div className="p-4">
        <h2 className="text-xl font-semibold mb-4">Создать персону</h2>
        <form onSubmit={handleSubmit} className="space-y-4">
          <input
            type="text"
            name="name"
            value={formData.name}
            onChange={(e) => setFormData({...formData, name: e.target.value})}
            placeholder="Имя"
            className="w-full p-2 border rounded"
            required
          />
          
          <input
            type="text"
            name="lastName"
            value={formData.lastName}
            onChange={(e) => setFormData({...formData, lastName: e.target.value})}
            placeholder="Фамилия"
            className="w-full p-2 border rounded"
            required
          />
          
          <input
            type="date"
            name="date"
            value={formData.date}
            onChange={(e) => setFormData({...formData, date: e.target.value})}
            className="w-full p-2 border rounded"
            required
          />

          <input
            type="text"
            name="email"
            placeholder="Почта"
            value={formData.email}
            onChange={(e) => setFormData({...formData, email: e.target.value})}
            className="w-full p-2 border rounded"
            required
          />
          
          <button 
            type="submit" 
            className={`w-full p-2 text-white rounded transition-colors ${
              isSuccess ? 'bg-green-500' : 'bg-blue-500 hover:bg-blue-600'
            }`}
          >
            {isSuccess ? 'Успешно отправлено!' : 'Отправить'}
          </button>
        </form>
      </div>
      
    </div>
  );
};

export function PersonPage(){

  return (
    <div>
      <div>
        {PersonForm()}
      </div>

    </div>
  );
};


