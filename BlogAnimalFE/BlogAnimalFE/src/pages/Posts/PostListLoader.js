import api from "../../api/api"

const postListLoader = async () => {
    const result = await api.getAllPost();
    console.log(result)
    return result
}

export default postListLoader