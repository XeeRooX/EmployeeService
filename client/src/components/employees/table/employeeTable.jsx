import React from "react";
import EmployeeTableRow from "./employeeTableRow";
import EmployeeTableEmpty from "./employeeTableEmpty";

export default class EmployeeTable extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount(){
    document.querySelector('#btn-find').click();
  }

  render() {
    const employees = this.props.tableData.employees;
    console.log(employees);

    return (
      <div className="mt-2">
        <table class="table">
          <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">ФИО</th>
              <th scope="col">Дата рождения</th>
              <th scope="col">Дата устройства на работу</th>
              <th scope="col">Заработная плата (₽)</th>
              <th scope="col">Действия</th>
            </tr>
          </thead>
          <tbody class="table-group-divider">
            {
              employees.length != 0 && (employees.map((item, idx)=>{
                return <EmployeeTableRow
                  key={idx}
                  idx={idx + 1}
                  setCurrentEditId={this.props.setCurrentEditId}
                  setCurrentDeleteFio={this.props.setCurrentDeleteFio}
                  {... item}
                ></EmployeeTableRow>;
              }))
            }
          </tbody>
        </table>
        <div>
            {employees.length == 0 && <EmployeeTableEmpty />}
          </div>
      </div>
    );
  }
}