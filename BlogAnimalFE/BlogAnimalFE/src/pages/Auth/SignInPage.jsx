import { Form, Link, useActionData, useNavigate } from "react-router-dom";
import logo2 from "../../assets/logo3.png";
import Modal from "@mui/material/Modal";
import Box from "@mui/material/Box";
import { useEffect, useState } from "react";
import SignUpModal from "./SignUpPage";
import { useRecoilState } from "recoil";
import { accountAtom } from "../../atom/accountAtom";
import { signUpmodalStyle } from "../../style/style";
import { toast } from "react-toastify";
import { sessionExtension } from "../../utils/sessionExtension";

const SignInPage = () => {
  const [account, setAccount] = useRecoilState(accountAtom);
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const navigate = useNavigate();

  const actionData = useActionData();

  useEffect(() => {
    handleClose();
    if (actionData?.email) {
      sessionExtension.setTItem("account", actionData);
      setAccount(actionData);
      navigate("/");
    } else if (actionData == "Unauthenticated") {
      toast("Unauthenticated", { type: toast.TYPE.ERROR });
    }
  }, [actionData]);

  return (
    <>
      <div className="min-h-screen px-32 py-16 bg-slate-100">
        <div className="flex items-center">
          <div className="w-3/5">
            <img src={logo2} className="w-4/5" />
          </div>
          <div className="w-2/5">
            <div className="shadow-xl p-5 bg-white rounded-2xl text-center">
              <Form method="post">
                <input type="hidden" name="type" value={"signin"} />
                <input
                  required
                  name="email"
                  className="p-3 mb-3 w-full bg-sky-50"
                  placeholder="email or phone number"
                />
                <input
                  required
                  name="password"
                  className="p-3 mb-3 w-full bg-sky-50"
                  placeholder="password"
                  type="password"
                />
                <button
                  type="submit"
                  className="font-medium w-full py-3 mb-3 text-white bg-blue-500 rounded-lg"
                >
                  Log In
                </button>
                <Link to={"/ForgotPassword"} className="text-blue-500">
                  Forgotten password ?
                </Link>
                <hr className="my-5" />
              </Form>
              <button
                onClick={handleOpen}
                className="font-medium w-2/3 py-3 text-white bg-lime-600"
              >
                Create Your Account
              </button>
            </div>
          </div>
        </div>
      </div>

      {/* modal sign in  */}

      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={signUpmodalStyle}>
          <SignUpModal />
        </Box>
      </Modal>
    </>
  );
};

export default SignInPage;
