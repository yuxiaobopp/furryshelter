import { render } from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import App from "./App";
import NavBar from "./components/navbar";
import LoginPage from "./components/LoginPage";
import Contact from "./components/Contact";

import SignUp from "./components/SignUp";
import PetList from "./components/PetList";
import Verification from "./components/Verificatioin";
import Donation from "./components/Donation";
import HomePage from "./pages/HomePage";
const rootElement = document.getElementById("root");
render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path="home" element={<HomePage />} />
      <Route path="about" element={<PetList />} />
      <Route path="login" element={<LoginPage />} />
      <Route path="signup" element={<SignUp />} />
      <Route path="verification" element={<Verification />} />
      <Route path="donation" element={<Donation />} />
      <Route path="contact" element={<Contact />} />
    </Routes>
  </BrowserRouter>,
  rootElement
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
