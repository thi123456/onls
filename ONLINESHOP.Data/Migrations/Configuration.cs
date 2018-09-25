namespace ONLINESHOP.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ONLINESHOP.Data.ONLINESHOPDBCONTEXT>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ONLINESHOP.Data.ONLINESHOPDBCONTEXT context)
        {
            CreateProductCategoryExample(context);
            CreateAccountExample(context);
        }

        private void CreateProductCategoryExample(ONLINESHOP.Data.ONLINESHOPDBCONTEXT context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Name="Điện lạnh",
                    Alias="dien-lanh",
                    Status=false,
                     CreatedDate=DateTime.Now
                },
                 new ProductCategory()
                {
                     Name="Viễn thông",
                     Alias="vien-thong",
                     Status=false,
                      CreatedDate=DateTime.Now
                },
                  new ProductCategory()
                {
                      Name="Đồ  gia dụng",
                      Alias="do-gia-dung",
                      Status=true,
                       CreatedDate=DateTime.Now
                },
                   new ProductCategory()
                {
                       Name="Mỹ phẩmm",
                       Alias="my-pham",
                       Status=true,
                       CreatedDate=DateTime.Now
                       
                }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateAccountExample(ONLINESHOP.Data.ONLINESHOPDBCONTEXT context)
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ONLINESHOPDBCONTEXT()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ONLINESHOPDBCONTEXT()));

            //var user = new ApplicationUser()

            //{
            //    UserName = "thi",

            //    Email = "thictk1.09c050tk@gmail.com",

            //    EmailConfirmed = true,

            //    BirthDay = DateTime.Now,

            //    FullName = "Tran Ngoc Thi"
            //};

            //manager.Create(user, "123456$");

            //if (!roleManager.Roles.Any())

            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });

            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("thictk1.09c050tk@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        //private void CreateSlide(TeduShopDbContext context)
        //{
        //    if (context.Slides.Count() == 0)
        //    {
        //        List<Slide> listSlide = new List<Slide>()
        //        {
        //            new Slide() {
        //                Name ="Slide 1",
        //                DisplayOrder =1,
        //                Status =true,
        //                Url ="#",
        //                Image ="/Assets/client/images/bag.jpg",
        //                Content =@"	<h2>FLAT 50% 0FF</h2>
        //                        <label>FOR ALL PURCHASE <b>VALUE</b></label>
        //                        <p>Lorem ipsum dolor sit amet, consectetur 
        //                    adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
        //                <span class=""on-get"">GET NOW</span>" },
        //            new Slide() {
        //                Name ="Slide 2",
        //                DisplayOrder =2,
        //                Status =true,
        //                Url ="#",
        //                Image ="/Assets/client/images/bag1.jpg",
        //            Content=@"<h2>FLAT 50% 0FF</h2>
        //                        <label>FOR ALL PURCHASE <b>VALUE</b></label>
        //                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
        //                        <span class=""on-get"">GET NOW</span>"},
        //        };
        //        context.Slides.AddRange(listSlide);
        //        context.SaveChanges();
        //    }
        //}

        //private void CreateContactDetail(TeduShopDbContext context)
        //{
        //    if (context.ContactDetails.Count() == 0)
        //    {
        //        List<ContactDetail> Con = new List<ContactDetail>()
        //        {
        //            new ContactDetail()
        //            {
        //              Name="Shop thời trang TEDU",
        //              Address="Khánh Hòa",
        //              Email="thictk1.09c050tk@gmail.com",
        //              Lat=11.9922856,
        //              Lng=109.1584,
        //              Phone="4547384754",
        //              Website="http://camranhclub.com",
        //              Others="Liên hệ ngay",
        //              Status=true

        //            }




        //        };
        //        context.ContactDetails.AddRange(Con);
        //        context.SaveChanges();
        //    }
        //}

        //private void CreatePage(TeduShopDbContext context)
        //{
        //    if (context.Pages.Count() == 0)
        //    {
        //        List<Page> listPage = new List<Page>()
        //        {
        //            new Page() {
        //                 Name="Giới thiệu",
        //                Alias="gio-thieu",

        //                Content=@"Sau 2 trận đấu khó khăn trước 2 đối thủ lạ mặt Fucsovics (vòng 1) và Sandgren (vòng 2),
        //                         Nole gặp lại người quen Richard Gasquet (Pháp, hạng 25) ở vòng 3. Có thể nói sau hơn 1 thập
        //                         kỷ qua, Nole thực sự là một khắc tinh với tay vợt người Pháp, tính tổng cộng họ đã gặp nhau 
        //                        13 trận trong đó The Djoker thắng tới 12 trận và đang có 10 lần thắng liên tiếp.
        //                        Đây là lần đầu tiên họ gặp nhau tại US Open và có cuộc đối đầu thứ 10 trên mặt sân cứng. Djokovic
        //                        cũng đã 8 lần thắng đồng nghiệp người Pháp trên mặt sân này và chỉ thua trận duy nhất cách đây 11 năm,
        //                        tại giải Masters Cup tại Trung Quốc 2017. Tấm vé đi tiếp vào vòng 4 đang nghiêng về tay vợt số 6 thế giới.",
        //                Status=true
        //                        },
        //            new Page() {
        //                 Name="Trang chủ",
        //                Alias="trang-chu",

        //                Content=@"Sharapova vô địch Grand Slam từ năm 17 tuổi và Ostapenko vô địch Roland Garros khi 20 tuổi, hai tay vợt này
        //                sẽ đụng độ với nhau tại vòng 3 đơn nữ US Open. Có thể nói đây sẽ là một trận đấu hấp dẫn, bởi Masha đang trên con đường
        //                tìm lại phong độ còn Ostapenka thì muốn cho cả thế giới biết cô không phải ngôi sao 1 mùa.
        //               Hai tay vợt đã từng gặp nhau tại Rome 2018, khi đó phần thắng đã thuộc về Sharapova, sau khi cô để thua set 1 rồi ngược dòng
        //               thắng lại 2-1 với các tỷ số 6-7(6) 6-4 7-5. Ở cuộc tái đấu, tay vợt người Latvia chắc chắn sẽ không muốn điều tương tự xảy ra
        //               nên Masha sẽ phải chuẩn bị thể lực tốt để trải qua một cuộc đọ sức theo đúng nghĩa.",
        //                Status=true
        //                       }


        //        };
        //        context.Pages.AddRange(listPage);
        //        context.SaveChanges();
        //    }
        //}
    }
}