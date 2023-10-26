import { useRecoilValue } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import api from "../api/api";

export const CommentModal = ({ handleClose, Post }) => {
  const account = useRecoilValue(accountAtom);

  const submit = async () => {
    const comment = document.querySelector(`input`);
    if (comment) {
      const result = await api.uploadComment(
        comment,
        account.accountId,
        Post.postId
      );
      console.log(result);
      handleClose();
    }
  };
  return (
    <>
      {Post ? (
        <div className="bg-neutral-900 text-white">
          <div>
            {account.username}
            <input
              className="p-2 rounded-full bg-neutral-700"
              placeholder={`what's your thought ${account.username}`}
            />
            <button onClick={submit} className="p-2 rounded-2xl">
              Comment
            </button>
          </div>
          <div>
            {Post.postComments.map((comment) => (
              <>
                <div>
                  {comment.account.username}
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
