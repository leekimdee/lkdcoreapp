using AutoMapper;
using AutoMapper.QueryableExtensions;
using LkdCoreApp.Application.Interfaces;
using LkdCoreApp.Application.ViewModels;
using LkdCoreApp.Data.Entities;
using LkdCoreApp.Data.Enums;
using LkdCoreApp.Data.IRepositories;
using LkdCoreApp.Infrastructure.Interfaces;
using LkdCoreApp.Utilities.Dtos;
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

        public PagedResult<ImageViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _imageRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Title.Contains(keyword));

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<ImageViewModel>().ToList();

            var paginationSet = new PagedResult<ImageViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public ImageViewModel GetById(int id)
        {
            return Mapper.Map<Image, ImageViewModel>(_imageRepository.FindById(id));
        }

        public List<ImageViewModel> GetImagesByAlbumId(int albumId)
        {
            return _imageRepository.FindAll(f => f.ImageAlbumId == albumId).ProjectTo<ImageViewModel>().ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ImageViewModel imageVm)
        {
            var image = Mapper.Map<ImageViewModel, Image>(imageVm);
            _imageRepository.Update(image);
        }
    }
}