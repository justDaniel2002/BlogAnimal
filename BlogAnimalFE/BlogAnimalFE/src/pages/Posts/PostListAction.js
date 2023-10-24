import api from "../../api/api"

export const postListAction = async (Title, Images, Content, AccountId) => {
    const result = await api.createPost({Title, Images, Content, AccountId})
    return result
}