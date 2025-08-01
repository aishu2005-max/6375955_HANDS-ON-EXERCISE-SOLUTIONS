import React from 'react';

function BookDetails({ show }) {
  return (
    show ? (
      <div style={styles.section}>
        <h2>Book Details</h2>
        <p><strong>Master React</strong></p>
        <p>670</p>
        <p><strong>Deep Dive into Angular 11</strong></p>
        <p>800</p>
        <p><strong>Mongo Essentials</strong></p>
        <p>450</p>
      </div>
    ) : null
  );
}

const styles = {
  section: {
    padding: '10px',
    borderRight: '5px solid green',
  },
};

export default BookDetails;