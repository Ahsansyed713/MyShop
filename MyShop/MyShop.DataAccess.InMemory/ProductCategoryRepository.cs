﻿using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productsCategories;


        public ProductCategoryRepository()
        {
            productsCategories = cache["productsCategories"] as List<ProductCategory>;
            if (productsCategories == null)
            {
                productsCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productsCategories"] = productsCategories;
        }
        public void Insert(ProductCategory p)
        {
            productsCategories.Add(p);
        }
        public void Update(ProductCategory proCat)
        {
            ProductCategory productCategoryToUpdate = productsCategories.Find(a => a.Id == proCat.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = proCat;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productsCategories.Find(a => a.Id == Id);

            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }


        public IQueryable<ProductCategory> Collection()
        {
            return productsCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productsCategories.Find(a => a.Id == Id);

            if (productCategoryToDelete != null)
            {
                productsCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }
}
