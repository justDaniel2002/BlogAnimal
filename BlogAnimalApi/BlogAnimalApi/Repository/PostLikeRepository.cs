using BlogAnimalApi.Entity;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class PostLikeRepository : Repository<PostLike>
    {
        public PostLikeRepository(BlogAnimalContext _context) : base(_context)
        {
        }

        public async Task<PostLike> getPostLikeByAccAndPost(string postId, string accId)
        {
            PostLike postLike = await context.PostLikes.FirstOrDefaultAsync(like => like.AccountId.Equals(accId) 
                                                                                        && like.PostId.Equals(postId));
            return postLike;
        }
    }
}
