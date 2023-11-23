import * as React from "react";
import Paper from "@mui/material/Paper";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TablePagination from "@mui/material/TablePagination";
import TableRow from "@mui/material/TableRow";
import { useLoaderData } from "react-router-dom";
import { CreateBlogModal } from "../../../components/Modals/CreateBlogModal";
import { useState } from "react";
import { Box, Modal } from "@mui/material";
import {
  createPostImagemodalStyle,
  createPostmodalStyle,
} from "../../../style/style";
import api from "../../../api/api";

const columns = [
  { id: "postId", label: "Post #", minWidth: 170 },
  { id: "title", label: "Title", minWidth: 100 },
  {
    id: "username",
    label: "CreatedBy",
    minWidth: 170,
    align: "right",
  },
  {
    id: "createdDate",
    label: "CreatedDate",
    minWidth: 170,
    align: "right",
  },
  {
    id: "action",
    label: "Action",
    minWidth: 170,
    align: "right",
  },
];

// function createData(name, code, population, size) {
//   const density = population / size;
//   return { blogId:name, title:code, population, size, density };
// }

export const PostManager = () => {
  const loaderPosts = useLoaderData();
  const [Posts, setPosts] = useState(loaderPosts);
  const [ModalBlog, setModalBlog] = useState();
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = async () => {
    setOpen(false);
    const blogs = await api.getAllBlog();
    setBlogs(blogs);
  };

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

  const rows = Posts.map((post) => {
    return {
      postId: post.postId,
      title: post.title,
      username: post?.account?.username,
      createdDate: post.createdDate,
      action: (
        <>
          <div className="flex flex-col">
            <div>
              <button
                onClick={async () => {
                  await api.deletePost(post.postId);
                  const posts = await api.getAllPost();
                  setPosts(posts);
                }}
                className="p-2 w-20 mb-1 bg-red-500 rounded-xl text-white"
              >
                Xóa
              </button>
            </div>
            {post.isSecure ? (
              <div>
                <button className="p-2 w-20 mb-1 bg-green-500 rounded-xl text-white">
                  Đã duyệt
                </button>
              </div>
            ) : (
              <div>
                <button
                  onClick={async () => {
                    await api.securePost(post.postId);
                    const posts = await api.getAllPost();
                    setPosts(posts);
                  }}
                  className="p-2 w-20 mb-1 bg-blue-500 rounded-xl text-white"
                >
                  Duyệt
                </button>
              </div>
            )}
          </div>
        </>
      ),
    };
  });

  return (
    <div className="px-20 mt-20 py-20">
      {/* <button
        onClick={() => {
          setModalBlog(undefined);
          handleOpen();
        }}
        className="p-2 mb-5 bg-blue-500 rounded-xl text-white"
      >
        Tạo Blog
      </button> */}
      <Paper sx={{ width: "100%", overflow: "hidden" }}>
        <TableContainer sx={{ maxHeight: 440 }}>
          <Table stickyHeader aria-label="sticky table">
            <TableHead>
              <TableRow>
                {columns.map((column) => (
                  <TableCell
                    key={column.id}
                    align={column.align}
                    style={{
                      minWidth: column.minWidth,
                      backgroundColor: "#303030",
                      color: "white",
                    }}
                  >
                    {column.label}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
            <TableBody>
              {Posts
                ? rows
                    ?.slice(
                      page * rowsPerPage,
                      page * rowsPerPage + rowsPerPage
                    )
                    .map((row) => {
                      return (
                        <TableRow
                          hover
                          role="checkbox"
                          tabIndex={-1}
                          key={row.code}
                        >
                          {columns.map((column) => {
                            const value = row[column.id];
                            return (
                              <TableCell
                                style={{
                                  backgroundColor: "#303030",
                                  color: "white",
                                }}
                                key={column.id}
                                align={column.align}
                              >
                                {column.format && typeof value === "number"
                                  ? column.format(value)
                                  : value}
                              </TableCell>
                            );
                          })}
                        </TableRow>
                      );
                    })
                : ""}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          sx={{
            width: "100%",
            overflow: "hidden",
            backgroundColor: "#303030",
            color: "white",
          }}
          rowsPerPageOptions={[10, 25, 100]}
          component="div"
          count={rows.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>

      {/* modal */}
      {/* <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={createPostImagemodalStyle}>
          <CreateBlogModal handleClose={handleClose} blog={ModalBlog} />
        </Box>
      </Modal> */}
    </div>
  );
};
