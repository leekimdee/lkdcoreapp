using LkdCoreApp.Application.ViewModels;
using System.Collections.Generic;

namespace LkdCoreApp.Application.Interfaces
{
    public interface IImageService
    {
        ImageViewModel Add(ImageViewModel imageVm);

        void Update(ImageViewModel imageVm);

        void Delete(int id);

        List<ImageViewModel> GetAll();

        List<ImageViewModel> GetAll(string keyword);

        ImageViewModel GetById(int id);

        void Save();
    }
}