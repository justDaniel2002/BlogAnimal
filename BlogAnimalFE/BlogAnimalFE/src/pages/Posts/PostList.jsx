import { useEffect, useState } from "react";
import ThumbUpOffAltIcon from '@mui/icons-material/ThumbUpOffAlt';
import ChatBubbleOutlineIcon from '@mui/icons-material/ChatBubbleOutline';
import SendIcon from '@mui/icons-material/Send';
import api from "../../api/api";

const PostList = () => {
  //const posts = useLoaderData();
  const [posts, setPosts] = useState([])
  useEffect( () => {
    const CallBack = async() =>{
      const getPosts = await api.getAllPost()
      setPosts(getPosts)
  }
  CallBack()
  },[])
  return (
    <>
      <div className="text-white mt-32 mb-32">
        {posts?.map((post) => (
          <>
            <div
              key={post.postId}
              className="rounded-xl w-5/12 m-auto bg-neutral-800"
            >
              <div className="pt-3 mx-5">
                <div className="font-medium">{post?.account?.username}</div>
                <div className="font-light text-neutral-400">
                  {post?.createdDate}
                </div>
              </div>
              <div className="my-5 mx-5 pl-2">{post?.content}</div>
              <div className="bg-neutral-700 h-1 w-full" />
              <div className="flex justify-between text-neutral-400 mx-10 py-5">
                <div><ThumbUpOffAltIcon /> Thích</div>
                <div><ChatBubbleOutlineIcon /> Bình luận</div>
                <div><SendIcon /> Chia sẻ</div>
              </div>
            </div>
          </>
        ))}
      </div>
    </>
  );
};

export default PostList;
