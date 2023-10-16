import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import api from "../../../api/api";

const BlogDetail = () => {
    const [Blog, setBlog] = useState()
    const { id } = useParams();
     useEffect(() => {
        const CallBack = async() => {
            const blog = await api.getBlogById(id)
            setBlog(blog)
        }

        CallBack()
        
     }, [])

    return <>
    <div className="mt-20 px-20 mx-20 py-10 rounded-xl text-white bg-neutral-700">
        {console.log("blog", Blog)}
        <div className="text-center text-3xl mb-10">{Blog?.title}</div>
        <div className="text-xl font-light">{Blog?.content}</div>
    </div>
    </>
}

export default BlogDetail