using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using WebApi.Services;
using WebApi.Models;




namespace WebApi.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository repository;

        public ContactController()
        {
            repository = new ContactRepository();
        }
        public IList<Contact> Get()
        {
            return repository.GetAllContacts();
        }
    }
}