using LkdCoreApp.Data.EF;
using LkdCoreApp.Data.Entities;
using LkdCoreApp.Data.Enums;
using LkdCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LkdCoreApp.Application.Implementations
{
    public class TestImageAlbumService
    {
        private TestEFRepository<ImageAlbum, int> _imageAlbumRepository;
        private TestEFUnitOfWork _unitOfWork;

        public TestImageAlbumService()
        {
            _imageAlbumRepository = new TestEFRepository<ImageAlbum, int>();
            _unitOfWork = new TestEFUnitOfWork();
        }

        public ImageAlbum Add(ImageAlbum imageAlbum)
        {
            _imageAlbumRepository.Add(imageAlbum);
            return imageAlbum;
        }

        public void Delete(int id)
        {
            _imageAlbumRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ImageAlbum> GetAll()
        {
            return _imageAlbumRepository.FindAll().OrderBy(x => x.Id).ToList();
        }

        public List<ImageAlbum> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _imageAlbumRepository.FindAll(x => x.Title.Contains(keyword))
                    .OrderBy(x => x.Id).ToList();
            else
                return _imageAlbumRepository.FindAll().OrderBy(x => x.Id).ToList();
        }

        public PagedResult<ImageAlbum> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _imageAlbumRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Title.Contains(keyword));

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ToList();

            var paginationSet = new PagedResult<ImageAlbum>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public ImageAlbum GetById(int id)
        {
            return _imageAlbumRepository.FindById(id);
        }

        public ImageAlbum GetByIdWithIncludeObject(int id)
        {
            return _imageAlbumRepository.FindById(id, i => i.Images);
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ImageAlbum imageAlbum)
        {
            _imageAlbumRepository.Update(imageAlbum);
        }
    }
}
