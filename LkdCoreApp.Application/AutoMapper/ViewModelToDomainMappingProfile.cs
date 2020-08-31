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
        }
    }
}