import api from "../../api/api"

export const postListAction = async (Title, Images, Content, AccountId) => {
    const result = await api.createPost({Title, Content, AccountId})
    if (result?.postId){
        const uploadResult = await api.uploadPostImage(Images, result?.postId)
        console.log(uploadResult)
    }
    
    return result
}