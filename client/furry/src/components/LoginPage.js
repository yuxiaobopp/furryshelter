import LoginForm from "./LoginForm";
import React, { useState } from "react";
import NavBar from "./navbar";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

function LoginPage() {
  const adminUser = {
    email: "admin@admin.com",
    password: "admin1234",
  };

  const [user, setUser] = useState({ name: "", email: "" });
  const [error, setError] = useState("");

  //this is a function to attempt login
  const Login = (details) => {
    console.log(details);
    if (
      details.email === adminUser.email &&
      details.password === adminUser.password
    ) {
      console.log("Login succeed!");
      setUser({
        name: details.name,
        email: details.email,
      });
    } else {
      console.log(" 账号或者密码不正确");
      setError("账号或密码不正确");
    }
  };

  const Logout = () => {
    console.log("Logout");
    setUser({ name: "", email: "" });
  };

  return (
    <div className="App">
      {user.email != "" ? (
        <div className="welcome">
          <h2>
            {" "}
            <span>{user.name}</span>, 欢迎来到furryshelter
          </h2>
          <Link to="/home">
            <button onClick={Logout}>退出账号</button>
          </Link>
        </div>
      ) : (
        <LoginForm Login={Login} error={error}></LoginForm>
      )}
    </div>
  );
}

export default LoginPage;
