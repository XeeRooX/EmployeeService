import React from "react";


export default class EmployeesPagination extends React.Component {
    constructor(props) {
        super(props);
    }

    onPageClick = async (e) =>{
        const id = Number(e.target.id);
        const setCurrentPage = this.props.setCurrentPage;

        await setCurrentPage(id);
        document.querySelector('#btn-find').click();
    }

    onNextPageClick = async () =>{
        const setCurrentPage = this.props.setCurrentPage;
        await setCurrentPage(this.props.currentPage + 1);
        document.querySelector('#btn-find').click();
    }

    onPrevPageClick = async () =>{
        const setCurrentPage = this.props.setCurrentPage;
        await setCurrentPage(this.props.currentPage - 1);
        document.querySelector('#btn-find').click();
    }

    render() {
        const countPages = this.props.countPages;
        const currentPage = this.props.currentPage;
        const isDisabled = this.props.isDisabled;

        let range = Array.apply(null, Array(countPages));

        return (
            <div hidden={countPages == 0}>
                <nav aria-label="Page navigation example" className="rounded-5">
                    <ul className="pagination justify-content-center">
                        {currentPage == 1 ?
                            <li className="page-item disabled">
                                <a className="page-link left-pill-porder" onClick={this.onPrevPageClick}>Назад</a>
                            </li> :
                            <li classNames="page-item" >
                                {isDisabled ? <a className="page-link disabled left-pill-porder" href="#" onClick={this.onPrevPageClick}>Назад</a> : 
                                <a className="page-link left-pill-porder" href="#" onClick={this.onPrevPageClick}>Назад</a>}
                            </li>
                        }
                        {
                            range.map((el, idx) => {
                                return !isDisabled ? ((idx + 1) == currentPage ?
                                    <li className="page-item" key={idx}><a className="page-link active" href="#" onClick={this.onPageClick} id={idx+1}>{idx + 1}</a></li> :
                                    <li className="page-item" key={idx}><a className="page-link" href="#" onClick={this.onPageClick} id={idx+1}>{idx + 1}</a></li>) :
                                    <li className="page-item" key={idx}><a className="page-link disabled" href="#" onClick={this.onPageClick} id={idx+1}>{idx + 1}</a></li>
                            })
                        }
                        {currentPage != countPages ?
                            <li className="page-item">
                                {isDisabled ? <a className="page-link disabled" href="#" onClick={this.onNextPageClick}>Слеедующая</a> : 
                                <a className="page-link" href="#" onClick={this.onNextPageClick}>Слеедующая</a>}
                              </li>
                            :
                            <li className="page-item disabled">
                                <a className="page-link" onClick={this.onNextPageClick}>Слеедующая</a>
                            </li>
                        }

                    </ul>
                </nav>
            </div>
        );
    }
}