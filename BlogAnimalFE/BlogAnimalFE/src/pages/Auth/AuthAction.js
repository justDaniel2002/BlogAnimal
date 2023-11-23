import { toast } from "react-toastify";
import authApi from "../../api/authApi";

const AuthAction = async ({ params, request }) => {
    const formData = await request.formData();
    const type = await formData.get('type');
    console.log(type);

    switch(type) {
        case 'signin':
            const dataSignIn = {
                email: formData.get('email'),
                password: formData.get('password'),
            }
            console.log("dataSignIn",dataSignIn);
            return await authApi.signIn(dataSignIn)
        case 'signUp':
            const dataSignUp = {
                email: formData.get('email'),
                hashPassword: formData.get('password'),
                username: formData.get('username'),
            }
            console.log("dataSignUp",dataSignUp);
            try{
                await authApi.signUp(dataSignUp)
                toast("Đăng ký thành công", {type: toast.TYPE.SUCCESS})
            }catch(err){
                toast("Đăng ký thất bại", {type: toast.TYPE.ERROR})
            }
            return 
    }
}

export default AuthAction