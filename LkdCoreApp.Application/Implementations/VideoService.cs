using LkdCoreApp.Application.Interfaces;
using LkdCoreApp.Application.ViewModels;
using LkdCoreApp.Data.IRepositories;
using LkdCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace LkdCoreApp.Application.Implementations
{
    public class VideoService : IVideoService
    {
        private IVideoRepository _videoRepository;
        private IUnitOfWork _unitOfWork;

        public VideoViewModel Add(VideoViewModel videoVm)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<VideoViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<VideoViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public VideoViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(VideoViewModel videoVm)
        {
            throw new NotImplementedException();
        }
    }
}