using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuySell.EntityModels;

namespace PatientData.Models
{
    public class PatientDb
    {
        public static List<Patient> GetGata()
        {
            var data = new List<Patient>();
            for (int i = 0; i < 3; i++)
            {
                data.Add(new Patient() { Id = "id" + i, Name = "Name_" + i });
            }
            return data;

        }
    }
}