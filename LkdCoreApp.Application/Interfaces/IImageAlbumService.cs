using LkdCoreApp.Application.ViewModels;
using System.Collections.Generic;

namespace LkdCoreApp.Application.Interfaces
{
    public interface IImageAlbumService
    {
        ImageAlbumViewModel Add(ImageAlbumViewModel imageAlbumVm);

        void Update(ImageAlbumViewModel imageAlbumVm);

        void Delete(int id);

        List<ImageAlbumViewModel> GetAll();

        List<ImageAlbumViewModel> GetAll(string keyword);

        ImageAlbumViewModel GetById(int id);

        void ReOrder(int sourceId, int targetId);

        void Save();
    }
}