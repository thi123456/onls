namespace ONLINESHOP.Data.Migrations
{
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
    }
}