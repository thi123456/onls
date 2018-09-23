using ONLINESHOP.Data.Infrastructure;
using ONLINESHOP.Data.Repositories;
using ONLINESHOP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINESHOP.Service
{
    public interface IProductService
    {
        Product Add(Product Product);

        void Update(Product Product);

        Product Delete(int id);

        void DeleteV(int id);

        Product Delete(Product Product);



        IEnumerable<Product> GetAll();

      
     // IEnumerable<Product>GetProductcategoryByID();

        IEnumerable<ProductCategory> GetProductcategory();

        Product GetById(int id);

        IQueryable<Product> GetMultiPaging(string filter, out int total, int page = 1, int pageSize = 5, string[] includes = null);


        void Save();



    }
    public class ProductService:IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        private ProductCategoryService _productCategoryService;
        public ProductService(IUnitOfWork unitOfWork,IProductRepository productRepository,ProductCategoryService productCategoryService)
        {
            this._unitOfWork = unitOfWork;
            this._productRepository = productRepository;
            this._productCategoryService = productCategoryService;
        }

        public Product Add(Product Product)
        {
            return _productRepository.Add(Product);
        }

        public void Update(Product Product)
        {
            _productRepository.Update(Product);
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public void DeleteV(int id)
        {
            _productRepository.DeleteV(id);
        }

        public Product Delete(Product Product)
        {
            return _productRepository.Delete(Product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

       

       

        public Product GetById(int id)
        {
            return _productRepository.SingleById(id);
        }

        public IQueryable<Product> GetMultiPaging(string filter, out int total, int page = 1, int pageSize = 5, string[] includes = null)
        {
            if (string.IsNullOrEmpty(filter))
                return _productRepository.GetMultiPaging(null, out total, page, pageSize, includes);
            return _productRepository.GetMultiPaging((x=>x.Name.Contains(filter) || x.Description.Contains(filter)), out total, page, pageSize);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        //public IEnumerable<Product> GetProccategoryByID()
        //{
        //    return _productRepository.GetAll(new string[] {"ProductCateogry"});
        //}

        public IEnumerable<ProductCategory> GetProductcategory()
        {
           return _productCategoryService.GetAll();
        }
    }
}
