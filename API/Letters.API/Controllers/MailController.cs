using AutoMapper;
using Letters.API.Filters;
using Letters.Domain.Dto;
using Letters.Domain.Models;
using Letters.Infrastructure.Contracts;
using Letters.Infrastructure.Services.EmailService;
using Letters.Models;
using Microsoft.AspNetCore.Mvc;

namespace Letters.API.Controllers;

[Route("api/mails")]
[ApiController]
public class MailController : ControllerBase
{        
  private readonly ILogger<MailController> _logger;
  private readonly IMapper _mapper;
  private readonly IEmailService _emailService;
  private readonly IUnitOfWork _repository;

  public MailController(ILogger<MailController> logger, IMapper mapper, IEmailService emailService, IUnitOfWork repository)
  {            
    _logger = logger;
    _mapper = mapper;
    _emailService = emailService;
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
  public async Task<ActionResult<MailDto>> CreateMail([FromBody]CreateMailDto dto)
  {
    var mail = _mapper.Map<Mail>(dto);

    if(mail.Recipients == null)
        mail.Recipients = new List<Recipient>();

    var recipients = dto.Recipients.Select(r => new Recipient() {Name = r}).ToArray();

    mail.Recipients = recipients;
    mail.Date = new DateTimeOffset(DateTime.Now);

    await _repository.Mail.CreateMailAsync(mail);

    var message = new EmailData(dto.Recipients, dto.Subject, dto.Body);

    try
    {
      await _emailService.SendEmailAsync(message);
    }
    catch(Exception ex)
    {
      mail.Result = Domain.Enums.MailStatusEnum.Failed;
      mail.FaildMessage = ex.Message;
      await _repository.SaveAsync();
      throw;
    }

    mail.Result = Domain.Enums.MailStatusEnum.Ok;
    await _repository.SaveAsync();

    var mailDto = _mapper.Map<MailDto>(mail);        

    return Ok(mailDto);
  }
}

