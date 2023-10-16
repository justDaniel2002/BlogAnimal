import { useRecoilValue } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import ArtTrackIcon from "@mui/icons-material/ArtTrack";
import ArticleIcon from "@mui/icons-material/Article";
import SupervisorAccountIcon from "@mui/icons-material/SupervisorAccount";
import Logo from "../assets/logo.png";
import { navbarData } from "../data/navbarData";
import { Link, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";

const Navbar = () => {
  const account = useRecoilValue(accountAtom);
  const [currentURL, setCurrentURL] = useState(window.location.href);
  const navigate = useNavigate()

  return (
    <>
      <div className="flex justify-between items-center px-10 py-3 border border-neutral-700">
        <div className="flex items-center">
          <img style={{ width: "100px" }} src={Logo} className="mr-2" />
          <input
            placeholder="Tìm kiếm trên BlogAnimal"
            className="p-3 rounded-full bg-neutral-700 text-neutral-300"
          />
        </div>
        <div className="flex items-center text-neutral-500 w-1/3">
          {navbarData.map((data) => (
            <Link onClick={() => setCurrentURL(data.alt)} to={data.link}>
              {data.alt == currentURL ? (
                <data.icon
                  sx={{ fontSize: "50px" }}
                  className="text-white mr-5"
                />
              ) : (
                <data.icon sx={{ fontSize: "50px" }} className="mr-5" />
              )}
            </Link>
          ))}
          {account && account.RoleId == 1 ? <SupervisorAccountIcon /> : ""}
        </div>
        <div className="flex items-center">
          {account !== undefined ? (
            <><div className="text-white text-lg font-medium">{account?.username}</div></>
          ) : (
            <div className="flex">
              <button onClick={() => navigate("SignIn")} className="bg-blue-800 text-white font-medium p-2 rounded-2xl mr-3">
                Đăng Kí
              </button>
              <button onClick={() => navigate("SignIn")} className="bg-blue-800 text-white font-medium p-2 rounded-2xl">
                Đăng Nhập
              </button>
            </div>
          )}
        </div>
      </div>
    </>
  );
};

export default Navbar;
