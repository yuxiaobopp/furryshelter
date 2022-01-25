import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import Grid from "@material-ui/core/Grid";

export default function Verification() {
  return (
    <div>
      <h1>发送验证邮件</h1>
      <Grid>
        <TextField
          variant="outlined"
          required
          id="email"
          label="邮箱地址"
          name="email"
          autoComplete="email"
        />

        <Button color="primary" variant="contained">
          确认发送
        </Button>
      </Grid>
    </div>
  );
}
