import { Outlet } from "react-router-dom"
import Navbar from "../components/Navbar"
import Footer from "../components/Footer"


const PageLayout = () => {
    
    return <>
    <div className="bg-neutral-900 min-h-screen">
    <Navbar />
    <Outlet />
    <Footer />
    </div>
    </>
}

export default PageLayout