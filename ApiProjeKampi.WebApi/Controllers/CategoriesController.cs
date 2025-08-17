using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApiContext _context;

    public CategoriesController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult CategoryList()
    {
        var values = _context.Categories.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return Ok("Kategori ekleme işlemi başarılı.");
    }

    [HttpDelete]
    public IActionResult DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return Ok("Kategori silme işlemi başarılı.");
    }

    [HttpGet("GetCategory")]
    public IActionResult GetCategory(int id)
    {
        var category = _context.Categories.Find(id);
        return Ok(category);
    }

    [HttpPut]
    public IActionResult UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
        return Ok("Kategori güncelleme işlemi başarılı.");
    }
}
