using LkdCoreApp.Data.Entities;
using LkdCoreApp.Data.IRepositories;

namespace LkdCoreApp.Data.EF.Respositories
{
    public class ImageAlbumRepository : EFRepository<ImageAlbum, int>, IImageAlbumRepository
    {
        public ImageAlbumRepository(AppDbContext context) : base(context)
        {
        }
    }
}