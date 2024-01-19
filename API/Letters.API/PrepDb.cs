using AutoMapper;
using Letters.Domain.Models;
using Letters.Infrastructure;
using Letters.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Letters.Models;

namespace Letters.API
{
  class PrepDb
  {
    public static async Task PrepPopulation(IApplicationBuilder app, bool isDev)
    {
      using var serviceScope = app.ApplicationServices.CreateScope();
      await SeedData(
        serviceScope.ServiceProvider.GetService<Context>(),
        serviceScope.ServiceProvider.GetService<IMapper>(),
        isDev
      );
    }

    private static async Task SeedData(Context context, IMapper mapper, bool isDev)
    {            
      Console.WriteLine("--> Attempting to apply migrations...");
      try
      {
        context.Database.Migrate();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"--> Could not run migrations: {ex.Message}");
      }
      

      if(isDev)
      {  
        if (!context.Mail.Any())
        {
          Console.WriteLine("Creating dummy Emails");

          context.Mail.AddRange(
            new Mail() { 
              Subject = "Breakfast",
              Body = "At 8 o'clock at my place",
              Result = MailStatusEnum.Ok,
              Date = new DateTimeOffset(DateTime.Now),
              FaildMessage = "",
              Recipients = new List<Recipient>() {
                new Recipient() {               
                  Name = "fubuisdbf@mail.ru"
                },
                new Recipient() {               
                  Name = "ugsdug533453@gmail.com"
                }
              }
            },
            new Mail() { 
              Subject = "Lunch",
              Body = "At 12 o'clock near the station",
              Result = MailStatusEnum.Failed,
              Date = new DateTimeOffset(DateTime.Now),
              FaildMessage = "Exception occured",
              Recipients = new List<Recipient>() {
                new Recipient() {               
                  Name = "fubuisdbf@mail.ru"
                },
                new Recipient() {               
                  Name = "ugsdug533453@gmail.com"
                }
              }
            }
          );

          await context.SaveChangesAsync();

          Console.WriteLine("Successful creation of dummies");
        }
        else
        {
          Console.WriteLine("DbMails already exists");
        }
      }
    }
  }
}