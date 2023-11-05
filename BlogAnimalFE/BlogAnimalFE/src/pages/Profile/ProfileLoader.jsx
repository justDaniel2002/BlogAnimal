import api from "../../api/api"

export const profileLoader = async ({params}) => {
    const profile = await api.getAccountById(params.accountId)
    return profile
}