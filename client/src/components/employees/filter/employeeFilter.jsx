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

    onAddClick(){
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
            //console.log(response.data);
            setEmployees(response.data);
        }).catch((error)=>{
            const showError = this.props.showError;
            showError(error);
        });
    }

    render() {
        const positions = this.props.filterData.positions;

        return (
            <div className="row">
                <div className="col-1 text-center pe-0">
                    <div className="py-3 border rounded mx-auto">
                        <button className="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#addWindow" onClick={this.onAddClick}>
                            <i class="bi bi-plus-circle-dotted"></i>
                        </button>
                    </div>
                </div>
                <div className="col">
                    <div id="filter" className="py-3 border rounded">
                        <div className="row px-3">
                            <div className="col" >
                                <div className="row">
                                    <div className="col">
                                        <button className="btn btn-secondary w-100 active fio-ascending" onClick={this.onFilterClick}>ФИО по возрастанию</button>
                                    </div>
                                    <div className="col">
                                        <button className="btn btn-secondary w-100 fio-descending" onClick={this.onFilterClick}>ФИО по убыванию</button>
                                    </div>
                                </div>
                            </div>
                            <div className="col">
                                <div className="row">
                                    <div className="col-9">
                                        <select className="form-select" onChange={this.onPositionSelectChanged}>
                                            <option selected disabled>Выберите нужную должность</option>
                                            <option value={0} >Любая</option>
                                            {positions.map((item, id) => {
                                                return <option value={item.id} key={item.id}>{item.name}</option>
                                            })}
                                        </select>
                                    </div>
                                    <div className="col-3">
                                        <button id="btn-find" className="btn btn-secondary w-100" onClick={this.onFindClick} >Найти</button>
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