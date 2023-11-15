import axios, { Axios } from "axios";
import React from "react";


export default class RequestErrorPanel extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            message: ""
        }
    }

    showError = (error) => {
        let message = "";

        switch (error.code) {
            case "ERR_NETWORK":
                message = "Возникли проблемы при подключении к серверу, связанные с сетью";
                break;
            default:
                message = "Возникли проблемы при подключении к серверу";
                break;
        }

        const data = { message: message };
        this.setState(data);
    }

    removeClick = () =>{
        const data = { message: "" };
        this.setState(data);
    }

    render() {
        return <div>
            {this.state.message &&
                <div className="alert alert-danger fade show " role="alert">
                    {/* <svg className="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Danger:"><use xlink: href="#exclamation-triangle-fill" /></svg> */}
                    <strong>Ошибка!</strong> {this.state.message}
                    <button type="button" className="btn-close position-absolute end-0 me-3" data-bs-dismiss="alert" aria-label="Close" onClick={this.removeClick}></button>
                </div>
            }
        </div>;
    }
}