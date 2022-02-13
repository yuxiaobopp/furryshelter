import React from "react";
import Hero from "./components/Hero";
import PetList from "./components/PetList";
import LoginPage from "./pages/LoginPage";
import SignUp from "./components/SignUp";

export default function App() {
  return (
    <div>
      <section>
        <Hero></Hero>
        {/* <PetList></PetList> */}

        <LoginPage></LoginPage>
        <SignUp></SignUp>
      </section>
    </div>
  );
}
