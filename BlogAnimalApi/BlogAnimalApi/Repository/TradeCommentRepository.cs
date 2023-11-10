using BlogAnimalApi.Entity;
using BlogAnimalApi.Helper;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class TradeCommentRepository : Repository<TradeComment>
    {
        private readonly Util util;

        public TradeCommentRepository(BlogAnimalContext _context, Util _util) : base(_context)
        {
            util = _util;
        }
    }
}
