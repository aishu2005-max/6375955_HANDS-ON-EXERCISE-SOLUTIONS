import React, { Component } from 'react';

class CountPeople extends Component {
  constructor() {
    super();
    this.state = {
      entrycount: 0,
      exitcount: 0,
    };
  }

  updateEntry() {
    this.setState((prevState) => {
      return { entrycount: prevState.entrycount + 1 };
    });
  }

  updateExit() {
    this.setState((prevState) => {
      return { exitcount: prevState.exitcount + 1 };
    });
  }

  render() {
    return (
      <div style={styles.container}>
        <div style={styles.box}>
          <button onClick={() => this.updateEntry()} style={styles.button}>Login</button>
          <span style={styles.text}>{this.state.entrycount} People Entered!!!</span>
        </div>
        <div style={styles.box}>
          <button onClick={() => this.updateExit()} style={styles.button}>Exit</button>
          <span style={styles.text}>{this.state.exitcount} People Left!!!</span>
        </div>
      </div>
    );
  }
}

const styles = {
  container: {
    display: 'flex',
    justifyContent: 'center',
    marginTop: '50px',
  },
  box: {
    margin: '0 40px',
    textAlign: 'center',
  },
  button: {
    backgroundColor: 'lightgreen',
    border: '1px solid green',
    padding: '10px 20px',
    cursor: 'pointer',
    fontWeight: 'bold',
    marginRight: '10px',
  },
  text: {
    fontSize: '18px',
    fontWeight: 'bold',
  },
};

export default CountPeople;