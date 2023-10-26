import { useRecoilValue } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import api from "../api/api";

export const CommentModal = ({ handleClose, Post }) => {
  console.log("Post", Post)
  const account = useRecoilValue(accountAtom);

  const submit = async () => {
    const comment = document.querySelector(`input#comment`).value;
    if (comment?.length>0) {
      const result = await api.uploadComment(
        comment,
        Post.postId,
        account.accountId,
        
      );
      console.log(result);
      handleClose();
    }
  };
  return (
    <>
      {Post ? (
        <div className="bg-neutral-900 text-white h-4/5 overflow-y-scroll">
          <div className="mb-5">
            <div className="font-medium mb-3">
            {account.username}
            </div>
            <div className="flex justify-between pr-5">
            <input id="comment"
              className="p-2 rounded-full w-2/3 bg-neutral-700"
              placeholder={`what's your thought ${account.username}`}
            />
            <button onClick={submit} className="p-2 rounded-2xl bg-blue-600">
              Comment
            </button>
            </div>
          </div>
          <div>
            {Post.postComments.map((comment) => (
              <>
                <div>
                  <div>{comment.account.username}</div>
                  {comment.content}
                </div>
              </>
            ))}
          </div>
        </div>
      ) : (
        <></>
      )}
    </>
  );
};
