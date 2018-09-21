using AutoMapper;
using ONLINESHOP.Model.Models;
using ONLINESHOP.Service;
using ONLINESHOP.Web.Infrastructure.Core;
using ONLINESHOP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ONLINESHOP.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService,IProductCategoryService productCategoryService):base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () => {

                var model = _productCategoryService.GetAll();
                var responData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                var respon=request.CreateResponse(HttpStatusCode.OK,responData);
                return respon;
            });
        }
    }
}
