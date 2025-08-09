import React, { useEffect, useState } from 'react';

 
interface IPersonModel {
  id: string;  // UUID обычно представляется как строка
  name: string;
  lastName: string;
  date: string; // Дата обычно приходит как строка с сервера
}

async function fetchToDo( ) {
    const currentMonth = new Date().getMonth() + 1; // +1 потому что месяцы в JS от 0 до 11

  try {
    const res = await fetch(`https://localhost:7130/api/Persons/birthdaybyMonth/${currentMonth}`);
    if (!res.ok) {
      throw new Error(`HTTP error! status: ${res.status}`);
    }
    return await res.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
}

export function CalendarPage(){
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
    <div className="container mx-auto max-w-[760px] pt-5">
      <header className="App-header">
        <div>
          <h2>Дни рождения в августе</h2>
          <pre style={{ textAlign: 'left' }}>
            {JSON.stringify(data, null, 2)}
          </pre>
        </div>
      </header>
    </div>
  );
}