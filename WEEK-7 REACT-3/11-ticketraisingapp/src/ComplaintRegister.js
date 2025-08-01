import React, { useState } from 'react';

function ComplaintRegister() {
  const [name, setName] = useState('');
  const [complaint, setComplaint] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (name.trim() === '' || complaint.trim() === '') {
      alert('Please enter both name and complaint.');
      return;
    }
    const transactionId = Math.floor(Math.random() * 100); // Just a 2-digit random number
    alert(
      'Thanks ${name}\nYour Complaint was Submitted.\nTransaction ID is: ${transactionId}'
    );
    setName('');
    setComplaint('');
  };

  return (
    <div style={{ textAlign: 'center', marginTop: '50px' }}>
      <h1 style={{ color: 'red' }}>Register your complaints here!!!</h1>
      <form onSubmit={handleSubmit}>
        <table style={{ margin: '0 auto' }}>
          <tbody>
            <tr>
              <td style={{ padding: '10px' }}><label>Name:</label></td>
              <td><input type="text" value={name} onChange={(e) => setName(e.target.value)} /></td>
            </tr>
            <tr>
              <td style={{ padding: '10px' }}><label>Complaint:</label></td>
              <td>
                <textarea value={complaint} onChange={(e) => setComplaint(e.target.value)} />
              </td>
            </tr>
            <tr>
              <td colSpan="2" style={{ textAlign: 'center', paddingTop: '10px' }}>
                <button type="submit">Submit</button>
              </td>
            </tr>
          </tbody>
        </table>
      </form>
    </div>
  );
}

export default ComplaintRegister;