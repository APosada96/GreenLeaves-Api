using GreenLeaves.Domain.Models;
using GreenLeaves.Domain.Services.Contracts;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace GreenLeaves.Domain.Services
{
    public class ContactService: IContactService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IGenericRepository<Contact> _genericRepositoryContact;
        private readonly IGenericRepository<City> _genericRepositoryCity;
        private readonly IGenericRepository<Country> _genericRepositoryCountry;
        private readonly IGenericRepository<State> _genericRepositoryState;
        private readonly IGenericUnitOfWork _genericUnitOfWork;
        public ContactService(EmailConfiguration emailConfig,
                              IGenericRepository<Contact> genericRepositoryContact,
                              IGenericRepository<Country> genericRepositoryCountry,
                              IGenericRepository<State> genericRepositoryState,
                              IGenericRepository<City> genericRepositoryCity,
                              IGenericUnitOfWork genericUnitOfWork
        )
        {
            _emailConfig =  emailConfig ?? throw new ArgumentNullException(nameof(emailConfig));
            _genericRepositoryContact = genericRepositoryContact ?? throw new ArgumentNullException(nameof(genericRepositoryContact));
            _genericRepositoryCountry = genericRepositoryCountry ?? throw new ArgumentNullException(nameof(genericRepositoryCountry));
            _genericRepositoryState = genericRepositoryState ?? throw new ArgumentNullException(nameof(genericRepositoryState));
            _genericRepositoryCity = genericRepositoryCity ?? throw new ArgumentNullException(nameof(genericRepositoryCity));
            _genericUnitOfWork = genericUnitOfWork ?? throw new ArgumentNullException(nameof(genericUnitOfWork));
        }

        public async Task<List<CityAndState>> GetCityAndState()
        {
            List<CityAndState> list = new List<CityAndState>();
            try
            {
                var countryList = await _genericRepositoryCountry.ListAsync();
                var stateList = await _genericRepositoryState.ListAsync();
                var cityList = await _genericRepositoryCity.ListAsync();
                var itemCountry = countryList.Find(x => x.Id == countryList[0].Id);
                var state = stateList.FindAll(x => x.IdCountry == itemCountry!.Id);
                foreach (var item in state)
                {
                   
                   var city = cityList.Find(x => x.IdState == item.Id);
                   list.Add(new CityAndState()
                   { 
                       Id = item.Id,
                       Name = city!.Name + ", " + item.Name + ", " + itemCountry!.Name
                   });
                }
                
                return list;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<string> SendMessage(ContactViewModel model)
        {
            Contact data = null!;
           
            try
            {
                DateTime date = Convert.ToDateTime(model.Date);
                string mon = date.ToString("MMM");
                string year = date.Year.ToString();
                string day = date.Day.ToString();
                string resultDate = day + "-" + mon + "-" + year;
                var emailMessage = await CreateEmailMessage(model, resultDate);
                if (Send(emailMessage))
                {
                    data = new Contact {                        
                        Telephone = model.Telephone,
                        Email = model.Email,
                        CityAndState = model.CityAndState,
                        Name = model.Name,
                        Date = model.Date
                    };
                    _genericRepositoryContact.Insert(data);
                    await _genericUnitOfWork.SaveChangesAsync();
                }
                return data.Name!;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        private async Task<MailMessage> CreateEmailMessage(ContactViewModel model,string date)
        {
            try
            {
                var linkedResource = new LinkedResource(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../GreenLeaves.Domain/Resources/assets/hoja.png"));
                linkedResource.ContentId = "prueba";
                var alternateView = AlternateView.CreateAlternateViewFromString(replaceBody(model, linkedResource, date),null,MediaTypeNames.Text.Html);
                alternateView.LinkedResources.Add(linkedResource);
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_emailConfig.From);
                message.Subject = _emailConfig.Subject;
                message.AlternateViews.Add(alternateView);
                message.IsBodyHtml = true;
                message.To.Add(_emailConfig.To);

                return await Task.FromResult(message);
               
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        private  bool Send(MailMessage message)
        {
            try
            {
                using var smtp = new SmtpClient();
                smtp.Port = _emailConfig.Port;
                smtp.Host = _emailConfig.Host;
                smtp.Credentials= new NetworkCredential(_emailConfig.UserName,_emailConfig.Password);
                smtp.EnableSsl = true;
                smtp.Send(message);
                smtp.Dispose();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        private string replaceBody(ContactViewModel content, LinkedResource linkedResource,string date) 
        {
            try
            {
                string[] cityandstate = content.CityAndState!.Split(',');
                using (StreamReader reader = File.OpenText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _emailConfig.Template)))
                {
                    string html = reader.ReadToEnd();
                    StringBuilder sb = new StringBuilder(html);
                    sb.Replace("{{Name}}",content.Name);
                    sb.Replace("{{Correo}}", content.Email);
                    sb.Replace("{{State}}", cityandstate[1]);
                    sb.Replace("{{City}}", cityandstate[0]);
                    sb.Replace("{{Country}}", cityandstate[2]);
                    sb.Replace("{{Date}}", date);
                    return sb.ToString();
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
