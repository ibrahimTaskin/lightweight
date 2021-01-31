using lightweight.business.Abstract;
using lightweight.core.Abstract;
using lightweight.data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lightweight.business.Concrete
{
    public class ProductManager : IProductService
    {
        private IRepository<Product> _productRepository;
        public ProductManager(IRepository<Product> productRepository)
        {
            _productRepository = productRepository; // dependency injection
        }

        public ServiceResponse<Product> GetProducts()
        {
            // Giden requestin dönen responsu
            var response = new ServiceResponse<Product>(null);

            try
            {
                response.List = _productRepository.TableNoTracking.ToList(); // Sadece okuyacağımız için noTracking aldık.
                response.Count = response.List.Count; // dönen sonuç sayısı
                response.IsSuccessful = true; // sonuç var mı evet
                return response;
            }
            catch (Exception e)
            {
                response.ExceptionMessage = e.Message; // hata varsa mesajı
                response.HasExceptionError = true; // Hata var mı evet
                return response;
            }
        }
    }
}
