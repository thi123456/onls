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
   
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        [Route("getallparent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetProductcategory();

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
                var model = _productService.GetMultiPaging(filter, out total, page, pageSize);
                var responData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
                var paginationSet = new PaginationSet<ProductViewModel>()
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
                var model = _productService.GetById(id);
                var responData = Mapper.Map<Product, ProductViewModel>(model);

                var respon = request.CreateResponse(HttpStatusCode.OK, responData);
                return respon;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productVieModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (ModelState.IsValid)
                {
                    var newProduct = new Product();
                    newProduct.UpdateProduct(productVieModel);
                    newProduct.CreatedBy = User.Identity.Name;
                    _productService.Add(newProduct);
                    _productService.Save();
                    var responData = Mapper.Map<Product, ProductViewModel>(newProduct);
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
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var newProduct = _productService.GetById(productViewModel.ID);
                    newProduct.UpdateProduct(productViewModel, "update");
                    newProduct.UpdatedBy = User.Identity.Name;
                    _productService.Update(newProduct);
                    _productService.Save();
                    var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
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
                    var oldProduct = _productService.Delete(id);

                    _productService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, oldProduct);
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
                        _productService.DeleteV(item);
                    }

                    _productService.Save();

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