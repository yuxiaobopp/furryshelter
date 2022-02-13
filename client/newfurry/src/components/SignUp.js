import React from "react";
import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

import Checkbox from "@material-ui/core/Checkbox";

import Grid from "@material-ui/core/Grid";
import Box from "@material-ui/core/Box";

import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";
import Container from "@material-ui/core/Container";
import Radio from "@material-ui/core/Radio";
import RadioGroup from "@material-ui/core/RadioGroup";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import FormControl from "@material-ui/core/FormControl";
import FormLabel from "@material-ui/core/FormLabel";
import { lightBlue } from "@material-ui/core/colors";

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(3),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
    backgroundColor: "#659dbd",
  },
}));

export default function SignUp() {
  const classes = useStyles();
  const [value, setValue] = React.useState("female");

  const handleChange = (event) => {
    setValue(event.target.value);
  };

  const register = (event) => {
    fetch("http://localhost:5000​/Front_Domain​/front_user​/UserRegister", {
      method: "post",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        UserName: this.state.email,
        Password: this.state.password,
        Email: this.state.email,
        RealName: this.state.lastName + this.state.firstName,
        IfPet: this.state.female,
      }),
    })
      .then((Response) => Response.json())
      .then((Result) => {
        if (Result.Status == "Success") this.props.history.push("/Dashboard");
        else alert("Sorrrrrry !!!! Un-authenticated User !!!!!");
      });
  };

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Avatar></Avatar>
        <Typography component="h1" variant="h5">
          注册账号
        </Typography>
        <form className={classes.form} noValidate>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="lastName"
                label="姓"
                name="lastName"
                autoComplete="lname"
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <TextField
                autoComplete="fname"
                name="firstName"
                variant="outlined"
                required
                fullWidth
                id="firstName"
                label="名"
                autoFocus
              />
            </Grid>

            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="cellnumber"
                label="手机号码"
                name="email"
                autoComplete="cellnumber"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="email"
                label="电子邮箱"
                name="email"
                autoComplete="email"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                name="password"
                label="密码"
                type="password"
                id="password"
                autoComplete="current-password"
              />
            </Grid>
            <Grid item xs={12}>
              <FormControl component="fieldset">
                <FormLabel component="legend">是否养过宠物</FormLabel>
                <RadioGroup
                  aria-label="raised-pet"
                  name="raised-1"
                  value={value}
                  onChange={handleChange}
                >
                  <FormControlLabel value="1" control={<Radio />} label="是" />
                  <FormControlLabel value="0" control={<Radio />} label="否" />
                </RadioGroup>
              </FormControl>
            </Grid>
            <Grid item xs={12}>
              <FormControlLabel
                control={<Checkbox value="allow" color="primary" />}
                label="同意注册"
              />
            </Grid>
          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            className={classes.submit}
            onClick={register}
          >
            确定注册
          </Button>
          <Grid container justifyContent="flex-end">
            <Grid item>
              {/* <Link to="/login">已有账号？ 登陆</Link> */}
              <a href="#">已有账号？ 登陆</a>
            </Grid>
          </Grid>
        </form>
      </div>
      <Box mt={5}></Box>
    </Container>
  );
}
