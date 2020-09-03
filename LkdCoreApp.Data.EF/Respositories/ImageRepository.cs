using LkdCoreApp.Data.Entities;
using LkdCoreApp.Data.IRepositories;

namespace LkdCoreApp.Data.EF.Respositories
{
    public class ImageRepository : EFRepository<Image, int>, IImageRepository
    {
        public ImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}