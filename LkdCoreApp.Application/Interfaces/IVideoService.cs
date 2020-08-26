using LkdCoreApp.Application.ViewModels;
using System.Collections.Generic;

namespace LkdCoreApp.Application.Interfaces
{
    public interface IVideoService
    {
        VideoViewModel Add(VideoViewModel videoVm);

        void Update(VideoViewModel videoVm);

        void Delete(int id);

        List<VideoViewModel> GetAll();

        List<VideoViewModel> GetAll(string keyword);

        VideoViewModel GetById(int id);

        void Save();
    }
}