using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CodeComb.ChinaTelecom.Website.Models;

namespace CodeComb.ChinaTelecom.Website.Controllers
{
    public class BaseController : BaseController<User, CTContext, string>
    {
    }
}
