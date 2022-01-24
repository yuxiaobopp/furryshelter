import React from "react";
import TextField from "@material-ui/core/TextField";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";

const useStyles = makeStyles((theme) => ({
  root: {
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      width: "25ch",
    },
  },
}));

export default function Register() {
  const classes = useStyles();
  return (
    <div>
      this is a Sign up page
      <form className={classes.root} noValidate autoComplete="off">
        <div>
          <TextField id="standard-required" label="Username" type="username" />

          <TextField
            id="standard-password-input"
            label="Password"
            type="password"
            autoComplete="current-password"
          />
          <TextField
            id="standard-password-confirm"
            label="Comfirm Password"
            type="comfirm-password"
            autoComplete="current-password"
          />
        </div>
        <div>
          <TextField id="standard-required" label="Username" type="username" />

          <TextField
            id="standard-password-input"
            label="Password"
            type="password"
            autoComplete="current-password"
          />
          <TextField
            id="standard-password-confirm"
            label="Comfirm Password"
            type="comfirm-password"
            autoComplete="current-password"
          />
        </div>
      </form>
      <Button variant="contained" color="primary">
        Primary
      </Button>
    </div>
  );
}
