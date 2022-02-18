import "./Pet.css";

import Grid from "@material-ui/core/Grid";
import pic1 from "../assets/1.jpeg";
import pic2 from "../assets/2.jpeg";
import pic3 from "../assets/3.jpeg";
import pic4 from "../assets/4.jpeg";
import pic5 from "../assets/5.jpeg";
import { Container } from "@material-ui/core";

const pets = [
  {
    name: "Lily",
    age: "2 years old",
    img: pic1,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "Jason",
    age: "3 years old",
    img: pic2,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "Abby",
    age: "1 years old",
    img: pic3,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "kate",
    age: "2.5 years old",
    img: pic4,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "Yvan",
    age: "3 years old",
    img: pic5,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "Bob",
    age: "3 years old",
    img: pic2,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
];

const Pet = (props) => {
  const { img, name, age, story } = props.pet;
  return (
    <div>
      <article className="pet">
        <img src={img} alt="" className="pet"></img>
        <h1>{name}</h1>
        <h4>{age}</h4>
        <p>{story}</p>
      </article>
    </div>
  );
};
const names = ["a", "asda", "adsa"];
const newnames = names.map((name) => {
  return <h1>{name}</h1>;
});
function PetList() {
  return (
    <div>
      <Container className="petlist">
        {pets.map((pet) => {
          const { img, name, age, story } = pet;
          // return <Pet img={img} name={name} age={age} story={story}></Pet>;
          return <Pet pet={pet}></Pet>;
        })}
      </Container>
    </div>
  );
}

export default PetList;
