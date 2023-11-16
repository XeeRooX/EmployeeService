import axios from "axios";
import React from "react";


export default class EditEmployeeWindow extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            employeeId: 0,
            firstname: "",
            lastname: "",
            surname: "",
            dateOfBirth: "2000-01-01",
            dateOfEmployment: "2000-01-01",
            tariffRate: 0,
            positionId: 0,
            departmentId: 0
        };

        this.onFormSubmit = this.onFormSubmit.bind(this);
        this.loadEditData = this.loadEditData.bind(this);

        //this.onFirstnameChanged = this.onFirstnameChanged.bind(this);
    }

    componentDidUpdate() {
        if (this.state.employeeId != this.props.currentEditId)
            this.loadEditData();
    }

    // !

    onFirstnameChanged = (e) => {
        const firstname = e.target.value;
        this.setState({ firstname: firstname });
    }

    onLastnameChanged = (e) => {
        const lastname = e.target.value;
        this.setState({ lastname: lastname });
    }

    onSurnameChanged = (e) => {
        const surname = e.target.value;
        this.setState({ surname: surname });
    }

    onDateOfBirthChanged = (e) => {
        const date = new Date(e.target.value);
        const currentDate = new Date();

        if (!isNaN(date.valueOf())) {
            if (date > currentDate) {
                const dateOfBirth = currentDate.toISOString().slice(0, 10);
                this.setState({ dateOfBirth: dateOfBirth });
            } else {
                const dateOfBirth = date.toISOString().slice(0, 10);
                this.setState({ dateOfBirth: dateOfBirth });
            }
        }
    }

    onDateOfEmploymentChanged = (e) => {
        const date = new Date(e.target.value);
        const currentDate = new Date();
        
        if (!isNaN(date.valueOf())) {
            if (date > currentDate) {
                const dateOfEmployment = currentDate.toISOString().slice(0, 10);
                this.setState({ dateOfEmployment: dateOfEmployment });
            } else {
                const dateOfEmployment = date.toISOString().slice(0, 10);
                this.setState({ dateOfEmployment: dateOfEmployment });
            }
        }
    }

    onTariffRateChanged = (e) => {
        const tariffRate = e.target.value;
        this.setState({ tariffRate: tariffRate });
    }

    onpositionIdChanged = (e) => {
        const positionId = e.target.value;
        this.setState({ positionId: positionId });
    }

    onDepartmentIdChanged = (e) => {
        const departmentId = e.target.value;
        this.setState({ departmentId: departmentId });
    }

    // !

    loadEditData() {
        const apiUrl = this.props.config.API_URL;
        const employeeId = this.props.currentEditId;

        axios.post(apiUrl + "employee/get", { id: employeeId }).then((response) => {
            let data = response.data;
            data['dateOfBirth'] = data['dateOfBirth'].slice(0, 10);
            data['dateOfEmployment'] = data['dateOfEmployment'].slice(0, 10);

            if(!data['surname'])
                data['surname'] = '';

            this.setState(data);
        }).catch((error)=>{
            const showError = this.props.showError;
            showError(error);
        });
    }

    onFormSubmit(e) {
        e.preventDefault();

        const apiUrl = this.props.config.API_URL;

        const data = new FormData(e.target);
        let values = {};
        data.forEach((value, key) => {
            values[key] = value;
        })
        
        values['employeeId'] = this.props.currentEditId;
        if(values.surname === '')
            delete values.surname;

        const jsonData = JSON.stringify(values);
        axios.post(apiUrl + "employee/edit", values).then((response) => {
            alert("Данные сотрудника изменены");
            document.querySelector('#close-edit-window').click();
            document.querySelector('#btn-find').click();
        }).catch((error)=>{
            const showError = this.props.showError;
            showError(error);
        });

    }

    render() {

        return <div className="modal fade" id="editWindow" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div className="modal-dialog">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5" id="exampleModalLabel">Редактировать сотрудника</h1>
                        <button type="button" id="close-edit-window" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <form id={"addForm"} onSubmit={this.onFormSubmit}>
                        <div className="modal-body p-3">
                            <div className="form-floating mb-3 ">
                                <input type="text" className="form-control" id="lastname" name="lastname"
                                    min={2}
                                    max={30}
                                    required={true}
                                    value={this.state.lastname}
                                    onChange={this.onLastnameChanged}
                                />
                                <label htmlFor="lastname">Фамилия</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="text" className="form-control" id="firstname"
                                    name="firstname"
                                    min={2} max={30}
                                    required={true}
                                    value={this.state.firstname}
                                    onChange={this.onFirstnameChanged}

                                />
                                <label htmlFor="firstname">Имя</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="text" className="form-control" id="surname" name="surname"
                                    min={2}
                                    max={30}
                                    required={false}
                                    value={this.state.surname}
                                    onChange={this.onSurnameChanged}
                                />
                                <label htmlFor="surname">Отчество</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="date" className="form-control" id="dateOfBirth" name="dateOfBirth"
                                    required={true}
                                    onChange={this.onDateOfBirthChanged}
                                    max={new Date().toISOString().slice(0,10)}
                                    value={this.state.dateOfBirth}
                                />
                                <label htmlFor="dateOfBirth">Дата рождения</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="date" className="form-control" id="dateOfEmployment" name="dateOfEmployment"
                                    required={true}
                                    onChange={this.onDateOfEmploymentChanged}
                                    max={new Date().toISOString().slice(0,10)}
                                    value={this.state.dateOfEmployment}
                                />
                                <label htmlFor="dateOfEmployment">Дата устройства на работу</label>
                            </div>
                            <div className="form-floating mb-3 ">
                                <input type="number" className="form-control" id="tariffRate" name="tariffRate"
                                    min={0}
                                    max={10000000}
                                    required={true}
                                    key={this.state.tariffRate ? 'notLoaded' : 'loaded'}
                                    value={this.state.tariffRate}
                                    onChange={this.onTariffRateChanged}
                                />
                                <label htmlFor="tariffRate">Оклад</label>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="postion" className="form-label">Должность</label>
                                <select id="postion" className="form-select" name="positionId" required={true}
                                    value={this.state.positionId}
                                    onChange={this.onpositionIdChanged}
                                >
                                    <option disabled={true}>Выберите должность ...</option>
                                    {this.props.positions.map((item, idx) => {
                                        return <option value={item.id} key={item.id}>{item.name}</option>
                                    })}
                                </select>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="department" className="form-label" >Отдел</label>
                                <select id="department" className="form-select" name="departmentId" required={true}
                                    value={this.state.departmentId}
                                    onChange={this.onDepartmentIdChanged}
                                >
                                    <option disabled={true}>Выберите отдел ...</option>
                                    {this.props.departments.map((item, idx) => {
                                        return <option value={item.id} key={item.id}>{item.name}</option>
                                    })}
                                </select>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Отмена</button>
                            <button type="submit" className="btn btn-primary">Сохранить</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>;
    }
}