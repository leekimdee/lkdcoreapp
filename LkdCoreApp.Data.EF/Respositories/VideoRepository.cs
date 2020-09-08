using LkdCoreApp.Data.Entities;
using LkdCoreApp.Data.IRepositories;

namespace LkdCoreApp.Data.EF.Respositories
{
    public class VideoRepository : EFRepository<Video, int>, IVideoRepository
    {
        public VideoRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}