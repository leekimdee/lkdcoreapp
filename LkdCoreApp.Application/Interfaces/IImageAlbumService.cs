using LkdCoreApp.Application.ViewModels;
using LkdCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;

namespace LkdCoreApp.Application.Interfaces
{
    public interface IImageAlbumService : IDisposable
    {
        ImageAlbumViewModel Add(ImageAlbumViewModel imageAlbumVm);

        void Update(ImageAlbumViewModel imageAlbumVm);

        void Delete(int id);

        List<ImageAlbumViewModel> GetAll();

        List<ImageAlbumViewModel> GetAll(string keyword);

        PagedResult<ImageAlbumViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ImageAlbumViewModel GetById(int id);

        ImageAlbumViewModel GetByIdWithIncludeObject(int id);

        void ReOrder(int sourceId, int targetId);

        void Save();
    }
}