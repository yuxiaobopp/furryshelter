import React from "react";

import { Navbar, Footer, Contact } from "./components";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Link } from "react-router-dom";
import {
  HomePage,
  Error,
  About,
  LoginPage,
  Adoption,
  SignupPage,
  ForgetPasswordPage,
  SubscriptionPage,
} from "./pages";
export default function App() {
  return (
    <div>
      <Router>
        <Navbar></Navbar>
        <Routes>
          <Route exact path="/" element={<HomePage></HomePage>}></Route>
          <Route path="/login" element={<LoginPage />}></Route>
          <Route path="/about" element={<About></About>}></Route>
          <Route path="/adoption" element={<Adoption></Adoption>}></Route>
          <Route path="/signup" element={<SignupPage></SignupPage>}></Route>
          <Route path="/subscribe" element={<SubscriptionPage />}></Route>
          <Route
            path="/forgetpassword"
            element={<ForgetPasswordPage></ForgetPasswordPage>}
          ></Route>
        </Routes>
        <Contact></Contact>
        <Footer />
      </Router>
    </div>
  );
}
