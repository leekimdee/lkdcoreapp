using LkdCoreApp.Data.Enums;
using LkdCoreApp.Data.Interfaces;
using LkdCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LkdCoreApp.Data.Entities
{
    public class Image : DomainEntity<int>, IDateTracking, IUserTracking<string>, IHasSoftDelete
    {
        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int ImageAlbumId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public Status Status { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("ImageAlbumId")]
        public virtual ImageAlbum ImageAlbum { get; set; }
    }
}