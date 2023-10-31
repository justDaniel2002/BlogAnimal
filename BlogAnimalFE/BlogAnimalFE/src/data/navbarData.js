import ArtTrackIcon from "@mui/icons-material/ArtTrack";
import ArticleIcon from "@mui/icons-material/Article";
import SupervisorAccountIcon from "@mui/icons-material/SupervisorAccount";
import BallotIcon from "@mui/icons-material/Ballot";

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
]

export const staffNavbarData = [
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
]