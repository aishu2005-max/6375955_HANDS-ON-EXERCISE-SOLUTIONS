import React from 'react';

function BlogDetails({ show }) {
  return (
    <>
      {show && (
        <div style={styles.section}>
          <h2>Blog Details</h2>
          <h3>React Learning</h3>
          <p><strong>Stephen Biz</strong></p>
          <p>Welcome to learning React!</p>
          <h3>Installation</h3>
          <p><strong>Schewzdenier</strong></p>
          <p>You can install React from npm.</p>
        </div>
      )}
    </>
  );
}

const styles = {
  section: {
    padding: '10px',
  },
};

export default BlogDetails;