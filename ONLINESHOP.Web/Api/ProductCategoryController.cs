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
using System.Web.Script.Serialization;

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
        public HttpResponseMessage GetAll(HttpRequestMessage request, string filter, int page = 1, int pageSize = 1)
        {
            int total = 0;
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetMultiPaging(filter, out total, page, pageSize);
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

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetById(id);
                var responData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

                var respon = request.CreateResponse(HttpStatusCode.OK, responData);
                return respon;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryVieModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (ModelState.IsValid)
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

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoyViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var newProductCategory = _productCategoryService.GetById(productCategoyViewModel.ID);
                    newProductCategory.UpdateProductCategory(productCategoyViewModel, "update");
                    _productCategoryService.Update(newProductCategory);
                    _productCategoryService.Save();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var oldProductCategory = _productCategoryService.Delete(id);

                    _productCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, oldProductCategory);
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string listId)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    var list = new JavaScriptSerializer().Deserialize<IEnumerable<int>>(listId);
                    foreach (int item in list)
                    {
                        _productCategoryService.DeleteV(item);
                    }

                    _productCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, list);
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }
    }
}