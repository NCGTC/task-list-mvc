using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskListMvc.Web.Infrastructure
{
    public abstract class StandardController : Controller
    {
        protected StandardJsonResult JsonSuccess(object data)
        {
            return new StandardJsonResult() { Data = data };
        }

        protected StandardJsonResult JsonError(string errorMessage)
        {
            return new StandardJsonResult() { ErrorMessage = errorMessage };
        }
    }
}