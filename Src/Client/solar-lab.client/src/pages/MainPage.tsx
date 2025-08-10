import React, { useEffect, useState } from 'react';
import { IPersonModel, PersonCard} from "../models/PersonModel";

async function fetchToDo( ) {
    
  try {
    const res = await fetch(`https://localhost:7130/api/Persons/Birthdays/ByDate/${7}`);
    if (!res.ok) {
      throw new Error(`HTTP error! status: ${res.status}`);
    }
    return await res.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
}

export function MainPage(){
  const [data, setData] = useState<IPersonModel[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await fetchToDo();
        setData(result);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Unknown error occurred');
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []); 

  if (loading) {
    return <div className="container mx-auto max-w-[760px] pt-5">Loading...</div>;
  }

  if (error) {
    return <div className="container mx-auto max-w-[760px] pt-5">Error: {error}</div>;
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <h1 className="text-3xl font-bold text-center text-gray-800 mb-8">Ближайшие дни рождения </h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {data.map(person => (
          <PersonCard key={person.id} person={person} />
        ))}
      </div>
    </div>
  );
};