using LkdCoreApp.Data.Entities;

namespace LkdCoreApp.Data.EF.Respositories
{
    public class ImageRepository : EFRepository<Image, int>
    {
        public ImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}