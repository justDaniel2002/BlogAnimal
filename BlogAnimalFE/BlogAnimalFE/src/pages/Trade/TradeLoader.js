import api from "../../api/api"

const tradeLoader = async () => {
    const result = await api.getAllTradePost();
    console.log(result)
    return result
}

export default tradeLoader