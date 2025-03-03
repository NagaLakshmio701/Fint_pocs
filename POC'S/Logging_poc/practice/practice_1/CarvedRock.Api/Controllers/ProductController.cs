using CarvedRock.Domain;
using CarvedRock.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductLogic _productLogic;

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger,IProductLogic productLogic)
    {
        _logger = logger;
        _productLogic = productLogic;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductModel>> Get(string category = "all")
    {
        _logger.LogInformation("get products in api {category}", category);
        return await _productLogic.GetProductsForCategory(category);
    }
}