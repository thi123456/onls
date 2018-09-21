using AutoMapper;
using ONLINESHOP.Model.Models;
using ONLINESHOP.Service;
using ONLINESHOP.Web.Infrastructure.Core;
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

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page=1, int pageSize=1)
        {
            int total = 0;
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetMultiPaging(out total, page, pageSize);
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
    }
}