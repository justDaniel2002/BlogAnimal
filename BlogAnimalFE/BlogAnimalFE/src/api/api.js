import axios from "axios";

const getAllPost = async () => {
  const res = await axios.get(`https://localhost:7252/api/Post`).catch((err) => console.log(err));
  console.log(res)
  return res.data;
};

const getBlogById = async (blogid) => {
  const res = await axios.get(`https://localhost:7252/api/Blog/${blogid}`).catch((err) => console.log(err));
  console.log(res)
  return res.data;
};

const getAllBlog = async () => {
  const res = await axios.get(`https://localhost:7252/api/Blog`).catch((err) => console.log(err));
  console.log(res)
  return res.data;
};

const getAllBlogType = async () => {
  const res = await axios.get(`https://localhost:7252/api/Blog/getBlogType`).catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const getAllBlogByType = async (typeid) => {
  const res = await axios.get(`https://localhost:7252/api/Blog/getBlogByType/${typeid}`).catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const createPost = async (data) => {
  const res = await axios.post(`https://localhost:7252/api/Post`, data).catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const api = {getAllPost, getAllBlog, getAllBlogType, getAllBlogByType, getBlogById, createPost}

export default api
