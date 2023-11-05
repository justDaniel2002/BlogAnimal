import api from "../../api/api"

export const searchPageLoader = async({params}) => {
    const posts = await api.searchPost(params.search)
    const blogs = await api.searchBlog(params.search)
    return {posts, blogs}
}