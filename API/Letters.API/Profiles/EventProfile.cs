
using AutoMapper;
using Letters.Domain.Dto;
using Letters.Domain.Models;

namespace Letters.Profiles
{
  public class MailProfile: Profile
  {
    public MailProfile()
    {
      CreateMap<Mail, MailDto>()
        .ForMember(
          destination => destination.Recipients,
          options => options.MapFrom(
            source => source.Recipients.Select(m => m.Name).ToArray()
          )
        );
      
      CreateMap<CreateMailDto, Mail>();    
    }
  }
}