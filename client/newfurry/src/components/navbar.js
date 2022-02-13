import "./navbar.css";
import Avatar from "@material-ui/core/Avatar";

import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

function NavBar() {
  return (
    <div>
      <header className="navbar">
        <div className="navbar__title navbar__item">Furry Shelter</div>
        {/* <Link to="/home">
          <div className="navbar__item">首页</div>
        </Link>

        <Link to="/about">
          <div className="navbar__item">毛茸茸社区</div>
        </Link>
        <Link to="/donation">
          <div className="navbar__item">爱心捐助</div>
        </Link>

        <Link to="/contact">
          <div className="navbar__item">联系我们</div>
        </Link> */}
        {/* <div>
          <Link to="/signup"></Link>
        </div> */}
        <a href="#" className="navbar__item">
          主页
        </a>
        <a href="#" className="navbar__item">
          社区
        </a>
        <a href="#" className="navbar__item">
          爱心助力
        </a>
        <Avatar></Avatar>
      </header>
    </div>
  );
}

export default NavBar;
