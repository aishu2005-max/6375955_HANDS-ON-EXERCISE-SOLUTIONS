import React from 'react';
import FlightDetails from './FlightDetails';

function UserPage({ onLogout }) {
  return (
    <div style={{ textAlign: 'center' }}>
      <h1>Welcome back</h1>
      <button onClick={onLogout}>Logout</button>
      <FlightDetails isUser={true} />
    </div>
  );
}

export default UserPage;