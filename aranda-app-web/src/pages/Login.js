import React, { useCallback, useState } from "react";
import * as Api from '../services/api';
import { useLocalStorage } from 'react-use';
import { useNavigate   } from "react-router-dom";

function Login()  {

    const [person, setPerson, removePerson] = useLocalStorage('person', {});
    let navigate = useNavigate();
    var message = "";

    const onSubmit = useCallback( async (event) => {
      event.preventDefault();
      const form = new FormData(event.target)
      const user = Object.fromEntries(form.entries())
      const data = await Api.signIn(user);
      try{
        if (data !== ''){
          setPerson(data);
        }else{
          message = "Usuario invalido";
          console.log("Usuario invalido");
        }
      }catch{
        console.log("Ocurrio un error inseperado");
      }

    }, [])
    
    if (Object.keys(person ?? {}).length > 0) {
      navigate('/home');
    }

    return (
      <form className="row mt-4" onSubmit={onSubmit}>
        <div className="col-12 shadow p-3 mb-5 rounded">
          <h1 className="title-h1">Login</h1>
          <div className="card p-2 mt-4">
            <div className="mb-3">
              <label htmlFor="formGroupExampleInput" className="form-label">User</label>
              <input name="user" type="text" className="form-control" id="formGroupExampleInput" placeholder="User" />
            </div>
            <div className="mb-3">
              <label htmlFor="formGroupExampleInput2" className="form-label">Password</label>
              <input name="pass" type="password" className="form-control" id="formGroupExampleInput2" placeholder="Password" />
            </div>
            <button type="submit" className="btn btn-success">Accept</button>
          </div>
        </div>
      </form>
    );
  
}

export default Login;