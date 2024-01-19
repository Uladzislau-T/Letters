using AutoMapper;
using Letters.API.Filters;
using Letters.Domain.Dto;
using Letters.Domain.Models;
using Letters.Infrastructure.Contracts;
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
  [ServiceFilter(typeof(ValidationFilterAttribute))]   
  public async Task<ActionResult<IEnumerable<Mail>>> GetMails()
  {
      var mails = await _repository.Mail.GetAllMailsAsync(trackChanges: false);

      var dtos = _mapper.Map<IEnumerable<MailDto>>(mails);             

      return Ok(dtos);
  }
}

