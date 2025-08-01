import React from 'react';

function CourseDetails({ show }) {
  if (!show) return null; // Conditional rendering using 'if'
  
  return (
    <div style={styles.section}>
      <h2>Course Details</h2>
      <p><strong>Angular</strong></p>
      <p>4/5/2021</p>
      <p><strong>React</strong></p>
      <p>6/3/20201</p>
    </div>
  );
}

const styles = {
  section: {
    padding: '10px',
    borderRight: '5px solid green',
  },
};

export default CourseDetails;