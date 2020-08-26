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
    public class ImageAlbumService : IImageAlbumService
    {
        private IImageAlbumRepository _imageAlbumRepository;
        private IUnitOfWork _unitOfWork;

        public ImageAlbumService(IImageAlbumRepository imageAlbumRepository, IUnitOfWork unitOfWork)
        {
            _imageAlbumRepository = imageAlbumRepository;
            _unitOfWork = unitOfWork;
        }

        public ImageAlbumViewModel Add(ImageAlbumViewModel imageAlbumVm)
        {
            var imageAlbum = Mapper.Map<ImageAlbumViewModel, ImageAlbum>(imageAlbumVm);
            _imageAlbumRepository.Add(imageAlbum);
            return imageAlbumVm;
        }

        public void Delete(int id)
        {
            _imageAlbumRepository.Remove(id);
        }

        public List<ImageAlbumViewModel> GetAll()
        {
            return _imageAlbumRepository.FindAll().OrderBy(x => x.Id)
                .ProjectTo<ImageAlbumViewModel>().ToList();
        }

        public List<ImageAlbumViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _imageAlbumRepository.FindAll(x => x.Title.Contains(keyword))
                    .OrderBy(x => x.Id).ProjectTo<ImageAlbumViewModel>().ToList();
            else
                return _imageAlbumRepository.FindAll().OrderBy(x => x.Id)
                    .ProjectTo<ImageAlbumViewModel>()
                    .ToList();
        }

        public ImageAlbumViewModel GetById(int id)
        {
            return Mapper.Map<ImageAlbum, ImageAlbumViewModel>(_imageAlbumRepository.FindById(id));
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ImageAlbumViewModel imageAlbumVm)
        {
            throw new NotImplementedException();
        }
    }
}