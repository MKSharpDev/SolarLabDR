import React from 'react';
import {Routes, Route} from 'react-router-dom';
import {MainPage} from './pages/MainPage'
import {CalendarPage} from './pages/CalendarPage'
import {PersonPage} from './pages/PersonPage'
import {GetPersonPage} from './pages/GetPersonPage'

import { Navigation } from './components/Navigation';


function App() {
  return (
    <>
      <Navigation></Navigation>
      <Routes>
        <Route path='/' element = { <MainPage /> }></Route>
        <Route path='/calendar' element = { <CalendarPage />}></Route>
        <Route path='/person' element = { <PersonPage />}></Route>
        <Route path='/getperson' element = { <GetPersonPage />}></Route>
      </Routes>
      
    </>
  );
}

export default App;
