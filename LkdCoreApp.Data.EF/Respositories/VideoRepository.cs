using LkdCoreApp.Data.Entities;

namespace LkdCoreApp.Data.EF.Respositories
{
    public class VideoRepository : EFRepository<Video, int>
    {
        private AppDbContext _context;

        public VideoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}