using System.Collections.Generic;
using TNTT.Data.Contracts;
using TNTT.Model;

namespace TNTT.Web.Controllers
{
    public class ValuesController : ApiControllerBase
    {
        public IEnumerable<Contact> Get()
        {
            return uow.Contacts.GetAll();
        }
        
    }
}