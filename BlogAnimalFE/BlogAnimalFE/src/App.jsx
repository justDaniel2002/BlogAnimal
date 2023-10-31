import { lazy, Suspense } from "react";
import {
  createBrowserRouter,
  createRoutesFromChildren,
  Route,
  RouterProvider,
} from "react-router-dom";
import PageLayout from "./layouts/PageLayout";
import "./App.css";
import "react-quill/dist/quill.snow.css";
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';
import BlogTypeList from "./pages/Blogs/BlogTypeList";
import PostList from "./pages/Posts/PostList";
import BlogDetail from "./pages/Blogs/BlogDetail/BlogDetail";
import SignInPage from "./pages/Auth/SignInPage";
import AuthAction from "./pages/Auth/AuthAction";
import { BlogManager } from "./pages/Admin/BlogManager/BlogManager";
import { blogManagerLoader } from "./pages/Admin/BlogManager/BlogManagerLoader";
import { AccountManager } from "./pages/Admin/AccountManager/AccountManager";
import { accountManagerLoader } from "./pages/Admin/AccountManager/AccountManagerLoader";

const LazyPostList = lazy(() => import("./pages/Posts/PostList"));
const LazyBlogList = lazy(() => import("./pages/Blogs/BlogList"));

function App() {
  const router = createBrowserRouter(
    createRoutesFromChildren(
      <Route errorElement={<h1>Error</h1>}>
        <Route path="/SignIn" element={<SignInPage />} action={AuthAction}/>
        <Route path="/" element={<PageLayout />}>
          <Route path="Blog/:id" element={<BlogDetail />} />
          <Route path="BlogType" element={<BlogTypeList />} />
          <Route
            path="BlogType/:typeid"
            element={
              <Suspense fallback={<h1 className="text-white">Loading...</h1>}>
                <LazyBlogList />
              </Suspense>
            }
          />
          <Route
            index
            element={
              <Suspense fallback={<h1 className="text-white">Loading...</h1>}>
                <LazyPostList />
              </Suspense>
            }
          />
          {/* <Route index element={<PostList />}/> */}

          <Route path="BlogManager" element={<BlogManager />} loader={blogManagerLoader}/>
          <Route path="AccountManager" element={<AccountManager />} loader={accountManagerLoader}/>
        </Route>
      </Route>
    ),
    { basename: "" }
  );
  return (
    <>
      <RouterProvider router={router} fallbackElement={<h1>Loading...</h1>} />
      <ToastContainer />
    </>
  );
}

export default App;
