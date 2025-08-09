import React, { useState } from 'react';

export const PersonPage = () => {
  const [formData, setFormData] = useState({
    name: '',
    lastName: '',
    date: ''
  });

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await fetch('https://localhost:7130/api/Persons', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(formData)
    });
  };

  return (
    <div className="container mx-auto px-4 py-8">
        <div className="p-4"> Создать персону
        <form onSubmit={handleSubmit} className="space-y-4">
            <input
            type="text"
            name="name"
            value={formData.name}
            onChange={(e) => setFormData({...formData, name: e.target.value})}
            placeholder="Name"
            className="w-full p-2 border rounded"
            />
            
            <input
            type="text"
            name="lastName"
            value={formData.lastName}
            onChange={(e) => setFormData({...formData, lastName: e.target.value})}
            placeholder="Last Name"
            className="w-full p-2 border rounded"
            />
            
            <input
            type="date"
            name="date"
            value={formData.date}
            onChange={(e) => setFormData({...formData, date:  e.target.value})}
            className="w-full p-2 border rounded"
            />
            
            <button 
            type="submit" 
            className="w-full p-2 bg-blue-500 text-white rounded"
            >
            Submit
            </button>
        </form>
        </div>
    </div>
  );
};