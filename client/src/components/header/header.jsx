import React from "react";
import { Link } from "react-router-dom";


export default class Header extends React.Component{
    constructor(props){
        super(props);
    }

    render(){
        return <nav className="navbar navbar-expand-lg bg-light">
        <div className="container-fluid">
          <a className="navbar-brand" href="#"><i className="bi bi-buildings me-2" style={{ fontSize: "25px" }}></i>
            Компания</a>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div className="navbar-nav">
              <Link className="nav-link" to="/employees">Сотрудники</Link>
              <Link className="nav-link" to="/">О компании</Link>
            </div>
          </div>
        </div>
      </nav>
    }
}