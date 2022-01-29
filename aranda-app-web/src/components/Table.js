import React, { Component } from "react";

class Table extends Component {

  buildRow(row, i) {
    return (
      <tr>
        <th scope="row">{i}</th>
        {
          this.props.headers.map((obj, i) =>
            <td>{row[obj.id]}</td>
          )
        }
        <td><div>
        <i className="glyphicon glyphicon-cloud"></i>
        <i className="fas fa-trash-alt"></i>
        </div>
        
        </td>
      </tr>
    )
  }


  render() {
    return (
      <table className="table table-success table-striped text-start">
        <thead>
          <tr>
            <th scope="col">#</th>
            {
              this.props.headers.map((object, i) =>
                <th scope="col">{object.name}</th>
              )
            }
            <th scope="col">Acciones</th>
          </tr>
        </thead>
        <tbody>
          {
            this.props.body.map((obj, i) =>
              this.buildRow(obj, i + 1)
            )
          }
        </tbody>
      </table>
    );
  }
}

export default Table;