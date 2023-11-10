import { useState } from "react";
import ReactQuill from "react-quill";
import { useCallback, useEffect } from "react";
import { useDropzone } from "react-dropzone";
import { Button } from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import fileToBase64 from "../../utils/util";
import { PhotoArrage } from "../PhotoArrage";
import { useRecoilValue } from "recoil";
import { accountAtom } from "../../atom/accountAtom";
import { toast } from "react-toastify";
import { postListAction } from "../../pages/Posts/PostListAction";
import api from "../../api/api";

export const CreatePostModal = ({ handleClose }) => {
  const account = useRecoilValue(accountAtom);
  const [title, setTitle] = useState("");
  const [files, setFiles] = useState([]);
  const [filesBase64, setFilesBase64] = useState([]);
  const [content, setContent] = useState("Content");

  const customnToolBar = [
    [{ header: "1" }, { header: "2" }, "bold", "italic", "underline"],
    [{ list: "ordered" }, { list: "bullet" }],
    ["link", "image", "blockquote"],
    ["clean"],
  ];

  const onSubmit = async () => {
    if (title.length === 0 || content.length === 0 || files.length == 0) {
      toast("Values are empty", { type: toast.TYPE.WARNING });
    } else {
      const result = await postListAction(
        title,
        files,
        content,
        account.accountId
      );
      console.log(result);
      handleClose();
    }
  };

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
    },
  });

  const removeFile = (index) => {
    const updatedFiles = [...files.slice(0, index), ...files.slice(index + 1)];
    setFiles(updatedFiles);
    const updateFilesBase64 = [
      ...filesBase64.slice(0, index),
      ...filesBase64.slice(index + 1),
    ];
    setFilesBase64(updateFilesBase64);
  };

  return (
    <>
      <div className="text-white bg-neutral-900 max-h-screen overflow-y-scroll">
        <div className="text-center text-3xl mb-5 font-bold">Create Post</div>
        <div className="text-right">
          <button
            onClick={onSubmit}
            className="p-2 px-5 mb-5 font-medium rounded-xl bg-blue-600"
          >
            Post
          </button>
        </div>
        <div className=" bg-neutral-800 h-1"></div>
        <input
          className="w-full p-3 bg-neutral-800 rounded-2xl mt-5"
          placeholder="Title"
          value={title}
          onChange={(event) => setTitle(event.target.value)}
        />
        <ReactQuill
          theme="snow"
          modules={{ toolbar: customnToolBar }}
          value={content}
          onChange={(content) => setContent(content)}
          className="rounded-lg mt-5 mb-3 w-full px-5 py-2 border text-black border-neutral-200 bg-neutral-100"
        />
        <div
          className="rounded-lg px-5 py-2 border-2 text-neutral-400 border-dashed border-neutral-300 bg-neutral-100"
          {...getRootProps()}
        >
          <input {...getInputProps()} />
          {isDragActive ? (
            <div className="h-60">Drop the files here ...</div>
          ) : files?.length === 0 ? (
            <p>
              Drag / drop some files here, or click to select files for Artifact
              Image
            </p>
          ) : (
            <>
              <h3>Selected Files:</h3>
              <ul>
                {files?.map((file, index) => (
                  <>
                    <li key={index}>
                      <span className="m-1">{file.name}</span>
                      <Button
                        variant="outlined"
                        color="error"
                        startIcon={<DeleteIcon />}
                        onClick={() => removeFile(index)}
                      >
                        Remove
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

export const CreateTradeModal = ({ handleClose }) => {
  const account = useRecoilValue(accountAtom);
  const [content, setContent] = useState("Content");

  const customnToolBar = [
    [{ header: "1" }, { header: "2" }, "bold", "italic", "underline"],
    [{ list: "ordered" }, { list: "bullet" }],
    ["link", "image", "blockquote"],
    ["clean"],
  ];

  const onSubmit = async () => {
    if (content.length === 0) {
      toast("Values are empty", { type: toast.TYPE.WARNING });
    } else {
      const result = await api.uploadTrade({
        content,
        accountId: account.accountId,
      });
      console.log(result);
      handleClose();
    }
  };

  return (
    <>
      <div className="text-white bg-neutral-900 max-h-screen overflow-y-scroll">
        <div className="text-center text-3xl mb-5 font-bold">
          Create Trade Post
        </div>
        <div className="text-right">
          <button
            onClick={onSubmit}
            className="p-2 px-5 mb-5 font-medium rounded-xl bg-blue-600"
          >
            Post
          </button>
        </div>
        <div className=" bg-neutral-800 h-1"></div>
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
