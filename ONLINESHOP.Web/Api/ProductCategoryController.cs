using AutoMapper;
using ONLINESHOP.Model.Models;
using ONLINESHOP.Service;
using ONLINESHOP.Web.Infrastructure.Core;
using ONLINESHOP.Web.Infrastructure.Extensions;
using ONLINESHOP.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ONLINESHOP.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getallparent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
          
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll();
                
                var responData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
               
                var respon = request.CreateResponse(HttpStatusCode.OK, responData);
                return respon;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string filter, int page=1, int pageSize=1)
        {
            int total = 0;
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetMultiPaging(filter,out total, page, pageSize);
                var responData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responData,
                    Page = page,
                    TotalCount = total,
                    TotalPage = (int)Math.Ceiling((decimal)total / pageSize)
                };
                var respon = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return respon;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request,ProductCategoryViewModel productCategoryVieModel)
        {
            return CreateHttpResponse(request, () =>
            {

                HttpResponseMessage respone = null;
                if(ModelState.IsValid)
                {
                    var newProductCategory = new ProductCategory();
                    newProductCategory.UpdateProductCategory(productCategoryVieModel);
                    _productCategoryService.Add(newProductCategory);
                    _productCategoryService.Save();
                    var responData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                    respone = request.CreateResponse(HttpStatusCode.Created, responData);
                }
                else
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
               
                return respone;

            });
        }
    }
}