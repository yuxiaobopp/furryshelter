import NavBar from "../components/navbar";
import LoginPage from "../components/LoginPage";
import pic2 from "../components/2.jpeg";

export default function HomePage() {
  return (
    <div>
      <NavBar></NavBar>
      <LoginPage />
      <img src={pic2} alt="" />
    </div>
  );
}
