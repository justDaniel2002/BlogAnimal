import { Form } from "react-router-dom";

const SignUpModal = () => {
  
  return (
    <>
      <div className="p-5">
        <div className="font-bold text-3xl">Đăng ký</div>
        <hr className="mt-10 mb-3" />
        <Form method="post">
          <input type="hidden" name="type" value={"signUp"} />
          <label>User name</label>
          <input
            name="username"
            required
            className="p-2 mb-3 w-full bg-sky-50"
            placeholder="user name"
          />
          <label>Email</label>
          <input
            name="email"
            required
            type="email"
            className="p-2 mb-3 w-full bg-sky-50"
            placeholder="email"
          />
          <label>Password</label>
          <input
            name="password"
            required
            type="password"
            className="p-2 mb-3 w-full bg-sky-50"
            placeholder="password"
          />
          <div className="mb-5 text-neutral-400">
            <input required type="checkbox" className="p-2 " /> Bằng cách nhấn vào dấu hiệu
            lên, bạn đồng ý với các điều khoản và dịch vụ của chúng tôi
          </div>
          <button className="font-medium w-1/3 py-3 text-white bg-lime-600">
            Đăng ký
          </button>
        </Form>
      </div>
    </>
  );
};

export default SignUpModal;
