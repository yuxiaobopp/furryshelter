import "./Pet.css";
import NavBar from "./navbar";
import Grid from "@material-ui/core/Grid";
function Pet() {
  const Info = () => {
    return (
      <article>
        <Image></Image>
        <Name></Name>
        <Age></Age>
      </article>
    );
  };
  const Image = () => {
    return (
      <img
        style={{ width: "200px", height: "300px", borderRadius: "10px" }}
        src="https://images.unsplash.com/photo-1552053831-71594a27632d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8ZG9nfGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=800&q=60"
        alt=""
      />
    );
  };
  const Name = () => {
    return <h1>Lily</h1>;
  };

  const Age = () => {
    return <h4>2 years old</h4>;
  };
  return (
    <section className="pet">
      <Info></Info>
      <Info></Info>
      <Info></Info>
      <Info></Info>
      <Info></Info>
      <Info></Info>
      <Info></Info>
      <Info></Info>
      <Info></Info>
    </section>
  );
}

export default Pet;
