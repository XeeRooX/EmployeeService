import React from "react";
import { Link } from "react-router-dom";
import personImg from '../../imgs/person.jpg'

export default class AboutIndex extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="m-4">
                <h2>
                    <i className="bi bi-buildings me-3" style={{ fontSize: "40px" }}></i>
                    О компании
                </h2>
                <div className="row mt-3">
                    <div className="col-12 col-lg-5 rounded-5 d-flex align-items-center justify-content-center ">
                        <img src={personImg} className="img-fluid"></img>
                    </div>
                    <div className="col-12 col-lg-7 rounded-5 p-3 px-5 shadow">
                        <div className="row">
                            <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Harum quibusdam recusandae amet beatae hic natus culpa. Vel facere cupiditate animi aperiam non repudiandae repellendus, omnis perspiciatis earum commodi ipsam exercitationem veniam optio placeat. Velit et, magni voluptate repudiandae eaque aliquam aut numquam suscipit autem nulla temporibus libero explicabo architecto totam.</p>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ex voluptate, facere praesentium iste veritatis modi quae? Consectetur, officia culpa aperiam debitis qui quo quidem maxime adipisci, repellat vero nobis dicta?</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere sapiente cumque sunt consequuntur! Reiciendis corporis, eaque neque obcaecati ratione mollitia explicabo, nesciunt dignissimos sint distinctio a. Sed aspernatur rerum vitae.</p>
                        </div>
                        <div className="row float-end mt-3">
                            <a className="btn read-more-btn rounded-pill" href="#">Читать далее ...
                            
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}