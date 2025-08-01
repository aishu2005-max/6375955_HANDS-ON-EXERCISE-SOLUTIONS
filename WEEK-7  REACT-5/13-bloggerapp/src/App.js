import React, { useState } from 'react';
import CourseDetails from './CourseDetails';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';

function App() {
  const [showCourses, setShowCourses] = useState(true);
  const [showBooks, setShowBooks] = useState(true);
  const [showBlogs, setShowBlogs] = useState(true);

  return (
    <div style={styles.container}>
      {/* Buttons to toggle each section */}
      <div style={{ textAlign: 'center', marginBottom: '20px' }}>
        <button onClick={() => setShowCourses(!showCourses)}>Toggle Courses</button>
        <button onClick={() => setShowBooks(!showBooks)}>Toggle Books</button>
        <button onClick={() => setShowBlogs(!showBlogs)}>Toggle Blogs</button>
      </div>

      <div style={styles.row}>
        {/* if statement inside CourseDetails */}
        <CourseDetails show={showCourses} />

        {/* Ternary rendering */}
        <BookDetails show={showBooks} />

        {/* Logical AND rendering */}
        <BlogDetails show={showBlogs} />
      </div>
    </div>
  );
}

const styles = {
  container: {
    fontFamily: 'Arial',
    padding: '20px',
  },
  row: {
    display: 'flex',
    justifyContent: 'space-around',
    alignItems: 'flex-start',
  },
};

export default App;