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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
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

        public PagedResult<ImageAlbumViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _imageAlbumRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Title.Contains(keyword));

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<ImageAlbumViewModel>().ToList();

            var paginationSet = new PagedResult<ImageAlbumViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public ImageAlbumViewModel GetById(int id)
        {
            return Mapper.Map<ImageAlbum, ImageAlbumViewModel>(_imageAlbumRepository.FindById(id));
        }

        public ImageAlbumViewModel GetByIdWithIncludeObject(int id)
        {
            return Mapper.Map<ImageAlbum, ImageAlbumViewModel>(_imageAlbumRepository.FindById(id, i => i.Images));
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