using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace StudentRegistrationDemo2.Models
{
    public class StudentRetrieveController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<Student> GetAllStudents()
        {
            string json = JsonConvert.SerializeObject(StudentRegistration.getInstance().getAllStudent(), Formatting.Indented);
            log.Debug(" Retrieving student information " + json);
            return StudentRegistration.getInstance().getAllStudent();
        }
    }
}
