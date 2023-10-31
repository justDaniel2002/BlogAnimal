import { useState } from "react";
import ReactQuill from "react-quill";
import {  useEffect } from "react";
import { useRecoilValue } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import { toast } from "react-toastify";
import { editBlogAction, postBlogAction } from "../pages/Blogs/PostBlogAction";
import api from "../api/api";

export const CreateBlogModal = ({ handleClose, blog }) => {
  const account = useRecoilValue(accountAtom);
  const [title, setTitle] = useState(blog?.title);
  const [content, setContent] = useState(blog?.content);
  const [blogType, setBlogType] = useState([]);

  useEffect(() => {
    const callback = async () => {
      const types = await api.getAllBlogType();
      setBlogType(types);
    };
    callback();
  }, []);

  const customnToolBar = [
    [{ header: "1" }, { header: "2" }, "bold", "italic", "underline"],
    [{ list: "ordered" }, { list: "bullet" }],
    ["link", "image", "blockquote"],
    ["clean"],
  ];

  const onSubmit = async () => {
    if (title.length === 0 || content.length === 0) {
      toast("Values are empty", { type: toast.TYPE.WARNING });
    } else {
      if (blog) {
        const result = await editBlogAction({
          blogId: blog.blogId,
          title,
          content,
          accountId: account.accountId,
          blogTypeId: document.querySelector('select[name="type"]').value,
          createdDate: blog.createdDate
        });
        console.log(result);
      } else {
        const result = await postBlogAction({
          title,
          content,
          accountId: account.accountId,
          blogTypeId: document.querySelector('select[name="type"]').value,
        });
        console.log(result);
      }

      handleClose();
    }
  };

  return (
    <>
      <div className="text-white bg-neutral-900 max-h-screen overflow-y-scroll">
        <div className="text-center text-3xl mb-5 font-bold">Create Blog</div>
        <div className="text-right">
          <button
            onClick={onSubmit}
            className="p-2 px-5 mb-5 font-medium rounded-xl bg-blue-600"
          >
            {blog ? "Edit" : "Post"}
          </button>
        </div>
        <div className=" bg-neutral-800 h-1"></div>

        <input
          className="w-full p-3 bg-neutral-800 rounded-2xl mt-5"
          placeholder="Title"
          value={title}
          onChange={(event) => setTitle(event.target.value)}
        />

        <select
          name="type"
          className="p-3 bg-neutral-800 rounded-2xl mt-5 w-1/3"
        >
          {blogType.map((type) => (
            <>
              {blog?.blogTypeId == type.typeId ? (
                <option selected value={type.typeId}>
                  {type.typeName}
                </option>
              ) : (
                <option value={type.typeId}>{type.typeName}</option>
              )}
            </>
          ))}
        </select>

        <ReactQuill
          theme="snow"
          modules={{ toolbar: customnToolBar }}
          value={content}
          onChange={(content) => setContent(content)}
          className="rounded-lg mt-5 mb-3 w-full px-5 py-2 border text-black border-neutral-200 bg-neutral-100"
        />
      </div>
    </>
  );
};
