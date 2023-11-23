import api from "../../../api/api"

export const postManagerLoader = async () => {
    const result = await api.getAllPost()
    return result
}