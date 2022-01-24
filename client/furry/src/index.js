import { render } from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import App from "./App";
import NavBar from "./components/navbar";
import LoginPage from "./components/LoginPage";
import Contact from "./components/Contact";
import Register from "./components/Register";

import Pet from "./components/Pet";

const rootElement = document.getElementById("root");
render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path="home" element={<NavBar />} />
      <Route path="about" element={<Pet />} />
      <Route path="login" element={<LoginPage />} />
      <Route path="register" element={<Register />} />
      <Route path="contact" element={<Contact />} />
    </Routes>
  </BrowserRouter>,
  rootElement
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
