import { useState } from "react";
import ReactQuill from "react-quill";
import { useCallback, useEffect } from "react";
import { useDropzone } from "react-dropzone";
import { Button } from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import fileToBase64, { convertDongToNumber, numberToVietnameseDong } from "../../utils/util";
import { PhotoArrage, PhotoArrageImgUrl } from "../PhotoArrage";
import { useRecoilValue } from "recoil";
import { accountAtom } from "../../atom/accountAtom";
import { toast } from "react-toastify";
import {
  postListAction,
  updatePostAction,
} from "../../pages/Posts/PostListAction";
import api from "../../api/api";
import { updateTradeAction } from "../../pages/Trade/TradeAction";

export const EditPostModal = ({ handleClose, post }) => {
  const account = useRecoilValue(accountAtom);
  const [title, setTitle] = useState(post.title);
  const [Urls, setURLs] = useState(post?.images?.split(","));
  const [files, setFiles] = useState([]);
  const [filesBase64, setFilesBase64] = useState([]);
  const [content, setContent] = useState(post.content);
  const onDrop = async (acceptedFiles) => {
    console.log(files);
    await setFiles([...files, acceptedFiles[0]]);
    await setFilesBase64([
      ...filesBase64,
      await fileToBase64(acceptedFiles[0]),
    ]);
  };
  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    onDrop,
    accept: {
      "image/png": [".png"],
      "image/jpg": [".jpg"],
      "image/jfif": [".jfif"],
    },
  });

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
      const result = await updatePostAction(
        {
          postId: post.postId,
          title,
          content,
          accountId: account.accountId,
          images: Urls?.join(","),
          isSecure: post?.isSecure ?? false,
          createdDate: post?.createdDate,
        },
        files
      );
      console.log(result);
      handleClose();
    }
  };

  const removeFile = (index) => {
    const updatedFiles = [...files.slice(0, index), ...files.slice(index + 1)];
    setFiles(updatedFiles);
    const updateFilesBase64 = [
      ...filesBase64.slice(0, index),
      ...filesBase64.slice(index + 1),
    ];
    setFilesBase64(updateFilesBase64);
  };

  const removeUrl = (index) => {
    console.log(index);
    const updatedUrls = [...Urls.slice(0, index), ...Urls.slice(index + 1)];
    setURLs(updatedUrls);
  };

  return (
    <>
      <div className="text-white bg-neutral-900 max-h-screen overflow-y-scroll">
        <div className="text-center text-3xl mb-5 font-bold">Edit Post</div>
        <div className="text-right">
          <button
            onClick={onSubmit}
            className="p-2 px-5 mb-5 font-medium rounded-xl bg-blue-600"
          >
            Edit
          </button>
        </div>
        <div className=" bg-neutral-800 h-1"></div>
        <label className="mt-5 mb-3 block">Tiêu đề</label>
        <input
          className="w-full p-3 bg-neutral-800 rounded-2xl"
          placeholder="Tiêu đề"
          value={title}
          onChange={(event) => setTitle(event.target.value)}
        />
        <label className="mt-5 mb-3 block">Nội dung</label>
        <ReactQuill
          theme="snow"
          modules={{ toolbar: customnToolBar }}
          value={content}
          onChange={(content) => setContent(content)}
          className="rounded-lg mb-3 w-full px-5 py-2 border text-black border-neutral-200 bg-neutral-100"
        />
        <label className="mt-5 mb-3 block">Hình ảnh cũ</label>
        <div className="rounded-lg px-5 py-2 border-2 text-neutral-400 border-dashed border-neutral-300 bg-neutral-100">
          <h3>Hình ảnh:</h3>
          <ul>
            {Urls?.slice(0, Urls.length - 1)?.map((url, index) => (
              <>
                <li key={index}>
                  <span className="m-1">{url}</span>
                  <Button
                    variant="outlined"
                    color="error"
                    startIcon={<DeleteIcon />}
                    onClick={() => removeUrl(index)}
                  >
                    Gỡ
                  </Button>
                </li>
              </>
            ))}
          </ul>
          {Urls?.length > 0 ? <PhotoArrageImgUrl urls={Urls} /> : ""}
        </div>
        <label className="mt-5 mb-3 block">Thêm Hình ảnh</label>
        <div
          className="rounded-lg px-5 py-2 border-2 text-neutral-400 border-dashed border-neutral-300 bg-neutral-100"
          {...getRootProps()}
        >
          <input {...getInputProps()} />
          {isDragActive ? (
            <div className="h-60">Thả ảnh ở đây ...</div>
          ) : files?.length === 0 ? (
            <p>
              Kéo/thả một số file vào đây, hoặc click chọn file cho Hình ảnh
            </p>
          ) : (
            <>
              <h3>Tệp đã chọn:</h3>
              <ul>
                {files?.map((file, index) => (
                  <>
                    <li key={index}>
                      <span className="m-1">{file?.name}</span>
                      <Button
                        variant="outlined"
                        color="error"
                        startIcon={<DeleteIcon />}
                        onClick={() => removeFile(index)}
                      >
                        Gỡ
                      </Button>
                    </li>
                  </>
                ))}
              </ul>
              <PhotoArrage base64Image={filesBase64} />
            </>
          )}
        </div>
      </div>
    </>
  );
};

export const EditTradeModal = ({ handleClose, post }) => {
  const account = useRecoilValue(accountAtom);
  const [title, setTitle] = useState(post.title);
  const [price, setPrice] = useState(post.price);
  const [content, setContent] = useState(post.content);

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
      const result = await updateTradeAction({
        tradeId: post.tradeId,
        title,
        content,
        accountId: account.accountId,
        price: convertDongToNumber(price),
        isTrade: post?.isTrade ?? false,
        isSecure: post?.isSecure ?? false,
        createdDate: post?.createdDate,
      });
      console.log(result);
      handleClose();
    }
  };

  return (
    <>
      <div className="text-white bg-neutral-900 max-h-screen overflow-y-scroll">
        <div className="text-center text-3xl mb-5 font-bold">
          Edit Trade Post
        </div>
        <div className="text-right">
          <button
            onClick={onSubmit}
            className="p-2 px-5 mb-5 font-medium rounded-xl bg-blue-600"
          >
            Edit
          </button>
        </div>
        <div className=" bg-neutral-800 h-1"></div>
        <label className="mt-5 mb-3 block">Tiêu đề</label>
        <input
          className="w-full p-3 bg-neutral-800 rounded-2xl"
          placeholder="Tiêu đề"
          value={title}
          onChange={(event) => setTitle(event.target.value)}
        />
        <label className="mt-5 mb-3 block">Giá</label>
        <input
          className="w-1/3 p-3 bg-neutral-800 rounded-2xl"
          placeholder="Price"
          value={price}
          onBlur={(event) => setPrice(numberToVietnameseDong(event.target.value))}
          onChange={(event) => setPrice(event.target.value)}
        />
        <label className="mt-5 mb-3 block">Nội dung</label>
        <ReactQuill
          theme="snow"
          modules={{ toolbar: customnToolBar }}
          value={content}
          onChange={(content) => setContent(content)}
          className="rounded-lg mb-3 w-full px-5 py-2 border text-black border-neutral-200 bg-neutral-100"
        />
      </div>
    </>
  );
};
