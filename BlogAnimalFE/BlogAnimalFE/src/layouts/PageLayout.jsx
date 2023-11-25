import { Outlet } from "react-router-dom"
import Navbar from "../components/Navbar"
import Footer from "../components/Footer"
import { backgroundState } from "../atom/accountAtom"
import { useRecoilValue } from "recoil"


const PageLayout = () => {
    const bg = useRecoilValue(backgroundState)
    return <>
    <div className={`${bg=="dark"?"bg-neutral-900":"bg-white"} min-h-screen transition-all delay-100`}>
    <Navbar />
    <Outlet />
    <Footer />
    </div>
    </>
}

export default PageLayout