import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import Box from "@material-ui/core/Box";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import Container from "@material-ui/core/Container";
import Typography from "@material-ui/core/Typography";
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

function LoginForm({ Login, error }) {
  const classes = useStyles();
  const [details, setDetails] = useState({ name: "", email: "", password: "" });

  const submitHandler = (e) => {
    e.preventDefault();
    Login(details);
  };

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Avatar></Avatar>
        <Typography component="h1" variant="h5">
          登陆
        </Typography>
        <form onSubmit={submitHandler} className={classes.form} noValidate>
          <Grid container spacing={2}>
            {/* check password correctness */}
            {error !== "" ? <div className="error">{error}</div> : ""}

            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="email"
                label="邮箱"
                name="email"
                autoComplete="email"
                onChange={(e) =>
                  setDetails({ ...details, email: e.target.value })
                }
                value={details.email}
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
                onChange={(e) =>
                  setDetails({ ...details, password: e.target.value })
                }
                value={details.password}
              />{" "}
            </Grid>
          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            className={classes.submit}
          >
            确定注册
          </Button>
        </form>
      </div>
    </Container>
  );
}

export default LoginForm;
