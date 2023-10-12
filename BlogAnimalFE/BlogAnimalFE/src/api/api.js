import axios from "axios";

const getAllPost = async () => {
  const res = await axios.get(`https://localhost:7252/api/Post`).catch((err) => console.log(err));
  console.log(res)
  return res.data;
};

const api = {getAllPost}

export default api
