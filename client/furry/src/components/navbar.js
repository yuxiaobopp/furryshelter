import "./navbar.css";
import PersonIcon from "@material-ui/icons/Person";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

function NavBar() {
  return (
    <div>
      <header className="navbar">
        <div className="navbar__title navbar__item">Furry Shelter</div>
        <div className="navbar__item">首页</div>
        <div className="navbar__item">毛茸茸社区</div>
        <div className="navbar__item">爱心捐助</div>
        <div className="navbar__item">关于我们</div>
        <div>
          <PersonIcon></PersonIcon>
        </div>
      </header>
    </div>
  );
}

export default NavBar;
