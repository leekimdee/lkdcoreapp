using LkdCoreApp.Data.Entities;
using LkdCoreApp.Infrastructure.Interfaces;

namespace LkdCoreApp.Data.IRepositories
{
    public interface IImageRepository : IRepository<Image, int>
    {
    }
}