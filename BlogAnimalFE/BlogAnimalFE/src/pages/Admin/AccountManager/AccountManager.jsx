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
import api from "../../../api/api";
import { useState } from "react";
import { useEffect } from "react";
import { getAdminDashBoard } from "../../../utils/util";
import animalbg from "../../../assets/animalBg.png"

const columns = [
  { id: "accountId", label: "Account ID", minWidth: 170 },
  { id: "username", label: "Username", minWidth: 100 },
  {
    id: "email",
    label: "Email",
    minWidth: 170,
    align: "right",
  },
  {
    id: "role",
    label: "Role",
    minWidth: 170,
    align: "right",
  },
  {
    id: "isBanned",
    label: "Status",
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

export const AccountManager = () => {
  const loaderAccounts = useLoaderData();
  const [Accounts, setAccounts] = useState(loaderAccounts);
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(10);
  const [Nob, setNob] = useState();
  const [Nop, setNop] = useState();
  const [Noc, setNoc] = useState();
  const [Nou, setNou] = useState();
  const [Notp, setNotp] = useState();

  useEffect(() => {
    callback();
  }, []);

  const callback = async () => {
    const { gNob, gNop, gNou, gNoc, gNotp } = await getAdminDashBoard();
    setNob(gNob);
    setNop(gNop);
    setNoc(gNoc);
    setNou(gNou);
    setNotp(gNotp)
  };

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

  const banAccount = async (accountId) => {
    await api.banAccount(accountId);
    const accounts = await api.getAllAccounts();
    setAccounts(accounts);
  };

  const rows = Accounts.map((acc) => {
    return {
      accountId: acc.accountId,
      username: acc.username,
      email: acc.email,
      role: acc?.role?.roleName,
      isBanned: acc.isBanned ? (
        <span className="text-red-500">banned</span>
      ) : (
        <span className="text-green-400">activate</span>
      ),
      action: (
        <>
          <div className="flex flex-col">
            <div>
              {acc.isBanned ? (
                <button
                  onClick={() => banAccount(acc.accountId)}
                  className="p-2 w-20 mb-1 bg-green-400 rounded-xl text-white"
                >
                  UnBan
                </button>
              ) : (
                <button
                  onClick={() => banAccount(acc.accountId)}
                  className="p-2 w-20 mb-1 bg-red-500 rounded-xl text-white"
                >
                  Ban
                </button>
              )}
            </div>
            <div>
              <button className="p-2 w-20 mb-1 bg-blue-500 rounded-xl text-white">
                Info
              </button>
            </div>
          </div>
        </>
      ),
    };
  });

  return (
    <div className="px-20 mt-20 pb-20">
      <div className="flex mb-10 relative overflow-hidden">
        
        <div className="w-1/5 text-2xl font-serif rounded-lg text-white bg-red-500 mr-3 relative">
        <img
          class="opacity-30 absolute w-full h-auto"
          src={animalbg}
          alt=""
        />
          <div className="px-5 pt-5 pb-10">Posts: {Nop}</div>
        </div>
        <div className="w-1/5 text-2xl font-serif rounded-lg text-white bg-orange-500 mr-3 relative">
        <img
          class="opacity-30 -bottom-1 absolute w-full h-auto"
          src={animalbg}
          alt=""
        />
          <div className="px-5 pt-5 pb-10">TradePosts: {Notp}</div>
        </div>
        <div className="w-1/5 text-2xl font-serif rounded-lg text-white bg-green-500 mr-3 relative">
        <img
          class="opacity-30 absolute w-full h-auto"
          src={animalbg}
          alt=""
        />
           <div className="px-5 pt-5 pb-10">Blogs: {Nob}</div>
        </div>
        <div className="w-1/5 text-2xl font-serif rounded-lg text-white bg-yellow-500 mr-3 relative">
        <img
          class="opacity-30 -bottom-1 absolute w-full h-auto"
          src={animalbg}
          alt=""
        />
           <div className="px-5 pt-5 pb-10">Users: {Nou}</div>
        </div>
        <div className="w-1/5 text-2xl font-serif rounded-lg text-white bg-blue-500 mr-3 relative">
        <img
          class="opacity-30 absolute w-full h-auto"
          src={animalbg}
          alt=""
        />
           <div className="px-5 pt-5 pb-10">Comments: {Noc}</div>
        </div>
      </div>
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
              {Accounts
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
    </div>
  );
};
