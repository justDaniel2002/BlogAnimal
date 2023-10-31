import api from "../../../api/api"

export const blogManagerLoader = async () => {
    const result = await api.getAllBlog()
    return result
}