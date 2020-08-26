using LkdCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace LkdCoreApp.Application.ViewModels
{
    public class ImageAlbumViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int SortOrder { get; set; }

        public bool IsDeleted { get; set; }

        public Status Status { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}