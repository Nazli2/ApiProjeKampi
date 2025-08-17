using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly ApiContext _context;

    public ContactsController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ContactList()
    {
        var values = _context.Contacts.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateContact(CreateContactDto createContactDto)
    {
        Contact contact = new Contact();
        contact.Email = createContactDto.Email;
        contact.Address = createContactDto.Address;
        contact.Phone = createContactDto.Phone;
        contact.MapLocation = createContactDto.MapLocation;
        contact.OpenHours = createContactDto.OpenHours;
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return Ok("Ekleme işlemi başarılı");
    }

    [HttpDelete]
    public IActionResult DeleteContact(int id)
    {
        var value = _context.Contacts.Find(id);
        _context.Contacts.Remove(value);
        _context.SaveChanges();
        return Ok("Silme işlemi başarılı");
    }

    [HttpGet("GetContact")]
    public IActionResult GetContact(int id)
    {
        var value = _context.Contacts.Find(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateContact(UpdateContactDto updateContactDto)
    {
        Contact contact = new Contact();
        contact.ContactId = updateContactDto.ContactId;
        contact.Email = updateContactDto.Email;
        contact.Address = updateContactDto.Address;
        contact.Phone = updateContactDto.Phone;
        contact.MapLocation = updateContactDto.MapLocation;
        contact.OpenHours = updateContactDto.OpenHours;
        _context.Contacts.Update(contact);
        _context.SaveChanges();
        return Ok("Güncelleme işlemi başarılı");
    }
}
