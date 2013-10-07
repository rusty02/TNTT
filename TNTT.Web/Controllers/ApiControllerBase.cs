using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using TNTT.Data;
using TNTT.Data.Contracts;
using TNTT.Data.Helpers;

namespace TNTT.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        public TNTTUow uow;

        protected ApiControllerBase()
        {
            uow = new TNTTUow(new RepositoryProvider(new RepositoryFactories()));
        }
    }
}