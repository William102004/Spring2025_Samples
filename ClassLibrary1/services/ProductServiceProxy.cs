using System;
using Spring2025_SAMPLES.models;

namespace Library.ecommerce.services;

    public class ProductServiceProxy
    {
        private ProductServiceProxy()
        {
            
        }

        private static ProductServiceProxy? instance; 
        private static object instanceLock = new object();
    public static ProductServiceProxy? GetCurrent()
    {
        lock (instanceLock)
        {
            if (instance == null)
            {
                instance = new ProductServiceProxy();
            }
        }

        return instance;
    }

    private List <Product?> list = new List<Product?>();
            public List<Product?> Products => list;

        }
    
    

