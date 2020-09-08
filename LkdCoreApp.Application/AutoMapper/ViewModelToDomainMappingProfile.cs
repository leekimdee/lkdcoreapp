using AutoMapper;
using LkdCoreApp.Application.ViewModels;
using LkdCoreApp.Data.Entities;

namespace LkdCoreApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ImageAlbumViewModel, ImageAlbum>()
                .ConstructUsing(i => new ImageAlbum(i.Title, i.SortOrder, i.Status));

            CreateMap<ImageViewModel, Image>()
                .ConstructUsing(i => new Image(i.Title, i.ImageUrl, i.ImageAlbumId, i.Status));

            CreateMap<VideoViewModel, Video>()
                .ConstructUsing(i => new Video(i.Title, i.VideoUrl, i.Status));
        }
    }
}