import React from 'react';

function FlightDetails({ isUser }) {
  const flights = [
    { id: 1, from: 'New York', to: 'London', time: '10:00 AM' },
    { id: 2, from: 'Delhi', to: 'Dubai', time: '2:30 PM' },
    { id: 3, from: 'Tokyo', to: 'Sydney', time: '7:45 PM' },
  ];

  return (
    <div style={{ marginTop: '30px' }}>
      <h2>Available Flights</h2>
      <table border="1" style={{ margin: 'auto', padding: '10px' }}>
        <thead>
          <tr>
            <th>From</th>
            <th>To</th>
            <th>Time</th>
            {isUser && <th>Action</th>}
          </tr>
        </thead>
        <tbody>
          {flights.map((flight) => (
            <tr key={flight.id}>
              <td>{flight.from}</td>
              <td>{flight.to}</td>
              <td>{flight.time}</td>
              {isUser && (
                <td>
                  <button onClick={() => alert('Ticket booked for ${flight.from} to ${flight.to}')}>
                    Book Now
                  </button>
                </td>
              )}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default FlightDetails;