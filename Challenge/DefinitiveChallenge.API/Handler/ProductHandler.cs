using AutoMapper;
using DefinitiveChallenge.API.Controllers;
using DefinitiveChallenge.API.DbContexts;
using DefinitiveChallenge.API.Models;
using DefinitiveChallenge.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DefinitiveChallenge.API.Handler
{
    public class ProductHandler : ControllerBase
    {
        private readonly ProductInfoContext _context;
        private readonly ProductTypes _productTypes;
        private readonly IProductInfoRepository _productInfoRepository;
        private readonly ILogger<ProductHandler> _logger;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;


        public ProductHandler(           
            ProductTypes productTypes,
            ProductInfoContext context,
            IProductInfoRepository productInfoRepository,
            ILogger<ProductHandler> logger,
            IMailService mailService,
            IMapper mapper)
        {
            _productTypes = productTypes;
            _context = context;
            _productInfoRepository = productInfoRepository ?? throw new ArgumentNullException(nameof(productInfoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductDto>> GetProductsHandler(string? description, string? searchQuery)
        {
            var productEntities = await _productInfoRepository.GetProductsAsync(description, searchQuery);
            
            return _mapper.Map<IEnumerable<ProductDto>>(productEntities);
        }

        public async Task<ProductDto> GetProductHandler(int id)
        {
            var productId = await _productInfoRepository.GetProductAsync(id);
            return _mapper.Map<ProductDto>(productId);
        }

        public async Task<ProductDto> CreateProductHandler(ProductCreationDto newProduct)
        {
            var list = _productTypes.Type;

            var validation = list.Contains(newProduct.Type);

            if (validation)
            {
                var productCreated = _mapper.Map<Entities.Product>(newProduct);
                _productInfoRepository.AddProduct(productCreated);
                await _productInfoRepository.SaveChangesAsync();
                return _mapper.Map<Models.ProductDto>(productCreated);
            }
            else
            {
                throw new Exception("Introduzca 'Bienes','Vehículos','Apartamentos' o 'Terrenos' dependiendo del tipo de su producto");
            }

            //var productCreated = _mapper.Map<Entities.Product>(newProduct);
            //_productInfoRepository.AddProduct(productCreated);
            //await _productInfoRepository.SaveChangesAsync();
            //return _mapper.Map<Models.ProductDto>(productCreated);
        }

        public async Task<ProductDto> UpdateProductHandler(int id, ProductUpdateDto product)
        {
            if (!await _productInfoRepository.ProductExistAsync(id))
            {
                throw new Exception("El producto que desea actualizar no existe porfavor verifique el id ingresado.");
            }

            var list = _productTypes.Type;

            var validation = list.Contains(product.Type);

            if (validation == true)
            {
                var productUpdate = await _productInfoRepository.GetProductAsync(id);
                _mapper.Map(product, productUpdate);
                await _productInfoRepository.SaveChangesAsync();
                return _mapper.Map<ProductDto>(productUpdate);
            }
            else
            {
                throw new Exception("Introduzca 'Bienes','Vehículos','Apartamentos' o 'Terrenos' dependiendo del tipo de su producto");
            }
        }

        
        public async Task<ProductDto> DeleteProductHandler(int id)
        {
            if (!await _productInfoRepository.ProductExistAsync(id))
            {
                throw new Exception("El producto que desea actualizar no existe porfavor verifique el id ingresado.");
            }

            var productEntity = await _productInfoRepository.GetProductAsync(id);

            _productInfoRepository.DeleteProduct(productEntity);

            await _productInfoRepository.SaveChangesAsync();

            _mailService.Send(
                "Un producto fue eliminado.",
                $"El producto {productEntity.Description} con el id {productEntity.Id} fue eliminado.");
            return _mapper.Map<ProductDto>(productEntity);
        }
    }
}
