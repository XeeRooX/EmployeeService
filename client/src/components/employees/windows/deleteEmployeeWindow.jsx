import axios from "axios";
import React from "react";


export default class DeleteEmployeeWindow extends React.Component {
    constructor(props) {
        super(props);
    }

    deleteButtonClick = () => {
        const id = this.props.currentEditId;
        const apiUrl = this.props.config.API_URL;

        axios.delete(apiUrl + "employee/delete", {
            headers : { "Content-Type" : "application/json"},
            data : {id : id}
        }).then((response)=>{
            alert("Сотрудник удален");
            document.querySelector('#close-delete-window').click();
            document.querySelector('#btn-find').click();
        }).catch((error)=>{
            const showError = this.props.showError;
            showError(error);
        });
    }

    render() {
        return <div className="modal fade" id="deleteWindow" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div className="modal-dialog">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5" id="exampleModalLabel">Удалить сотрудника</h1>
                        <button type="button" id="close-delete-window" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body p-3">
                        <p className="m-0">Вы точно хотите удалить сотрудника: </p>
                        <p className="m-0"> <span style={{ fontWeight: "bold", fontStyle: "italic" }}>{this.props.currentDeleteFio}</span></p>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Отмена</button>
                        <button type="submit" className="btn btn-primary" onClick={this.deleteButtonClick}>Удалить</button>
                    </div>
                </div>
            </div>
        </div>;
    }
}