import axios from "axios";
import React from "react";
import AddEmployeeWindow from "../windows/addEmployeeWindow";


export default class EmployeesFilter extends React.Component {
    constructor(props) {
        super(props);

        this.onPositionSelectChanged = this.onPositionSelectChanged.bind(this);
        this.onFilterClick = this.onFilterClick.bind(this);
        this.onFindClick = this.onFindClick.bind(this);
        this.loadEmployees = this.loadEmployees.bind(this);
        this.onAddClick = this.onAddClick.bind(this);

    }

    componentDidMount() {

    }

    onFindClick() {
        const setPaginationDisabled = this.props.setPaginationDisabled;

        setPaginationDisabled(false);
        this.loadEmployees();
    }

    onAddClick() {
        document.querySelector('#addForm').reset();
    }

    async onPositionSelectChanged(e) {
        const setPosition = this.props.setPosition;
        const setCurrentPage = this.props.setCurrentPage;
        const setPaginationDisabled = this.props.setPaginationDisabled;

        await setCurrentPage(1);
        await setPaginationDisabled(true);

        setPosition(Number(e.target.value));
    }

    async onFilterClick(e) {
        const setFilterBy = this.props.setFilterBy;
        const setByDescending = this.props.setByDescending;
        const setCurrentPage = this.props.setCurrentPage;
        const setPaginationDisabled = this.props.setPaginationDisabled;

        e.target.parentElement.parentElement.childNodes.
            forEach((item) => {
                item.children[0].classList.remove("active");
            })

        await setCurrentPage(1);
        await setPaginationDisabled(true);

        e.target.classList.add("active");

        if (e.target.classList.contains("fio-ascending")) {
            setFilterBy("fio");
            setByDescending(false);
        } else if (e.target.classList.contains("fio-descending")) {
            setFilterBy("fio");
            setByDescending(true);
        }
    }

    loadEmployees() {
        const apiUrl = this.props.config.API_URL;
        const filter = this.props.filterData;
        const currentPage = this.props.currentPage;

        const data = {
            count: filter.count,
            page: currentPage,
            positionId: filter.positionId,
            sortBy: filter.filterby,
            sortByDescending: filter.byDescending
        };

        const setEmployees = this.props.setEmployees;

        axios.post(apiUrl + "employee/filter", data).then((response) => {
            setEmployees(response.data);
        }).catch((error) => {
            const showError = this.props.showError;
            showError(error);
        });
    }

    render() {
        const positions = this.props.filterData.positions;

        return (
            <div>
                <div className="row mx-0">
                    <div id="filter" className="p-0 ps-3 border rounded-5 pb-3">
                        <div className="row px-3">

                            <div className="col-12 col-md-6 p-3 ps-0 pb-0" >
                                <div className="row">
                                    <div className="col py-0 ">
                                        <button className="btn btn-secondary rounded-pill text-center add-btn me-2" data-bs-toggle="modal" style={{ float: "left" }} data-bs-target="#addWindow" onClick={this.onAddClick}>
                                            <i className="bi bi-plus-circle-dotted" style={{fontSize: "18px"}}></i>
                                        </button>
                                        <div className="row" style={{ marginLeft: "60px", overflow: "auto" }}>
                                            <div className="col p-0">
                                                <button className="btn btn-secondary active fio-ascending w-100 rounded-pill" onClick={this.onFilterClick}>
                                                    <i className="bi bi-sort-alpha-down me-2" style={{fontSize: "18px"}}></i>
                                                    ФИО
                                                </button>
                                            </div>
                                            <div className="col pe-0">
                                                <button className="btn btn-secondary rounded-pill fio-descending w-100" onClick={this.onFilterClick}>
                                                <i className="bi bi-sort-alpha-down-alt me-2" style={{fontSize: "18px"}}></i>ФИО
                                                    </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col p-3 pb-0 ps-0">
                                <div className="row">
                                    <div className="col-8">
                                        <select className="form-select rounded-pill" defaultValue={-1} onChange={this.onPositionSelectChanged}>
                                            <option value={-1} disabled>Выберите нужную должность</option>
                                            <option value={0} >Любая</option>
                                            {positions.map((item, id) => {
                                                return <option value={item.id} key={item.id}>{item.name}</option>
                                            })}
                                        </select>
                                    </div>
                                    <div className="col-4">
                                        <button id="btn-find" className="btn btn-secondary w-100 rounded-pill" onClick={this.onFindClick} >
                                        <i className="bi bi-search" style={{fontSize: "18px"}}></i> </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        )
    }
}