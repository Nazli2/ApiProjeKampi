using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly ApiContext _context;
    private readonly IMapper _mapper;

    public MessagesController(ApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult MessagesList()
    {
        var values = _context.Messages.ToList();
        return Ok(_mapper.Map<List<ResultMessageDto>>(values));
    }

    [HttpPost]
    public IActionResult CreateMessage(CreateMessageDto createMessageDto)
    {
        var value = _mapper.Map<Message>(createMessageDto);
        _context.Messages.Add(value);
        _context.SaveChanges();
        return Ok("Mesaj Ekleme İşlemi Başarılı");
    }

    [HttpDelete]
    public IActionResult DeleteMessage(int id)
    {
        var value = _context.Messages.Find(id);
        _context.Messages.Remove(value);
        _context.SaveChanges();
        return Ok("Mesaj Silme İşlemi Başarılı");
    }

    [HttpGet("GetMessage")]
    public IActionResult GetMessage(int id)
    {
        var value = _context.Messages.Find(id);
        return Ok(_mapper.Map<GetByIdMessageDto>(value));
    }

    [HttpPut]
    public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
    {
        var value = _mapper.Map<Message>(updateMessageDto);
        _context.Messages.Update(value);
        _context.SaveChanges();
        return Ok("Mesaj Güncelleme İşlemi Başarılı");
    }

    [HttpGet("MessageListByIsReadFalse")]
    public IActionResult MessageListByIsReadFalse()
    {
        var value = _context.Messages.Where(x => x.IsRead == false).ToList();
        return Ok(value);
    }
}
