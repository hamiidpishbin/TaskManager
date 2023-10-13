import React, { lazy, Suspense } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Spinner from "../Components/spinner";

const Login = lazy(() => import("../Pages/login"));
const Admin = lazy(() => import("../Pages/admin"));

function RoutesIndex() {
  return (
    <Suspense
      fallback={
        <div className="w-screen h-screen flex justify-center items-center">
          <Spinner center />
        </div>
      }
    >
      <Router>
        <Routes>
          <Route exact path="/" element={<Login />} />
          <Route exact path="/admin" element={<Admin />} />
        </Routes>
      </Router>
    </Suspense>
  );
}

export default RoutesIndex;
