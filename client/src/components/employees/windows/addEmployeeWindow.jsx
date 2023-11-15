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

        console.log(this.props.departments);
        console.log(this.props.positions);

        return <div class="modal fade" id="addWindow" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="exampleModalLabel">Добавить сотрудника</h1>
                        <button type="button" id="close-add-window" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <form id={"addForm"} onSubmit={this.onFormSubmit}>
                        <div class="modal-body p-3">
                            <div class="form-floating mb-3 ">
                                <input type="text" class="form-control" id="lastname" name="lastname" minLength={2} maxLength={30} required={true} />
                                <label for="lastname">Фамилия</label>
                            </div>
                            <div class="form-floating mb-3 ">
                                <input type="text" class="form-control" id="firstname" name="firstname" minLength={2} maxLength={30} required={true} />
                                <label for="firstname">Имя</label>
                            </div>
                            <div class="form-floating mb-3 ">
                                <input type="text" class="form-control" id="surname" name="surname" minLength={2} maxLength={30} required={false} />
                                <label for="surname">Отчество</label>
                            </div>
                            <div class="form-floating mb-3 ">
                                <input type="date" class="form-control" id="dateOfBirth" name="dateOfBirth" 
                                max={new Date().toISOString().slice(0,10)}
                                required={true} 
                                onChange={this.onDateChanged}/>
                                <label for="dateOfBirth">Дата рождения</label>
                            </div>
                            <div class="form-floating mb-3 ">
                                <input type="date" class="form-control" id="dateOfEmployment" name="dateOfEmployment"
                                 max={new Date().toISOString().slice(0,10)} 
                                 required={true} 
                                 onChange={this.onDateChanged}/>
                                <label for="dateOfEmployment">Дата устройства на работу</label>
                            </div>
                            <div class="form-floating mb-3 ">
                                <input type="number" class="form-control" id="tariffRate" name="tariffRate" min={0} required={true} />
                                <label for="tariffRate">Оклад</label>
                            </div>
                            <div class="mb-3">
                                <label for="postion" class="form-label">Должность</label>
                                <select id="postion" class="form-select" name="postionId" required={true}>
                                    <option disabled={true}>Выберите должность ...</option>
                                    {this.props.positions.map((item, idx) => {
                                        return <option value={item.id} key={item.id}>{item.name}</option>
                                    })}
                                </select>
                            </div>
                            <div class="mb-3">
                                <label for="department" class="form-label" >Отдел</label>
                                <select id="department" class="form-select" name="departmentId" required={true}>
                                    <option disabled={true}>Выберите отдел ...</option>
                                    {this.props.departments.map((item, idx) => {
                                        return <option value={item.id} key={item.id}>{item.name}</option>
                                    })}
                                </select>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Отмена</button>
                            <button type="submit" class="btn btn-primary">Добавить</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>;
    }
}