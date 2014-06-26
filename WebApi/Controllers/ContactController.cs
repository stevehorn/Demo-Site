using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using WebApi.Services;
using WebApi.Models;




namespace WebApi.Controllers
{
    public class ContactController : ApiController
    {
        private HttpRequest _request = HttpContext.Current.Request;
        private ContactRepository repository;

        public ContactController()
        {
            repository = new ContactRepository();
        }
        public IList<Contact> Get()
        {
            return repository.GetAllContacts();
        }

        public bool Put(Contact contact)
        {
            return repository.UpdateContact(contact);
        }

        public HttpResponseMessage Post(int Id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            Contact contact = new Contact();
            contact.Id = Id;
            contact.LName = string.IsNullOrEmpty(_request["LName"]) ? contact.LName : _request["LName"];
            contact.FName = string.IsNullOrEmpty(_request["FName"]) ? contact.LName : _request["FName"];
            contact.Company = string.IsNullOrEmpty(_request["Company"]) ? contact.Company : _request["Company"];
            contact.Company = string.IsNullOrEmpty(_request["Region"]) ? contact.Region : _request["Region"];
            bool updateOK = repository.UpdateContact(contact);
            if (updateOK)
            {
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent(string.Format("The employee with id {0} was not found in the database", Id.ToString()));
            }
            return response;
        }
    }
}