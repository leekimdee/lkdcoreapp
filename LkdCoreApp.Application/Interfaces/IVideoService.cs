using LkdCoreApp.Application.ViewModels;
using LkdCoreApp.Utilities.Dtos;
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

        PagedResult<VideoViewModel> GetAllPaging(string keyword, int page, int pageSize);

        VideoViewModel GetById(int id);

        void Save();
    }
}