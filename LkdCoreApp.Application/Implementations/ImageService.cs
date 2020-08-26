using LkdCoreApp.Application.Interfaces;
using LkdCoreApp.Application.ViewModels;
using LkdCoreApp.Data.IRepositories;
using LkdCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace LkdCoreApp.Application.Implementations
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;
        private IUnitOfWork _unitOfWork;

        public ImageViewModel Add(ImageViewModel imageVm)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ImageViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public ImageViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ImageViewModel imageVm)
        {
            throw new NotImplementedException();
        }
    }
}