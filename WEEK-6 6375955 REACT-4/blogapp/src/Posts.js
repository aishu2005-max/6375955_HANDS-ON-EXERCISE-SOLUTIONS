import React, { Component } from "react";
import Post from "./Post";

class Posts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
    };
  }

  // Method to load posts from API
  loadPosts = () => {
    fetch("https://jsonplaceholder.typicode.com/posts")
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to fetch posts");
        }
        return response.json();
      })
      .then((data) => {
        const postsList = data.map(
          (p) => new Post(p.userId, p.id, p.title, p.body)
        );
        this.setState({ posts: postsList });
      })
      .catch((error) => {
        console.error("Error fetching posts:", error);
      });
  };

  // Lifecycle method to call loadPosts
  componentDidMount() {
    this.loadPosts();
  }

  // Error handling
  componentDidCatch(error, info) {
    alert("An error occurred: " + error.toString());
  }

  render() {
    return (
      <div>
        <h1>Blog Posts</h1>
        {this.state.posts.map((post) => (
          <div key={post.id}>
            <h3>{post.title}</h3>
            <p>{post.body}</p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;