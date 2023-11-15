import React from "react";


export default class EmployeeTableEmpty extends React.Component{
    constructor(props){
        super(props);
    }

    render(){
        return <div className="p-3 mx-auto text-center mb-3">
            <h3>Таблица пуста</h3>
        </div>
    }
}