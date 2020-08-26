using LkdCoreApp.Data.Enums;
using LkdCoreApp.Data.Interfaces;
using LkdCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LkdCoreApp.Data.Entities
{
    public class Video : DomainEntity<int>, IDateTracking, IUserTracking<string>, IHasSoftDelete
    {
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