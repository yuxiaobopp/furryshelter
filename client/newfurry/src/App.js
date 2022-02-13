import React from "react";
import Hero from "./components/Hero";
import PetList from "./components/PetList";
import LoginPage from "./pages/LoginPage";
import SignUp from "./components/SignUp";
import Footer from "./components/Footer";
import NavBar from "./components/navbar";
import Contact from "./components/Contact";
export default function App() {
  return (
    <div>
      <section>
        <NavBar></NavBar>
        <Hero></Hero>
        {/* <PetList></PetList> */}

        <LoginPage></LoginPage>
        <SignUp></SignUp>
        <Contact></Contact>
        <Footer></Footer>
      </section>
    </div>
  );
}
