using LkdCoreApp.Data.Entities;
using LkdCoreApp.Data.IRepositories;

namespace LkdCoreApp.Data.EF.Respositories
{
    public class ImageAlbumRepository : EFRepository<ImageAlbum, int>, IImageAlbumRepository
    {
        private AppDbContext _context;

        public ImageAlbumRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}