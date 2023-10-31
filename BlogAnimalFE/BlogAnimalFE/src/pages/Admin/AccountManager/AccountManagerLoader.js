import api from "../../../api/api"

export const accountManagerLoader = async () => {
    const result = await api.getAllAccounts()
    return result
}