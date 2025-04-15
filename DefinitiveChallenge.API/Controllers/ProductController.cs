//using AutoMapper;

//using DefinitiveChallenge.API.DbContexts;
//using DefinitiveChallenge.API.Entities;
//using DefinitiveChallenge.API.Handler;
//using DefinitiveChallenge.API.Models;
//using DefinitiveChallenge.API.Services;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;

//namespace DefinitiveChallenge.API.Controllers
//{
//    [ApiController]
//    [Route("api/products", Name = "GetProducts")]
//    public class ProductController : ControllerBase
//    {
//        //private readonly ProductInfoContext context;
//        private readonly IProductInfoRepository _productInfoRepository; 
//        private readonly ILogger<ProductController> _logger;
//        private readonly IMailService _mailService;
//        private readonly IMapper _mapper;
//        private readonly ProductHandler _productHandler; 

//        public ProductController(ProductHandler productHandler, ILogger<ProductController> logger,
//            IMailService mailService,
//            IProductInfoRepository productInfoRepository,
//            IMapper mapper)
//        {
//            //this.context = context;
//            _productHandler = productHandler ?? throw new ArgumentNullException(nameof(productHandler));
//            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
//            _productInfoRepository = productInfoRepository ?? throw new ArgumentNullException(nameof(productInfoRepository));
//            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(
//            string? description, string? searchQuery)
//        {
//            var productEntities = await _productInfoRepository.GetProductsAsync(description, searchQuery);
//            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productEntities));
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetProduct(int id)
//        {
//            var product = await _productInfoRepository.GetProductAsync(id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            return Ok(_mapper.Map<ProductDto>(product));
//        }

//        [HttpPost]
//        public async Task<ActionResult<int>> CreateProduct(
//            int id,
//            ProductCreationDto product)
//        {
//            if (await _productInfoRepository.ProductExistAsync(id))
//            {
//                return NotFound();
//            }

//            var finalProduct = _mapper.Map<Entities.Product>(product);

//            _productInfoRepository.AddProduct(
//                 finalProduct);

//            await _productInfoRepository.SaveChangesAsync();

//            var createdProductToReturn =
//                _mapper.Map<Models.ProductDto>(finalProduct);
//            //var newproduct = _productHandler.CreateProductHandler(product);

//            return CreatedAtRoute("GetProducts", finalProduct);

//            //return Ok(newproduct.Id);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateProduct(int id, ProductUpdateDto product)
//        {
//            if(!await _productInfoRepository.ProductExistAsync(id))
//            {
//                return NotFound();
//            }

//            var productEntity = await _productInfoRepository.GetProductAsync(id);

//            _mapper.Map(product, productEntity);

//            await _productInfoRepository.SaveChangesAsync();

//            return NoContent();
//        }

//        [HttpPatch("{id}")]
//        public async Task<ActionResult> PartiallyUpdateProduct(
//            int id,
//            JsonPatchDocument<ProductUpdateDto> 
//            patchDocument)
//        {
//            if(!await _productInfoRepository.ProductExistAsync(id))
//            {
//                return NotFound();
//            }

//            var productEntity = await _productInfoRepository.GetProductAsync(id);

//            var productToPatch = _mapper.Map<ProductUpdateDto>(
//                productEntity);

//            patchDocument.ApplyTo(productToPatch, ModelState);

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (!TryValidateModel(productToPatch))
//            {
//                return BadRequest(ModelState);
//            }

//            _mapper.Map(productToPatch, productEntity);
//            await _productInfoRepository.SaveChangesAsync();

//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteProduct(int id)
//        {
//            if (!await _productInfoRepository.ProductExistAsync(id))
//            {
//                return NotFound();
//            }

//            var productEntity = await _productInfoRepository.GetProductAsync(id);
//            if(productEntity == null)
//            {
//                return BadRequest();
//            }

//            _productInfoRepository.DeleteProduct(productEntity);

//            await _productInfoRepository.SaveChangesAsync();

//            _mailService.Send(
//                "Un producto fue eliminado.",
//                $"El producto {productEntity.Description} con el id {productEntity.Id} fue eliminado.");
//            return NoContent();
//        }
//    }
//}
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/
/*******************************************************************************************************************************************************************************************************************************************************/

// Nuevo código

using DefinitiveChallenge.API.Handler;
using DefinitiveChallenge.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DefinitiveChallenge.API.Controllers
{
    [ApiController]
    [Route("api/products", Name = "GetProducts")]
    public class ProductController : ControllerBase
    {
        private readonly ProductHandler _productHandler;
  
        public ProductController(ProductHandler productHandler)
        {
            _productHandler = productHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(
            string? description, string? searchQuery)
        {
            var product = await _productHandler.GetProductsHandler(description,searchQuery);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productHandler.GetProductHandler(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct(ProductCreationDto product)
        {
            var newproduct = await _productHandler.CreateProductHandler(product);           
            return CreatedAtRoute("GetProducts", newproduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductUpdateDto product)
        {
            await _productHandler.UpdateProductHandler(id, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productHandler.DeleteProductHandler(id);
            return NoContent();
        }
    }
}