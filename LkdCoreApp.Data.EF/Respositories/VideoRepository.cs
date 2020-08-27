using LkdCoreApp.Data.Entities;

namespace LkdCoreApp.Data.EF.Respositories
{
    public class VideoRepository : EFRepository<Video, int>
    {
        public VideoRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}