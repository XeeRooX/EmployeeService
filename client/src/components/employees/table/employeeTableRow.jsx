import React from "react";

export default class EmployeeTableRow extends React.Component {
    constructor(props) {
        super(props);

        this.onEditClick = this.onEditClick.bind(this);
    }

    async onEditClick(){
        const setCurrentEditId = this.props.setCurrentEditId;
        const setCurrentDeleteFio = this.props.setCurrentDeleteFio;

        const fio = `${this.props.lastname} ${this.props.firstname} ${this.props.surname}`;

        await setCurrentEditId(this.props.employeeId);
        await setCurrentDeleteFio(fio);
    }

    render() {
        const dateOfBirth = new Date(this.props.dateOfBirth);
        const dateOfEmployment = new Date(this.props.dateOfEmployment);

        return (


            <tr>
                <th scope="row">{this.props.idx}</th>
                <td>{this.props.lastname} {this.props.firstname} {this.props.surname}</td>
                <td>{dateOfBirth.toLocaleDateString("ru-RU")}</td>
                <td>{dateOfEmployment.toLocaleDateString("ru-RU")}</td>
                <td>{this.props.salary}</td>
                <td>
                    <button className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#editWindow" onClick={this.onEditClick}><i class="bi bi-pencil-square"></i></button>
                    <button className="btn btn-primary ms-2" data-bs-toggle="modal" data-bs-target="#deleteWindow" onClick={this.onEditClick}><i class="bi bi-trash"></i></button>
                </td>
            </tr>
        );
    }
}