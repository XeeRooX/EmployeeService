import React from 'react';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import ReactDOM from 'react-dom/client';
import App from './App';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.css';
import "bootstrap-icons/font/bootstrap-icons.css";
import EmployeesIndex from './components/employees/employeesIndex';
import AboutIndex from './components/about/aboutIndex';
import config from "./config.json";
import 'bootstrap/dist/js/bootstrap.min.js';


export default function Main(){
  return (
    <Router>
      <Routes>
        <Route path="/" element={<App/>}>
          <Route path='/employees' element={<EmployeesIndex config={config}/>}></Route>
          <Route path='' element={<AboutIndex/>}></Route>
        </Route>
      </Routes>
    </Router>
  );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<Main></Main>);

reportWebVitals();
