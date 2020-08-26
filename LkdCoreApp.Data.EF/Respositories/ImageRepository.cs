using LkdCoreApp.Data.Entities;

namespace LkdCoreApp.Data.EF.Respositories
{
    public class ImageRepository : EFRepository<Image, int>
    {
        private AppDbContext _context;

        public ImageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}