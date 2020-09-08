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
    public class VideoService : IVideoService
    {
        private IVideoRepository _videoRepository;
        private IUnitOfWork _unitOfWork;

        public VideoService(IVideoRepository videoRepository, IUnitOfWork unitOfWork)
        {
            _videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
        }

        public VideoViewModel Add(VideoViewModel videoVm)
        {
            var video = Mapper.Map<VideoViewModel, Video>(videoVm);
            _videoRepository.Add(video);
            return videoVm;
        }

        public void Delete(int id)
        {
            _videoRepository.Remove(id);
        }

        public List<VideoViewModel> GetAll()
        {
            return _videoRepository.FindAll().OrderBy(x => x.Id)
                .ProjectTo<VideoViewModel>().ToList();
        }

        public List<VideoViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _videoRepository.FindAll(x => x.Title.Contains(keyword))
                    .OrderBy(x => x.Id).ProjectTo<VideoViewModel>().ToList();
            else
                return _videoRepository.FindAll().OrderBy(x => x.Id)
                    .ProjectTo<VideoViewModel>()
                    .ToList();
        }

        public PagedResult<VideoViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _videoRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Title.Contains(keyword));

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<VideoViewModel>().ToList();

            var paginationSet = new PagedResult<VideoViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public VideoViewModel GetById(int id)
        {
            return Mapper.Map<Video, VideoViewModel>(_videoRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(VideoViewModel videoVm)
        {
            var video = Mapper.Map<VideoViewModel, Video>(videoVm);
            _videoRepository.Update(video);
        }
    }
}