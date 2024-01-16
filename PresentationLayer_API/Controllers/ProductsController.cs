using AutoMapper;

using BusinessLayer.Interfaces;

using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace PresentationLayer_API.Controllers
{
    public class ProductsController(IProducts productsService) : ApiController
    {
        private readonly MapperConfiguration config = new(cfg =>
        {
            cfg.CreateMap<DomainModels.Product, PresentationLayer_API.Models.Product>();
            cfg.CreateMap<Models.Product, DomainModels.Product>();
        });
        private readonly IProducts productsService = productsService;

        //GET: api/Products
        public List<Models.Product> GetProducts()
        {
            List<DomainModels.Product> productFromDB = productsService.GetProducts();
            Mapper mapper = new(config);
            List<Models.Product> products = mapper
                .Map<List<DomainModels.Product>, List<PresentationLayer_API.Models.Product>>(productFromDB);
            return products;
        }

        //GET: api/Products/5
        [ResponseType(typeof(Models.Product))]
        public IHttpActionResult GetProduct(int id)
        {
            DomainModels.Product productFromDB = productsService.GetProduct(id);
            if (productFromDB == null)
            {
                return NotFound();
            }
            var mapper = new Mapper(config);
            PresentationLayer_API.Models.Product product = mapper
                .Map<DomainModels.Product, PresentationLayer_API.Models.Product>(productFromDB);
            return Ok(product);
        }

        //PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Models.Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (product is null || id != product.Product_Id)
            {
                return BadRequest();
            }
            Mapper mapper = new(config);
            DomainModels.Product productForDB = mapper
                .Map<Models.Product, DomainModels.Product>(product);

            bool updateSuccessful = productsService.UpdateProduct(productForDB);
            if (!updateSuccessful)
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //POST: api/Companies
        [ResponseType(typeof(Models.Product))]
        public IHttpActionResult PostProduct(Models.Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mapper mapper = new(config);
            DomainModels.Product productForDB = mapper.Map<Models.Product, DomainModels.Product>(product);
            productsService.AddProduct(productForDB);
            return CreatedAtRoute("DefaultApi", new { idd = productForDB.Product_Id }, productForDB);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Models.Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            DomainModels.Product product = productsService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            productsService.DeleteProduct(id);

            // Returning the deleted product may be unnecessary, 
            // but if you want to provide additional information, you can do so.
            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}