import api from "../../api/api"

export const postBlogAction = async (data) => {
    const result = await api.createBlog(data)
    return result
}

export const editBlogAction = async (data) => {
    const result = await api.editBlog(data)
    return result
}