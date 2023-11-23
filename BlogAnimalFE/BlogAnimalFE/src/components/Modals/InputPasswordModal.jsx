import { Form } from "react-router-dom";
import { toast } from "react-toastify";
import api from "../../api/api";

export const CheckPasswordModal = ({ handelClose, editProfile }) => {
  const checkPassword = async () => {
    const password = document.getElementById("ckpass").value;
    if (password.length > 0) {
      await editProfile(password);
      handelClose();
    } else {
      toast("you havent input anything", { type: toast.TYPE.WARNING });
    }
  };
  return (
    <>
      <div className="p-5 bg-neutral-800 text-neutral-400">
      <label className=" mb-3 block">Mật khẩu</label>
        <input
          id="ckpass"
          className="p-2 bg-neutral-600 rounded-full w-4/5 mr-3"
          placeholder="mật khẩu"
          type="password"
        />
        <button onClick={checkPassword}  className="p-2 text-white bg-blue-500 rounded-xl font-medium mt-5">
          Nhập
        </button>
      </div>
    </>
  );
};

export const InputPasswordModal = ({ handelClose, accountId }) => {
  const submitChangePass = async(event) => {
    event.preventDefault();
    const formData = new FormData(event.target);

    const formObject = {};
    formData.forEach((value, key) => {
      formObject[key] = value;
    });

    const result = await api.editPassword(formObject, accountId)

    if(result === "password incorrect") {
        toast(result, {type: toast.TYPE.ERROR})
    }
    else if(result === "succesfully"){
        toast("change password successfully", {type: toast.TYPE.SUCCESS})
        handelClose()
    }
    
  };
  return (
    <>
      <div className="p-5 bg-neutral-800 text-neutral-400">
        <Form onSubmit={submitChangePass} method="post">
        <label className="mb-3 block">Mật khẩu cũ</label>
          <input
            className="p-2 bg-neutral-600 rounded-full w-full mb-3"
            placeholder="mật khẩu cũ"
            name="oldpassword"
            type="password"
            required
          />
          <label className=" mb-3 block">Mật khẩu mới</label>
          <input
            className="p-2 bg-neutral-600 rounded-full w-full"
            placeholder="mật khẩu mới"
            name="newpassword"
            type="password"
            required
          />
          <button
            className="p-2 text-white bg-blue-500 rounded-xl font-medium mt-5"
          >
            Submit
          </button>
        </Form>
      </div>
    </>
  );
};
