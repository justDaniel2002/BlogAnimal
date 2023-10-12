import { lazy, Suspense } from "react";
import {
  createBrowserRouter,
  createRoutesFromChildren,
  Route,
  RouterProvider
} from "react-router-dom";
import PageLayout from "./layouts/PageLayout";
import PostList from "./pages/Posts/PostList";
import postListLoader from "./pages/Posts/PostListLoader";
import "./App.css"
import PostListPage from "./pages/Posts/page";

const LazyPostList = lazy(() => import('./pages/Posts/PostList'))

function App() {
  const router = createBrowserRouter(
    createRoutesFromChildren(
      <Route errorElement={<h1>Error</h1>}>
        <Route path="/" element={<PageLayout />}>
          <Route index element={<Suspense fallback={<h1 className="text-white">Loading...</h1>}><LazyPostList /></Suspense>}/>
          {/* <Route index element={<PostList />}/> */}
        </Route>
      </Route>
    ),
    { basename: "" }
  );
  return <>
  <RouterProvider router={router} fallbackElement={<h1>Loading...</h1>}/>
  </>;
}

export default App;
