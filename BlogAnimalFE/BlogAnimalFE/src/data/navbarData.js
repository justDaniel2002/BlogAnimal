import ArtTrackIcon from "@mui/icons-material/ArtTrack";
import ArticleIcon from "@mui/icons-material/Article";
import SupervisorAccountIcon from "@mui/icons-material/SupervisorAccount";
import BallotIcon from "@mui/icons-material/Ballot";
import PostAddIcon from '@mui/icons-material/PostAdd';
import AddPhotoAlternateIcon from '@mui/icons-material/AddPhotoAlternate';

export const navbarData = [
    {
        icon: ArtTrackIcon,
        link:"/",
        alt:"http://localhost:5173/",
        forAdmin: false
    },
    {
        icon: ArticleIcon,
        link:"/BlogType",
        alt:"http://localhost:5173/BlogType",
        forAdmin: false
    },
    {
        icon: PostAddIcon,
        link:"/TradePost",
        alt:"http://localhost:5173/TradePost",
        forAdmin: false
    },
]

export const staffNavbarData = [
    {
        icon: BallotIcon,
        link:"/BlogManager",
        alt:"http://localhost:5173/BlogManager",
        forAdmin: false
    },
    
]

export const adminNavbarData = [
    {
        icon: SupervisorAccountIcon,
        link:"/AccountManager",
        alt:"http://localhost:5173/AccountManager",
        forAdmin: false
    },
    {
        icon: BallotIcon,
        link:"/BlogManager",
        alt:"http://localhost:5173/BlogManager",
        forAdmin: false
    },
    {
        icon:AddPhotoAlternateIcon,
        link:"/PostManager",
        alt:"http://localhost:5173/PostManager",
        forAdmin: false
    }
    
]