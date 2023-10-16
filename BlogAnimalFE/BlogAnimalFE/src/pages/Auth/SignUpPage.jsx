import { Form } from "react-router-dom";

const SignUpModal = () => {
  return (
    <>
      <div className="p-5">
        <div className="font-bold text-3xl">Sign Up</div>
        <hr className="mt-10 mb-3" />
        <Form method="post">
          <input type="hidden" name="type" value={"signUp"} />
          <input
            name="username"
            required
            className="p-2 mb-3 w-full bg-sky-50"
            placeholder="user name"
          />
          <input
            name="email"
            required
            type="email"
            className="p-2 mb-3 w-full bg-sky-50"
            placeholder="email"
          />
          <input
            name="password"
            required
            type="password"
            className="p-2 mb-3 w-full bg-sky-50"
            placeholder="password"
          />
          <div className="mb-5 text-neutral-400">
            <input required type="checkbox" className="p-2 " /> By clicking sign
            up, you agree with our terms and services
          </div>
          <button className="font-medium w-1/3 py-3 text-white bg-lime-600">
            Sign Up
          </button>
        </Form>
      </div>
    </>
  );
};

export default SignUpModal;
