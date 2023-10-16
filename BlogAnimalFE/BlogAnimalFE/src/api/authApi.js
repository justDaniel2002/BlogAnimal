import axios from "axios";

const signIn = async (data) => {
    const res = await axios.post(`https://localhost:7252/api/Authen/SignIn`, data)
    console.log(res)
    return res.data
}


const signUp = async (data) => {
    const res = await axios.post(`https://localhost:7252/api/Authen/SignUp`, data)
                            .catch(err => err)
    console.log(res)
    return true
}

const authApi = {signIn, signUp}

export default authApi
