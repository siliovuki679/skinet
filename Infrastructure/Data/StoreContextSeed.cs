using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try{
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(path + @"../../../../../Infrastructure/Data/SeedData/brands.json");

                    

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                        context.Database.OpenConnection();
                        try
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands ON");
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands OFF");
                        }
                        finally
                        {
                            context.Database.CloseConnection();
                        }
                    }

                    await context.SaveChangesAsync();
                                    
                }
                if(!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(path + @"../../../../../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach(var item in types)
                    {
                        context.ProductTypes.Add(item);
                        context.Database.OpenConnection();
                        try
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes ON");
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes OFF");
                        }
                        finally
                        {
                            context.Database.CloseConnection();
                        }
                    }

                    await context.SaveChangesAsync();
                                    
                }
                if(!context.Products.Any())
                {
                    var productsData = File.ReadAllText(path + @"../../../../../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach(var item in products)
                    {
                        context.Products.Add(item);
                        // context.Database.OpenConnection();
                        
                    }

                    await context.SaveChangesAsync();
                                    
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}