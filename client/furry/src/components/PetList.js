import "./Pet.css";
import NavBar from "./navbar";
import Grid from "@material-ui/core/Grid";

const firstPet = {
  name: "Lily",
  age: "2 year old",
  img: "https://images.unsplash.com/photo-1537151625747-768eb6cf92b2?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=685&q=80",
  story:
    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
};

const secondPet = {
  name: "Jason",
  age: "3 year old",
  img: "https://images.unsplash.com/photo-1552053831-71594a27632d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8ZG9nfGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=800&q=60",
  story:
    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
};

const Pet = (props) => {
  console.log(props);
  return (
    <article className="pet">
      <img src={props.img} alt="" className="pet"></img>
      <h1>{props.name}</h1>
      <h2>{props.age}</h2>
      <h4>{props.story}</h4>
    </article>
  );
};

function PetList() {
  return (
    <section className="petlist">
      <Pet
        img={firstPet.img}
        name={firstPet.name}
        age={firstPet.age}
        story={firstPet.story}
      ></Pet>
      <Pet
        img={secondPet.img}
        name={secondPet.name}
        age={secondPet.age}
        story={secondPet.story}
      ></Pet>
      <Pet
        img={secondPet.img}
        name={secondPet.name}
        age={secondPet.age}
        story={secondPet.story}
      ></Pet>
      <Pet
        img={firstPet.img}
        name={firstPet.name}
        age={firstPet.age}
        story={firstPet.story}
      ></Pet>
    </section>
  );
}

export default PetList;
