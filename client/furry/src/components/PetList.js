import "./Pet.css";
import NavBar from "./navbar";
import Grid from "@material-ui/core/Grid";
import pic1 from "./1.jpeg";
import pic2 from "./2.jpeg";
import pic3 from "./3.jpeg";
import pic4 from "./4.jpeg";
import pic5 from "./5.jpeg";

const pets = [
  {
    name: "Lily",
    age: "2 year old",
    img: pic1,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "Jason",
    age: "3 year old",
    img: pic2,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "Abby",
    age: "1 year old",
    img: pic3,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "kate",
    age: "2.5 year old",
    img: pic4,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "Yvan",
    age: "3 year old",
    img: pic5,
    story:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda necessitatibus quidem perspiciatis a nisi sequi eaque tenetur adipisci voluptatem error aliquid, iste molestias harum odio odit, fugiat, velit animi placeat.",
  },
  {
    name: "Bob",
    age: "3 year old",
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
      <NavBar></NavBar>
      <section className="petlist">
        {pets.map((pet) => {
          const { img, name, age, story } = pet;
          // return <Pet img={img} name={name} age={age} story={story}></Pet>;
          return <Pet pet={pet}></Pet>;
        })}
      </section>
    </div>
  );
}

export default PetList;
