import LoginForm from "../components/LoginForm";
import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

async function loginUser(credentials) {
  return fetch("http://furryshelter/Base_Manage/Home/SubmitLogin", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(credentials),
  }).then((data) => data.json());
}

function LoginPage(setToken) {
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
          <h2> 欢迎来到furryshelter</h2>
        </div>
      ) : (
        <LoginForm Login={Login} error={error}></LoginForm>
      )}
    </div>
  );
}

export default LoginPage;
