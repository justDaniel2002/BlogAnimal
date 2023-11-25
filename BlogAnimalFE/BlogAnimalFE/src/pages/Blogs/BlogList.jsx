import { useEffect, useState } from "react";
import api from "../../api/api";
import { Link, useParams } from "react-router-dom";
import { useRecoilValue } from "recoil";
import { backgroundState } from "../../atom/accountAtom";

const BlogList = () => {
  const bg = useRecoilValue(backgroundState)
  const [blogs, setBlogs] = useState([]);
  const { typeid } = useParams();
  useEffect(() => {
    const CallBack = async () => {
      const getBlogs = await api.getAllBlogByType(typeid);
      setBlogs(getBlogs);
    };
    CallBack();
  }, []);
  return (
    <>
      <div className="mt-20 px-20 flex flex-wrap">
        {blogs.map((blog) => (
          <Link
            to={`/Blog/${blog.blogId}`}
            className={`w-1/3 h-60 rounded-2xl ${bg=="dark"?"bg-neutral-700 text-white":"bg-white text-black border"} mr-10 px-5 py-5`}
          >
            <div className="text-2xl my-5  font-serif font-medium">
              {blog.title}
            </div>
            <div className=" mr-5 h-1/3 overflow-hidden" dangerouslySetInnerHTML={{ __html: blog?.content }}></div>
            <span>...</span>
          </Link>
        ))}
      </div>
    </>
  );
};

export default BlogList;
