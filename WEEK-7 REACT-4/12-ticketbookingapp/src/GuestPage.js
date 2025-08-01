import React from 'react';
import FlightDetails from './FlightDetails';

function GuestPage({ onLogin }) {
  return (
    <div style={{ textAlign: 'center' }}>
      <h1>Please sign up.</h1>
      <button onClick={onLogin}>Login</button>
      <FlightDetails isUser={false} />
    </div>
  );
}

export default GuestPage;