import React from "react";
import "./App.css";

function App() {
  // JSX element for the heading
  const element = "Office Space";

  // Image attribute
  const imgSrc = "https://via.placeholder.com/400x200?text=Office+Space";

  // Object for office space
  const itemName = {
    Name: "DBS",
    Rent: 50000,
    Address: "Chennai",
  };

  // Color condition
  let rentColor = "";
  if (itemName.Rent <= 60000) {
    rentColor = "textRed";
  } else {
    rentColor = "textGreen";
  }

  return (
    <div className="App">
      <h1>{element}, at Affordable Range</h1>
      <img src={imgSrc} alt="Office Space" width="25%" height="25%" />
      <h1>Name: {itemName.Name}</h1>
      <h3 className={rentColor}>Rent: Rs. {itemName.Rent}</h3>
      <h3>Address: {itemName.Address}</h3>
    </div>
  );
}

export default App;