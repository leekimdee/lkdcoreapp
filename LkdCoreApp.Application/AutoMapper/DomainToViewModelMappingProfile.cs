using AutoMapper;
using LkdCoreApp.Application.ViewModels;
using LkdCoreApp.Data.Entities;

namespace LkdCoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ImageAlbum, ImageAlbumViewModel>();
            CreateMap<Image, ImageViewModel>();
            CreateMap<Video, VideoViewModel>();
        }
    }
}