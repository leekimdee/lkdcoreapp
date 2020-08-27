using AutoMapper;
using AutoMapper.QueryableExtensions;
using LkdCoreApp.Application.Interfaces;
using LkdCoreApp.Application.ViewModels;
using LkdCoreApp.Data.Entities;
using LkdCoreApp.Data.IRepositories;
using LkdCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LkdCoreApp.Application.Implementations
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;
        private IUnitOfWork _unitOfWork;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        public ImageViewModel Add(ImageViewModel imageVm)
        {
            var image = Mapper.Map<ImageViewModel, Image>(imageVm);
            _imageRepository.Add(image);
            return imageVm;
        }

        public void Delete(int id)
        {
            _imageRepository.Remove(id);
        }

        public List<ImageViewModel> GetAll()
        {
            return _imageRepository.FindAll().OrderBy(x => x.Id)
                .ProjectTo<ImageViewModel>().ToList();
        }

        public List<ImageViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _imageRepository.FindAll(x => x.Title.Contains(keyword))
                    .OrderBy(x => x.Id).ProjectTo<ImageViewModel>().ToList();
            else
                return _imageRepository.FindAll().OrderBy(x => x.Id)
                    .ProjectTo<ImageViewModel>()
                    .ToList();
        }

        public ImageViewModel GetById(int id)
        {
            return Mapper.Map<Image, ImageViewModel>(_imageRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ImageViewModel imageVm)
        {
            throw new NotImplementedException();
        }
    }
}