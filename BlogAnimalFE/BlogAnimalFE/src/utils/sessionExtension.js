
const setTItem = (key, value) => {
    const objectString = JSON.stringify(value);
    sessionStorage.setItem(key, objectString);
}

const getTItem = (key) => JSON.parse(sessionStorage.getItem(key));

export const sessionExtension = {setTItem, getTItem}