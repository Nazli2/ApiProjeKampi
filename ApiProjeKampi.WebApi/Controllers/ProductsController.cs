using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IValidator<Product> _validator;
    private readonly ApiContext _context;

    public ProductsController(IValidator<Product> validator, ApiContext context)
    {
        _validator = validator;
        _context = context;
    }

    [HttpGet]
    public IActionResult ProductList()
    {
        var values = _context.Products.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        var validationResult = _validator.Validate(product);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
        }
        else
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ürün ekleme işlemi başarılı");
        }
    }
}
