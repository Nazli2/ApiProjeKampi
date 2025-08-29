using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class YummyEventsController : ControllerBase
{
    private readonly ApiContext _context;

    public YummyEventsController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult YummyEventList()
    {
        var values = _context.YummyEvents.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateYummyEvent(YummyEvent yummyEvent)
    {
        _context.YummyEvents.Add(yummyEvent);
        _context.SaveChanges();
        return Ok("Etkinlik ekleme işlemi başarılı.");
    }

    [HttpDelete]
    public IActionResult DeleteYummyEvent(int id)
    {
        var yummyEvent = _context.YummyEvents.Find(id);
        _context.YummyEvents.Remove(yummyEvent);
        _context.SaveChanges();
        return Ok("Etkinlik silme işlemi başarılı.");
    }

    [HttpGet("GetYummyEvent")]
    public IActionResult GetYummyEventint(int id)
    {
        var yummyEvent = _context.YummyEvents.Find(id);
        return Ok(yummyEvent);
    }

    [HttpPut]
    public IActionResult UpdateYummyEvent(YummyEvent yummyEvent)
    {
        _context.YummyEvents.Update(yummyEvent);
        _context.SaveChanges();
        return Ok("Etkinlik güncelleme işlemi başarılı.");
    }
}
