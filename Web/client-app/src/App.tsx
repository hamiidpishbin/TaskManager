import React, { Fragment } from "react";
import "./App.css";
import SignUp from "./pages/Signup";
import { ToastContainer } from "react-toastify";
import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import Login from "./pages/Login";
import Sprint from "./pages/Sprint";
import Summary from "./pages/Summary";
import NavBar from "./pages/Navbar";
// import BaseTable from "./components/base/BaseTableEx";

function App() {
  return (
    <div className="App">
      <Fragment>
        <ToastContainer position="bottom-right" hideProgressBar />
        <NavBar />
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/sprints" element={<Sprint />} />
          <Route path="/summary" element={<Summary />} />
          <Route path="/signup" element={<SignUp />} />
          <Route path="/login" element={<Login />} />
          {/* <Route path="/table" element={<BaseTable />} /> */}
        </Routes>
      </Fragment>
    </div>
  );
}

export default App;
