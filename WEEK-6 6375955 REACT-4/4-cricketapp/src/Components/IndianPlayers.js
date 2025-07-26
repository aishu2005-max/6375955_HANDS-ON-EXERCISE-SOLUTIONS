import React from 'react';

const IndianPlayers = () => {
  const players = ["Rohit", "Gill", "Kohli", "SKY", "Rahul", "Hardik"];

  // Destructure Odd and Even Players
  const oddPlayers = players.filter((_, index) => index % 2 === 0);
  const evenPlayers = players.filter((_, index) => index % 2 !== 0);

  // Merge two arrays
  const T20players = ["Kohli", "Rohit", "Hardik"];
  const RanjiTrophyPlayers = ["Pujara", "Rahane", "Ashwin"];
  const mergedPlayers = [...T20players, ...RanjiTrophyPlayers];

  return (
    <div>
      <h2>Odd Team Players</h2>
      <ul>
        {oddPlayers.map((player, index) => (
          <li key={index}>{player}</li>
        ))}
      </ul>

      <h2>Even Team Players</h2>
      <ul>
        {evenPlayers.map((player, index) => (
          <li key={index}>{player}</li>
        ))}
      </ul>

      <h2>Merged Team (T20 + Ranji)</h2>
      <ul>
        {mergedPlayers.map((player, index) => (
          <li key={index}>{player}</li>
        ))}
      </ul>
    </div>
  );
};

export default IndianPlayers;