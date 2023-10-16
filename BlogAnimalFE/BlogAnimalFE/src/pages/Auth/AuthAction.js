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
            return authApi.signIn(dataSignIn)
        case 'signUp':
            const dataSignUp = {
                email: formData.get('email'),
                hashPassword: formData.get('password'),
                username: formData.get('username'),
            }
            console.log("dataSignUp",dataSignUp);
            return authApi.signUp(dataSignUp)
    }
}

export default AuthAction