using BuySell.EntityModels;
using EShopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EShopper.Controllers
{
    [EnableCors("*","*","GET")]
    [Authorize]
    public class PatientsController : ApiController
    {
        public PatientsController()
        {

        }
        public List<Patient> Get()
        {
            return PatientDb.GetGata();
        }
    }
}
