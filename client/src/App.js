import React from 'react';
import Header from './components/header/header';
import { Outlet } from 'react-router-dom';

export default class App extends React.Component{
  constructor(props){
    super(props);
  }
  
  render(){
    return (
      <div className="App">
        <header className="App-header">
          <Header></Header>
        </header>
        <div id='content' className='container mt-3'>
          <Outlet></Outlet>
        </div>
      </div>
    );
  }
}
