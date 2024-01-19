using Microsoft.AspNetCore.Mvc;

namespace Letters.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailsController : ControllerBase
{        
  private readonly ILogger<MailsController> _logger;
  // private readonly IMapper _mapper;
  // private readonly IUnitOfWork _repository;

  // public MailsController(ILogger<MailsController> logger, IMapper mapper, IUnitOfWork repository)
  // {            
  //   _logger = logger;
  //   _mapper = mapper;
  //   _repository = repository;
  // }
  public MailsController(ILogger<MailsController> logger)
  {            
    _logger = logger;
  }

  
}

