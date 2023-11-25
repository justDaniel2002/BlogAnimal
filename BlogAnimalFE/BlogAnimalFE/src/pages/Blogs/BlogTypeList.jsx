import { useEffect, useState } from "react";
import api from "../../api/api";
import { Link } from "react-router-dom";
import { useRecoilValue } from "recoil";
import { backgroundState } from "../../atom/accountAtom";

const BlogTypeList = () => {
  const bg = useRecoilValue(backgroundState)
  const [blogTypes, setBlogTypes] = useState([]);
  useEffect(() => {
    const CallBack = async () => {
      const getBlogTypes = await api.getAllBlogType();
      setBlogTypes(getBlogTypes);
    };
    CallBack();
  }, []);
  return (
    <>
      <div className="mt-20 px-20 flex flex-wrap">
        {blogTypes.map((type) => (
          <Link
            to={`/BlogType/${type.typeId}`}
            className={`w-1/4 rounded-2xl ${bg=="dark"?"bg-neutral-700":"bg-white border"} mr-10`}
          >
            <div className={`${bg=="dark"?"text-white":"text-black"} text-3xl my-2 mx-5 font-serif font-medium`}>
              {type.typeName}
            </div>
            <img className="w-full" src={type.image} />
          </Link>
        ))}
      </div>
    </>
  );
};

export default BlogTypeList;
