import React from "react";
import { Component } from "react";

class Header extends Component {
  render() {
    return (
      <nav className="navbar navbar-dark header-navbar">
        <div className="container-fluid">
          <a className="navbar-brand">Aranda Web</a>
          <form className="d-flex">
            <input className="form-control me-2" type="search" placeholder="Buscar" aria-label="Search" />
            <button className="btn btn-outline-success" type="submit">Buscar</button>
          </form>
        </div>
      </nav>
    );
  }
}
export default Header;