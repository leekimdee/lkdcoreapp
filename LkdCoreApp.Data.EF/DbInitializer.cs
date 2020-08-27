using LkdCoreApp.Data.Entities;
using LkdCoreApp.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LkdCoreApp.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    Balance = 0,
                }, "123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            //if (_context.Functions.Count() == 0)
            //{
            //    _context.Functions.AddRange(new List<Function>()
            //    {
            //        new Function() {Id = "SYSTEM", Name = "Hệ thống",ParentId = null,SortOrder = 1,Status = Status.Active,URL = "/",IconCss = "fa-desktop"  },
            //        new Function() {Id = "ROLE", Name = "Nhóm",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Active,URL = "/admin/role/index",IconCss = "fa-home"  },
            //        new Function() {Id = "FUNCTION", Name = "Chức năng",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Active,URL = "/admin/function/index",IconCss = "fa-home"  },
            //        new Function() {Id = "USER", Name = "Người dùng",ParentId = "SYSTEM",SortOrder =3,Status = Status.Active,URL = "/admin/user/index",IconCss = "fa-home"  },
            //        new Function() {Id = "ACTIVITY", Name = "Nhật ký",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Active,URL = "/admin/activity/index",IconCss = "fa-home"  },
            //        new Function() {Id = "ERROR", Name = "Lỗi",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Active,URL = "/admin/error/index",IconCss = "fa-home"  },
            //        new Function() {Id = "SETTING", Name = "Cấu hình",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active,URL = "/admin/setting/index",IconCss = "fa-home"  },
            //        new Function() {Id = "PRODUCT",Name = "Sản phẩm",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/",IconCss = "fa-chevron-down"  },
            //        new Function() {Id = "PRODUCT_CATEGORY",Name = "Danh mục",ParentId = "PRODUCT",SortOrder =1,Status = Status.Active,URL = "/admin/productcategory/index",IconCss = "fa-chevron-down"  },
            //        new Function() {Id = "PRODUCT_LIST",Name = "Sản phẩm",ParentId = "PRODUCT",SortOrder = 2,Status = Status.Active,URL = "/admin/product/index",IconCss = "fa-chevron-down"  },
            //        new Function() {Id = "BILL",Name = "Hóa đơn",ParentId = "PRODUCT",SortOrder = 3,Status = Status.Active,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },
            //        new Function() {Id = "CONTENT",Name = "Nội dung",ParentId = null,SortOrder = 3,Status = Status.Active,URL = "/",IconCss = "fa-table"  },
            //        new Function() {Id = "BLOG",Name = "Bài viết",ParentId = "CONTENT",SortOrder = 1,Status = Status.Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
            //        new Function() {Id = "UTILITY",Name = "Tiện ích",ParentId = null,SortOrder = 4,Status = Status.Active,URL = "/",IconCss = "fa-clone"  },
            //        new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.Active,URL = "/admin/footer/index",IconCss = "fa-clone"  },
            //        new Function() {Id = "FEEDBACK",Name = "Phản hồi",ParentId = "UTILITY",SortOrder = 2,Status = Status.Active,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
            //        new Function() {Id = "ANNOUNCEMENT",Name = "Thông báo",ParentId = "UTILITY",SortOrder = 3,Status = Status.Active,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
            //        new Function() {Id = "CONTACT",Name = "Liên hệ",ParentId = "UTILITY",SortOrder = 4,Status = Status.Active,URL = "/admin/contact/index",IconCss = "fa-clone"  },
            //        new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.Active,URL = "/admin/slide/index",IconCss = "fa-clone"  },
            //        new Function() {Id = "ADVERTISMENT",Name = "Quảng cáo",ParentId = "UTILITY",SortOrder = 6,Status = Status.Active,URL = "/admin/advertistment/index",IconCss = "fa-clone"  },

            //        new Function() {Id = "REPORT",Name = "Báo cáo",ParentId = null,SortOrder = 5,Status = Status.Active,URL = "/",IconCss = "fa-bar-chart-o"  },
            //        new Function() {Id = "REVENUES",Name = "Báo cáo doanh thu",ParentId = "REPORT",SortOrder = 1,Status = Status.Active,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
            //        new Function() {Id = "ACCESS",Name = "Báo cáo truy cập",ParentId = "REPORT",SortOrder = 2,Status = Status.Active,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
            //        new Function() {Id = "READER",Name = "Báo cáo độc giả",ParentId = "REPORT",SortOrder = 3,Status = Status.Active,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
            //    });
            //}

            //if (_context.Footers.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
            //{
            //    string content = "Footer";
            //    _context.Footers.Add(new Footer()
            //    {
            //        Id = CommonConstants.DefaultFooterId,
            //        Content = content
            //    });
            //    _context.SaveChanges();
            //}

            if (_context.ImageAlbums.Count() == 0)
            {
                List<ImageAlbum> listImageAlbum = new List<ImageAlbum>()
                {
                    new ImageAlbum() { Title = "Thiên nhiên", Status = Status.Active, SortOrder = 1,
                        Images = new List<Image>()
                        {
                            new Image(){Title = "Hình 1", ImageUrl = "/UploadedFiles/images/1.jpg", Status = Status.Active},
                            new Image(){Title = "Hình 2", ImageUrl = "/UploadedFiles/images/2.jpg", Status = Status.Active},
                            new Image(){Title = "Hình 3", ImageUrl = "/UploadedFiles/images/3.jpg", Status = Status.Active},
                            new Image(){Title = "Hình 4", ImageUrl = "/UploadedFiles/images/4.jpg", Status = Status.Active},
                            new Image(){Title = "Hình 5", ImageUrl = "/UploadedFiles/images/5.jpg", Status = Status.Active},
                        }
                    }
                };
                _context.ImageAlbums.AddRange(listImageAlbum);
                _context.SaveChanges();
            }

            if (_context.Videos.Count() == 0)
            {
                _context.Videos.AddRange(new List<Video>()
                {
                    new Video(){Title = "Student Academy Award Winning", VideoUrl = "https://www.youtube.com/watch?v=Pq9yPrLWMyU", Status = Status.Active},
                    new Video(){Title = "Big Buck Bunny", VideoUrl = "https://www.youtube.com/watch?v=aqz-KE-bpKQ", Status = Status.Active},
                    new Video(){Title = "Amazing Nature", VideoUrl = "https://www.youtube.com/watch?v=mcixldqDIEQ", Status = Status.Active},
                    new Video(){Title = "Planet Earth: Amazing nature scenery", VideoUrl = "https://www.youtube.com/watch?v=6v2L2UGZJAM", Status = Status.Active},
                    new Video(){Title = "Nature and life", VideoUrl = "https://www.youtube.com/watch?v=IFitUvw6BtI", Status = Status.Active}
                });
                _context.SaveChanges();
            }

            //if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
            //{
            //    _context.SystemConfigs.Add(new SystemConfig()
            //    {
            //        Id = "HomeTitle",
            //        Name = "Tiêu đề trang chủ",
            //        Value1 = "Trang chủ TeduShop",
            //        Status = Status.Active
            //    });
            //}
            //if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
            //{
            //    _context.SystemConfigs.Add(new SystemConfig()
            //    {
            //        Id = "HomeMetaKeyword",
            //        Name = "Từ khoá trang chủ",
            //        Value1 = "Trang chủ TeduShop",
            //        Status = Status.Active
            //    });
            //}
            //if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
            //{
            //    _context.SystemConfigs.Add(new SystemConfig()
            //    {
            //        Id = "HomeMetaDescription",
            //        Name = "Mô tả trang chủ",
            //        Value1 = "Trang chủ TeduShop",
            //        Status = Status.Active
            //    });
            //}
        }
    }
}