import { useRecoilValue } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import ArtTrackIcon from "@mui/icons-material/ArtTrack";
import ArticleIcon from "@mui/icons-material/Article";
import SupervisorAccountIcon from "@mui/icons-material/SupervisorAccount";
import Logo from "../assets/logo.png";

const Navbar = () => {
  const account = useRecoilValue(accountAtom);

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
          <ArtTrackIcon sx={{fontSize: "50px"}} className="text-white mr-5" />
          <ArticleIcon sx={{fontSize: "50px"}} />
          {account && account.RoleId == 1 ? <SupervisorAccountIcon /> : ""}
        </div>
        <div className="flex items-center">
          {account !== undefined ? (
            <>{account?.name}</>
          ) : (
            <div className="flex">
              <button className="bg-blue-800 text-white font-medium p-2 rounded-2xl mr-3">
                Đăng Kí
              </button>
              <button className="bg-blue-800 text-white font-medium p-2 rounded-2xl">
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
