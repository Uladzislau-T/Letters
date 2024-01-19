using AutoMapper;
using Letters.API.Filters;
using Letters.Domain.Dto;
using Letters.Domain.Models;
using Letters.Infrastructure.Contracts;
using Letters.Models;
using Microsoft.AspNetCore.Mvc;

namespace Letters.API.Controllers;

[Route("api/mails")]
[ApiController]
public class MailController : ControllerBase
{        
  private readonly ILogger<MailController> _logger;
  private readonly IMapper _mapper;
  private readonly IUnitOfWork _repository;

  public MailController(ILogger<MailController> logger, IMapper mapper, IUnitOfWork repository)
  {            
    _logger = logger;
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(Name = "GetMails")]   
  public async Task<ActionResult<IEnumerable<MailDto>>> GetMails()
  {
      var mails = await _repository.Mail.GetAllMailsAsync(trackChanges: false);

      var dtos = _mapper.Map<IEnumerable<MailDto>>(mails);             

      return Ok(dtos);
  }

  [HttpPost]    
  [ServiceFilter(typeof(ValidationFilterAttribute))]
  public async Task<ActionResult<MailDto>> CreateEvent([FromBody]CreateMailDto dto)
  {
    var mail = _mapper.Map<Mail>(dto);

    if(mail.Recipients == null)
        mail.Recipients = new List<Recipient>();

    var recipients = dto.Recipients.Select(r => new Recipient() {Name = r}).ToArray();

    mail.Recipients = recipients;

    await _repository.Mail.CreateMailAsync(mail);


    var message = new EmailData(new string[] { user.Email }, "Confirmation email link", confirmationLink);
    await _emailService.SendEmailAsync(message);


    await _repository.SaveAsync();

    var eventDto = _mapper.Map<MailDto>(mail);        

    return Ok(eventDto);
  }
}

