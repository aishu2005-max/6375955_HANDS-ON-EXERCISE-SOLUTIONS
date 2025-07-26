import React from 'react';

const ListofPlayers = () => {
  const players = [
    { name: "Virat Kohli", score: 85 },
    { name: "Rohit Sharma", score: 65 },
    { name: "Shubman Gill", score: 72 },
    { name: "Suryakumar Yadav", score: 45 },
    { name: "KL Rahul", score: 90 },
    { name: "Hardik Pandya", score: 55 },
    { name: "Ravindra Jadeja", score: 88 },
    { name: "Axar Patel", score: 60 },
    { name: "R Ashwin", score: 68 },
    { name: "Mohammed Shami", score: 40 },
    { name: "Jasprit Bumrah", score: 77 },
  ];

  // Filter players with score below 70
  const lowScoringPlayers = players.filter(player => player.score < 70);

  return (
    <div>
      <h2>All Players</h2>
      <ul>
        {players.map((player, index) => (
          <li key={index}>{player.name} - Score: {player.score}</li>
        ))}
      </ul>

      <h2>Players with Score below 70</h2>
      <ul>
        {lowScoringPlayers.map((player, index) => (
          <li key={index}>{player.name} - Score: {player.score}</li>
        ))}
      </ul>
    </div>
  );
};

export default ListofPlayers;