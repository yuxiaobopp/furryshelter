import React from "react";
import Hero from "./components/Hero";
import PetList from "./components/PetList";
import LoginPage from "./pages/LoginPage";
import SignUp from "./components/SignUp";
import Footer from "./components/Footer";

export default function App() {
  return (
    <div>
      <section>
        <Hero></Hero>
        {/* <PetList></PetList> */}

        <LoginPage></LoginPage>
        <SignUp></SignUp>
        <Footer></Footer>
      </section>
    </div>
  );
}
