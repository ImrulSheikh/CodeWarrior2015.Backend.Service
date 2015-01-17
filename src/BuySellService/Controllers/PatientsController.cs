using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientData.Controllers
{
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
