using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.NotificationDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly ApiContext _context;
    private readonly IMapper _mapper;

    public NotificationsController(ApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult NotificationsList()
    {
        var values = _context.Notifications.ToList();
        return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
    }

    [HttpPost]
    public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
    {
        var value = _mapper.Map<Notification>(createNotificationDto);
        _context.Notifications.Add(value);
        _context.SaveChanges();
        return Ok("Bildirim Ekleme İşlemi Başarılı");
    }

    [HttpDelete]
    public IActionResult DeleteNotification(int id)
    {
        var value = _context.Notifications.Find(id);
        _context.Notifications.Remove(value);
        _context.SaveChanges();
        return Ok("Bildirim Silme İşlemi Başarılı");
    }

    [HttpGet("GetNotification")]
    public IActionResult GetNotification(int id)
    {
        var value = _context.Notifications.Find(id);
        return Ok(_mapper.Map<GetByIdNotificationDto>(value));
    }

    [HttpPut]
    public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
    {
        var value = _mapper.Map<Notification>(updateNotificationDto);
        _context.Notifications.Update(value);
        _context.SaveChanges();
        return Ok("Bildirim Güncelleme İşlemi Başarılı");
    }
}
