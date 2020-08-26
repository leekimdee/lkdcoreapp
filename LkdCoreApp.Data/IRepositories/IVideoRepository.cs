using LkdCoreApp.Data.Entities;
using LkdCoreApp.Infrastructure.Interfaces;

namespace LkdCoreApp.Data.IRepositories
{
    public interface IVideoRepository : IRepository<Video, int>
    {
    }
}