import api from "../../api/api"

export const tradeAction = async (data) => {
    const result = await api.createPost({Title, Content, AccountId})
    if (result?.postId){
        const uploadResult = await api.uploadTrade(data)
        console.log(uploadResult)
    }
    
    return result
}