import React, { Component } from 'react';
import Cart from './Cart';

class OnlineShopping extends Component {
  constructor() {
    super();
    this.state = {
      items: [
        { itemname: "Laptop", price: 80000 },
        { itemname: "TV", price: 120000 },
        { itemname: "Washing Machine", price: 50000 },
        { itemname: "Mobile", price: 30000 },
        { itemname: "Fridge", price: 70000 }
      ]
    };
  }

  render() {
    return (
      <div style={{ textAlign: "center", marginTop: "20px" }}>
        <h1 style={{ color: "green" }}>Items Ordered :</h1>
        <table
          style={{
            margin: "0 auto",
            borderCollapse: "collapse",
            width: "40%",
            textAlign: "center"
          }}
          border="1"
        >
          <thead>
            <tr style={{ backgroundColor: "#f0f0f0" }}>
              <th>Name</th>
              <th>Price</th>
            </tr>
          </thead>
          <tbody>
            {this.state.items.map((item, index) => (
              <Cart key={index} itemname={item.itemname} price={item.price} />
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

export default OnlineShopping;