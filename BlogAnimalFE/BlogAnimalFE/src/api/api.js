import axios from "axios";
import { convertFileListToBytes } from "../utils/util";

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

const uploadPostImage = async (Images, id) => {
  const formData = new FormData();
    
    for (let i = 0; i < Images.length; i++) {
      formData.append('files', Images[i]);
    }

  const res = await axios.post(`https://localhost:7252/api/Post/uploadImg/${id}`, formData, {
    headers: {
      'Content-Type': 'multipart/form-data'
    }
  }).catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const uploadComment = async (comment, postId, accId) => {
  const res = await axios.post(`https://localhost:7252/api/Post/uploadComment/${postId}/${accId}?comment=${comment}`)
  .catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const likePost = async ( postId, accId) => {
  const res = await axios.post(`https://localhost:7252/api/Post/likePost/${postId}/${accId}`)
  .catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const getAllAccounts = async () => {
  const res = await axios.get(`https://localhost:7252/api/Account/getAllAccount`)
  .catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const banAccount = async (accountId) => {
  const res = await axios.post(`https://localhost:7252/api/Account/banAccount/${accountId}`)
  .catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const createBlog = async (data) => {
  const res = await axios.post(`https://localhost:7252/api/Blog`,data)
  .catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const editBlog = async (data) => {
  const res = await axios.put(`https://localhost:7252/api/Blog`,data)
  .catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const deleteBlog = async (blogId) => {
  const res = await axios.delete(`https://localhost:7252/api/Blog/${blogId}`)
  .catch((err) => console.log(err));
  console.log(res)
  return res.data;
}

const api = {getAllPost, getAllBlog, getAllBlogType, getAllBlogByType, getBlogById, createPost, 
  uploadPostImage, uploadComment, likePost, getAllAccounts, banAccount, createBlog, editBlog, deleteBlog}

export default api
