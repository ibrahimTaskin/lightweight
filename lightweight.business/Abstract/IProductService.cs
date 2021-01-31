using lightweight.data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace lightweight.business.Abstract
{
    public interface IProductService
    {
        ServiceResponse<Product> GetProducts(); // ServiceResponse türünden product istedik. Sadece imzasını tanımladık.
    }
}
