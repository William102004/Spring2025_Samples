using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Spring2025_SAMPLES.models;

namespace Library.ecommerce.services;

    public class ProductServiceProxy
    {
        private ProductServiceProxy()
        {
            Products = new List<Product?>();
        }

        private int lastKey
        {
            get
            {
                if(!Products.Any())
                {
                    return 0;
                }

                return Products.Select(p => p?.Id ?? 0).Max();
            }
        }
        private static ProductServiceProxy? instance; 
        private static object instanceLock = new object();
    public static ProductServiceProxy Current
    {
        get
        {
            lock(instanceLock)
            {
                if(instance == null)
                {
                    instance = new ProductServiceProxy();
                }
            }
            return instance;
        }
       
    }  
    
    public List<Product?> Products{get; private set; }
    public Product Add(Product product)
    {
        if(product.Id == 0)
        {
            product.Id = lastKey + 1;
        }

        Products.Add(product);
        return product;
    }
}
