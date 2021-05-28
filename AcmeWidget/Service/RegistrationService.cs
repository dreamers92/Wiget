using AcmeWidget.Interface;
using AcmeWidget.Models;
using AcmeWidget.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidget.Service
{
    public class RegistrationService : IRegistraionService
    {

        private readonly ILogger<RegistrationService> _logger;
        private readonly FormRegistrationsContext _db;



        public RegistrationService(FormRegistrationsContext db, ILogger<RegistrationService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Message<bool>> RegisterContact(Contact contact)
        {

            string messageId = Guid.NewGuid().ToString();
            Message<bool> result = new Message<bool>();

            //this should be saved  in application insights! or in a blob storage
            _logger.LogInformation(string.Format("{0} : {1} is called for creating a new applicant. The payload data : {2}", messageId, "AcmeWidget.Service.RegistrationService.RegisterContact", JsonConvert.SerializeObject(contact)));

            try
            {
                var applicant = new Applicant
                {
                    Activity = contact.Activity,
                    Comments = contact.Comments,
                    EmailAddress = contact.EmailAddress,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    //this should be based on timezone
                    DateModified = DateTime.Now
                };
                _db.Applicants.Add(applicant);
                await _db.SaveChangesAsync();


                // this should be saved based in application insights!or in a blob storage
                _logger.LogInformation(string.Format("{0} : data is successfully saved", messageId));

                result.IsSuccess = true;
                result.Data = true;
                result.CorrelationId = messageId;

                return result;

            }
            catch (Exception ex)
            {

                // this should be saved based in application insights!or in a blob storage
                _logger.LogInformation(string.Format("{0} : {1} is called for creating a new applicant with Errors. The Error is : {2}", messageId, "AcmeWidget.Service.RegistrationService.RegisterContact", ex.Message));
                _logger.LogInformation(string.Format("{0} : {1} is called for creating a new applicant with Errors. The Error Details is : {2}", messageId, "AcmeWidget.Service.RegistrationService.RegisterContact", ex.InnerException));
                result.IsSuccess = false;
                result.Error = new Error();
                result.Error.ErrorMessage = ex.Message;
                result.Error.Description = ex.Message;
                result.CorrelationId = messageId;
                return result;
            }
        }



        public async Task<Message<Contact>> LoadContacts()
        {

            string messageId = Guid.NewGuid().ToString();
            Message<Contact> result = new Message<Contact>();
            List<Contact> contacts = new List<Contact>();

            //this should be saved  in application insights! or in a blob storage
            _logger.LogInformation(string.Format("{0} : {1} is called for loading contacts.", messageId, "AcmeWidget.Service.RegistrationService.LoadContacts"));

            try
            {

                //We can put any filtrations here like... paging or date
                var applicantsQuery = _db.Applicants.Select(a => new Contact()
                {
                    Activity = a.Activity.Trim(),
                    Comments = a.Comments,
                    EmailAddress = a.EmailAddress,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    ModifiedDate = a.DateModified.ToString()
                });

                contacts = await applicantsQuery.ToListAsync();


               


                // this should be saved based in application insights!or in a blob storage
                _logger.LogInformation(string.Format("{0} : data is successfully loaded", messageId));

                result.IsSuccess = true;
                result.DataList = contacts;
                result.CorrelationId = messageId;

                return result;

            }
            catch (Exception ex)
            {

                // this should be saved based in application insights!or in a blob storage
                _logger.LogInformation(string.Format("{0} : {1} is called for loading contacts. The Error is : {2}", messageId, "AcmeWidget.Service.RegistrationService.LoadContacts", ex.Message));
                _logger.LogInformation(string.Format("{0} : {1} is called for loading contacts. The Error Details is : {2}", messageId, "AcmeWidget.Service.RegistrationService.LoadContacts", ex.InnerException));
                result.IsSuccess = false;
                result.Error = new Error();
                result.Error.ErrorMessage = ex.Message;
                result.Error.Description = ex.Message;
                result.CorrelationId = messageId;
                return result;
            }
        }

     
    }
}
