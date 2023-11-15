import React from "react";
import { Link } from "react-router-dom";
import EmployeeTable from "./table/employeeTable";
import EmployeesFilter from "./filter/employeeFilter";
import EmployeesPagination from "./pagination/employeesPagination";
import AddEmployeeWindow from "./windows/addEmployeeWindow";
import EditEmployeeWindow from "./windows/editEmployeeWindow";
import DeleteEmployeeWindow from "./windows/deleteEmployeeWindow";
import RequestErrorPanel from "../errorPanels/requestError";
import axios from "axios";


export default class EmployeesIndex extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            filter: {
                filterby: "fio",
                byDescending: false,
                count: 5,
                positionId: 0,
                positions: [],
                countLoaded: 0,
                departments: []
            },
            table: {
                currentEditId : 0,
                currentDeleteFio : "",
                employees: []
            },
            pagination: {
                currentPage: 1,
                countPages: 0,
                isDisabled: false
            }
        }

        this.child = React.createRef();
        this.config = this.props.config;
        this.loadPosition = this.loadPosition.bind(this);
        this.loadDepartments = this.loadDepartments.bind(this);
        this.setSelectedPosition = this.setSelectedPosition.bind(this);
        this.setFilterByValue = this.setFilterByValue.bind(this);
        this.setByDescendingValue = this.setByDescendingValue.bind(this);
        this.setEmployeesValue = this.setEmployeesValue.bind(this);
        this.setCurrentEditId = this.setCurrentEditId.bind(this);
    }

    componentDidMount() {
        const apiUrl = this.config.API_URL;
        //await this.loadPosition();
        this.loadDepartments();
    }

    setCurrentEditId(id){
        const data = { table: { ...this.state.table, currentEditId: id } };
        this.setState(data);    
    }

    setCurrentDeleteFio = (fio) => {
        const data = { table: { ...this.state.table, currentDeleteFio: fio } };
        this.setState(() => data);
    }

    setSelectedPosition(id) {
        const data = { filter: { ...this.state.filter, positionId: id } };
        this.setState(() => data);
    }

    setByDescendingValue(value) {
        const data = { filter: { ...this.state.filter, byDescending: value } };
        this.setState(() => data);
    }

    setFilterByValue(value) {
        const data = { filter: { ...this.state.filter, filterby: value } };
        this.setState(() => data);
    }

    setEmployeesValue(value) {
        const items = value.items;
        const countPages = value.countPages;

        const data = { table: { ...this.state.table, employees: items } };
        const data2 = { pagination: { ...this.state.pagination, countPages: countPages } };

        this.setState(data);
        this.setState(data2);
    }

    loadDepartments() {
        const apiUrl = this.config.API_URL;

        axios.get(apiUrl + "department/getall").then((response) => {
            let departments = [];

            for (let d of response.data) {
                departments.push({ id: d.id, name: d.name });
            }


            const data = { filter: { ...this.state.filter, departments: departments } };
            this.setState(data, this.loadPosition);
        }).catch((error)=>{
            this.showError(error);
        });
    }

    loadPosition() {
        const apiUrl = this.config.API_URL;

        axios.get(apiUrl + "position/getall").then((response) => {
            let positions = [];

            for (let p of response.data) {
                positions.push({ id: p.id, name: p.name });
            }

            const data = { filter: { ...this.state.filter, positions: positions } };
            console.log("2 postions");
            console.log(data);
            this.setState(() => data);
        }).catch((error)=>{
            this.showError(error);
        });

    }

    showError = (error)=>{
        console.log("error "+ error)
        this.child.current.showError(error);
    }

    setCurrentPage = (idx) =>{
        const data = { pagination: { ...this.state.pagination, currentPage: idx } };
        this.setState(data);
    }

    setPaginationDisabled = (value) =>{
        const data = { pagination: { ...this.state.pagination, isDisabled: value } };
        this.setState(data);
    }

    render() {
        console.log("!!!!!!!!!!!!");
        console.log(this.state.filter);

        return (<div>
            <h2>Сотрудники</h2>
            <RequestErrorPanel ref={this.child}/>
            <div id="table" className="mt-3 pb-2 mb-3 border p-4 rounded-5">
                <AddEmployeeWindow
                    positions={this.state.filter.positions}
                    departments={this.state.filter.departments}
                    config={this.props.config}
                    showError={this.showError}
                />
                <EditEmployeeWindow 
                    positions={this.state.filter.positions}
                    departments={this.state.filter.departments}
                    config={this.props.config}
                    currentEditId={this.state.table.currentEditId}
                    showError={this.showError}
                />
                <DeleteEmployeeWindow 
                    config={this.props.config}
                    currentEditId={this.state.table.currentEditId}
                    currentDeleteFio={this.state.table.currentDeleteFio}
                    showError={this.showError}
                />
                <EmployeesFilter
                    filterData={this.state.filter}
                    setPosition={this.setSelectedPosition}
                    setFilterBy={this.setFilterByValue}
                    setByDescending={this.setByDescendingValue}
                    setEmployees={this.setEmployeesValue}
                    config={this.props.config}
                    showError={this.showError}
                    currentPage={this.state.pagination.currentPage}
                    setCurrentPage={this.setCurrentPage}
                    setPaginationDisabled={this.setPaginationDisabled}
                >
                </EmployeesFilter>
                <EmployeeTable
                    tableData={this.state.table}
                    setCurrentEditId={this.setCurrentEditId}
                    setCurrentDeleteFio={this.setCurrentDeleteFio}
                ></EmployeeTable>
                <EmployeesPagination
                    currentPage={this.state.pagination.currentPage}
                    countPages={this.state.pagination.countPages}
                    countLoad={this.state.filter.count}
                    setCurrentPage={this.setCurrentPage}
                    isDisabled={this.state.pagination.isDisabled}
                />
            </div>
        </div>
        );
    }
}