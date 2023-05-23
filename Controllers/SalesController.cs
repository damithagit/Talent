using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json.Schema;
using ReactAspCrud.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
//using System.Data.Entity.Migrations.Model;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesDbContext _salesDbContext;
        

        public SalesController(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }

       
        //Customer Table
        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await _salesDbContext.Customers.ToListAsync();
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<Customer> AddCustomer(Customer objCustomer)
        {
            _salesDbContext.Customers.Add(objCustomer);
            await _salesDbContext.SaveChangesAsync();
            return objCustomer;
        }
        [HttpPatch]
        [Route("UpdateCustomer/{CustomerId})")]
        public async Task <Customer> UpdateCustomer(Customer objCustomer)
        {
            _salesDbContext.Entry(objCustomer).State = EntityState.Modified;
            await _salesDbContext.SaveChangesAsync();
            return objCustomer;
        }
        [HttpDelete]
        [Route("DeleteCustomer/{CustomerId})")]
        public bool DeleteCustomer(int CustomerId)
        {
            bool a = false;
            var customer = _salesDbContext.Customers.Find(CustomerId);
            if (customer != null) 
            {
                a = true;
                _salesDbContext.Entry(customer).State = EntityState.Deleted;
                _salesDbContext.SaveChanges();

            }
            else
            {
                a = false;

            }
            return a;
        }

        //Product Table
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _salesDbContext.Product.ToListAsync();
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<Product> AddProduct(Product objProduct)
        {
            _salesDbContext.Product.Add(objProduct);
            await _salesDbContext.SaveChangesAsync();
            return objProduct;
        }
        [HttpPatch]
        [Route("UpdateProduct/{ProductId})")]
        public async Task<Product> UpdateProduct(Product objProduct)
        {
            _salesDbContext.Entry(objProduct).State = EntityState.Modified;
            await _salesDbContext.SaveChangesAsync();
            return objProduct;
        }
        [HttpDelete]
        [Route("DeleteProduct/{ProductId})")]
        public bool DeleteProduct(int ProductId)
        {
            bool a = false;
            var product = _salesDbContext.Product.Find(ProductId);
            if (product != null)
            {
                a = true;
                _salesDbContext.Entry(product).State = EntityState.Deleted;
                _salesDbContext.SaveChanges();

            }
            else
            {
                a = false;

            }
            return a;
        }

        //Store Table
        [HttpGet]
        [Route("GetStore")]
        public async Task<IEnumerable<Store>> GetStore()
        {
            return await _salesDbContext.Stores.ToListAsync();
        }
        [HttpPost]
        [Route("AddStore")]
        public async Task<Store> AddStore(Store objStore)
        {
            _salesDbContext.Stores.Add(objStore);
            await _salesDbContext.SaveChangesAsync();
            return objStore;
        }
        [HttpPatch]
        [Route("UpdateStore/{StoreId})")]
        public async Task<Store> UpdateStore(Store objStore)
        {
            _salesDbContext.Entry(objStore).State = EntityState.Modified;
            await _salesDbContext.SaveChangesAsync();
            return objStore;
        }
        [HttpDelete]
        [Route("DeleteStore/{StoreId})")]
        public bool DeleteStore(int StoreId)
        {
            bool a = false;
            var store = _salesDbContext.Stores.Find(StoreId);
            if (store != null)
            {
                a = true;
                _salesDbContext.Entry(store).State = EntityState.Deleted;
                _salesDbContext.SaveChanges();

            }
            else
            {
                a = false;

            }
            return a;
        }

        //Sales Table
        [HttpGet]
        [Route("GetSales")]
        public async Task< IEnumerable<Sales>> GetSales()
        {
            return await _salesDbContext.Sales
         
                .Include(s => s.Customers)
                .Include(sr => sr.Stores)
                .Include(pr => pr.Products).ToListAsync();


           // return await _salesDbContext.Sales.ToListAsync();
        }

        [HttpPost]
        [Route("AddSales")]
        public async Task<Sales?> AddSales(SalesOnly objSales)
        {

           
            var customer1 = await _salesDbContext.Customers.FindAsync(objSales.CustomerId);
            var product1 = await _salesDbContext.Product.FindAsync(objSales.ProductId);
            var store1 = await _salesDbContext.Stores.FindAsync(objSales.StoreId);

            if( (customer1 == null) || (product1==null) ||(store1 == null))
            {
                return null;
            }
            else
            { 
              
                var newobjsales= new Sales
                {
                    CustomerId = customer1.CustomerId,
                    ProductId = objSales.ProductId,
                    StoreId = objSales.StoreId,
                    DateSold = objSales.DateSold,
                    Quantity = objSales.Quantity
                };


                _salesDbContext.Add(newobjsales);

                await _salesDbContext.SaveChangesAsync();
                return newobjsales;
            }
        }
        [HttpPatch]
        [Route("UpdateSales/{SalesId})")]
        public async Task<Sales> UpdateSales(SalesOnly objSales)
        {
            var newobjsales = new Sales
            {
                SalesId = objSales.SalesId,
                CustomerId = objSales.CustomerId,
                ProductId = objSales.ProductId,
                StoreId = objSales.StoreId,
                DateSold = objSales.DateSold,
                Quantity = objSales.Quantity
            };
            _salesDbContext.Entry(newobjsales).State = EntityState.Modified;
            await _salesDbContext.SaveChangesAsync();

           // _salesDbContext.Update(newobjsales);
         
            return newobjsales;
        }
        [HttpDelete]
        [Route("DeleteSales/{SalesId})")]
        public bool DeleteSales(int SalesId)
        {
            bool a = false;
            var sales = _salesDbContext.Sales.Find(SalesId);
            if (sales != null)
            {
                a = true;
                _salesDbContext.Entry(sales).State = EntityState.Deleted;
                _salesDbContext.SaveChanges();

            }
            else
            {
                a = false;

            }
            return a;
        }
    }
}
