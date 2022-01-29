import React, { useState } from "react";
import { useLocalStorage } from "react-use";
import { useNavigate } from "react-router-dom";
import Table from "../components/Table";
import { TableUsers, TablePersons, TableProfiles, TablePermissions } from "../services/Constants";
import * as Api from '../services/api';
import * as Authorization from '../services/authorization';


function Home() {
  const [person, setPerson, removePerson] = useLocalStorage('person', {});
  const [action, setAction] = useState("");
  const [pages, setPages] = useState([])

  const navigate = useNavigate();

  const singUp = () => {
    removePerson();
    navigate('/');
  }

  const columns = () => {
    switch (action) {
      case 'usuarios':
        return TableUsers;
      case 'personas':
        return TablePersons;
      case 'roles':
        return TableProfiles;
      case 'permisos':
        return TablePermissions;
    }
  }

  const options = (option) => {
    setAction(option);
    setPages([]);
    switch (option) {
      case 'usuarios':
        Api.users(person.nombre).then((users) => setPages(users));
        break;
      case 'personas':
        Api.persons(person.nombre).then((persons) => setPages(persons));
        break;
      case 'roles':
        Api.roles().then((persons) => setPages(persons));
        break;
      case 'permisos':
        Api.permissions().then((persons) => setPages(persons));
        break;
    }

  }

  const table = () => {
    if (action !== "") {
      let colmunsTable = columns()
      return (
        <div className="shadow p-2 mb-5 rounded text-center">
          <h3>{action.toUpperCase()}</h3>
          {filters()}
          <Table headers={colmunsTable} body={pages} />
        </div>
      );
    }
  }

  const filters = () => {
    if (Authorization.ValidateAuthorization(["filtros"], person.permisos) && action === "usuarios") {
      return (
        <div className="col-4">
          <div className="input-group mb-3">
            <input type="text" className="form-control" placeholder="Nombre" />
            <span className="input-group-text">Filtros</span>
            <input type="text" className="form-control" placeholder="Rol" />
          </div>
        </div>
      )
    }
  }

  const administration = () => {
    if (Authorization.ValidateAuthorization(["lista_usuarios"], person.permisos)) {
      return (
        <div className="row">
          <div className="col-12">
            <div className="shadow p-3 mb-5 rounded">
              <h5>Administración del Sistema</h5>
              <div className="d-flex justify-content-evenly">
                <button type="button" onClick={() => options("usuarios")} className="btn btn-outline-success">Usuarios</button>
                <button type="button" onClick={() => options("personas")} className="btn btn-outline-success">Personas</button>
                <button type="button" onClick={() => options("roles")} className="btn btn-outline-success">Roles</button>
                <button type="button" onClick={() => options("permisos")} className="btn btn-outline-success">Permisos</button>
              </div>
            </div>
            {table()}
          </div>
        </div>
      )
    }
  }

  return (
    <div className="container mt-2">
      <div className="row">
        <div className="col-12 user-bar">
          <div className="user-bar-info">
            <span className="mr-8">{person.persona.nombre} {person.persona.apellido}</span>
            <small>{person.nombre}</small>
          </div>
          <button className="btn btn-outline-success" onClick={() => singUp()}>Cerrar Sesion</button>
        </div>
      </div>
      <div className="row mt-4">
        <div className="col-12">
          <div className="alert alert-success mt-2" role="alert">
            <h4 className="alert-heading">Bienvendo {person.persona.nombre}!</h4>
            <p>Este es el Home de la empresa</p>
          </div>
        </div>
      </div>
      {administration()}
    </div>
  );
}

export default Home;