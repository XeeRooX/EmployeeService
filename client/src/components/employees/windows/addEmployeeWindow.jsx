import axios from "axios";
import React from "react";


export default class AddEmployeeWindow extends React.Component {
    constructor(props) {
        super(props);

        this.onFormSubmit = this.onFormSubmit.bind(this);
        this.onDateChanged = this.onDateChanged.bind(this);
    }

    onFormSubmit(e) {
        e.preventDefault();

        const apiUrl = this.props.config.API_URL;

        const data = new FormData(e.target);
        let values = {};
        data.forEach((value, key) => {
            values[key] = value;
        })

        if(values.surname === '')
            delete values.surname;

        const jsonData = JSON.stringify(values);
        axios.post(apiUrl + "employee/add", values).then((response) => {
            alert("Сотрудник добавлен");
            document.querySelector('#close-add-window').click();
            document.querySelector('#btn-find').click();
        }).catch((error)=>{
            const showError = this.props.showError;
            showError(error);
        });

    }

    onDateChanged(e) {
        const date = new Date(e.target.value);
        const currentDate = new Date();
        if (date > currentDate)
            e.target.value = currentDate.toLocaleDateString("sv-SE");
    }

    render() {

        return <div className="modal fade" id="addWindow" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div className="modal-dialog">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5" id="exampleModalLabel">Добавить сотрудника</h1>
                        <button type="button" id="close-add-window" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <form id={"addForm"} onSubmit={this.onFormSubmit}>
                        <div className="modal-body p-3">
                            <div className="form-floating mb-3 ">
                                <input type="text" className="form-control" id="lastname" name="lastname" minLength={2} maxLength={30} required={true} />
                                <label htmlFor="lastname">Фамилия</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="text" className="form-control" id="firstname" name="firstname" minLength={2} maxLength={30} required={true} />
                                <label htmlFor="firstname">Имя</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="text" className="form-control" id="surname" name="surname" minLength={2} maxLength={30} required={false} />
                                <label htmlFor="surname">Отчество</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="date" className="form-control" id="dateOfBirth" name="dateOfBirth" 
                                max={new Date().toISOString().slice(0,10)}
                                required={true} 
                                onChange={this.onDateChanged}/>
                                <label htmlFor="dateOfBirth">Дата рождения</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="date" className="form-control" id="dateOfEmployment" name="dateOfEmployment"
                                 max={new Date().toISOString().slice(0,10)} 
                                 required={true} 
                                 onChange={this.onDateChanged}/>
                                <label htmlFor="dateOfEmployment">Дата устройства на работу</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="number" className="form-control" id="tariffRate" name="tariffRate" min={0} max={10000000} required={true} />
                                <label htmlFor="tariffRate">Оклад</label>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="postion" className="form-label">Должность</label>
                                <select id="postion" className="form-select" name="postionId" required={true}>
                                    <option disabled={true}>Выберите должность ...</option>
                                    {this.props.positions.map((item, idx) => {
                                        return <option value={item.id} key={item.id}>{item.name}</option>
                                    })}
                                </select>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="department" className="form-label" >Отдел</label>
                                <select id="department" className="form-select" name="departmentId" required={true}>
                                    <option disabled={true}>Выберите отдел ...</option>
                                    {this.props.departments.map((item, idx) => {
                                        return <option value={item.id} key={item.id}>{item.name}</option>
                                    })}
                                </select>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Отмена</button>
                            <button type="submit" className="btn btn-primary">Добавить</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>;
    }
}