import { atom } from "recoil";
import { sessionExtension } from "../utils/sessionExtension";

export const accountAtom = atom({
    key: "account",
    default: sessionExtension.getTItem("account")
})

export const backgroundState = atom({
    key:"background",
    default: localStorage.getItem("background")??"dark"
})