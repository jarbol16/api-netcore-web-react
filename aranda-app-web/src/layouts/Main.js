import { Component } from "react";
import { Route, Routes, BrowserRouter as Router } from "react-router-dom";
import Home from '../pages/Home';
import Login from '../pages/Login';

const routing = (
  <Router>
    <Routes>
      <Route  path="/" element={<Login />} />
      <Route  path="/home" element={<Home />} />
    </Routes>
  </Router>
);

class Main extends Component {
  render() {
    return (
      <section className="container main-container" >
        {routing}
      </section>
    );
  }
}

export default Main;