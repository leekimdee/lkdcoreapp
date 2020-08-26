using LkdCoreApp.Data.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LkdCoreApp.Application.ViewModels
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public Status Status { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}