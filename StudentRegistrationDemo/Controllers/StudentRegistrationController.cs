using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentRegistrationDemo2.Models
{
    public class StudentRegistrationController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public StudentRegistrationReply registerStudent(Student studentregd)
        {
            Console.WriteLine("In registerStudent");
            StudentRegistrationReply stdregreply = new StudentRegistrationReply();
            StudentRegistration.getInstance().Add(studentregd);
            try
            {
                stdregreply.Name = studentregd.Name;
                stdregreply.Age = studentregd.Age;
                stdregreply.RegistrationNumber = studentregd.RegistrationNumber;
                stdregreply.RegistrationStatus = " Successful ";
                string logMessage = "StudentRegistration[Name:" + stdregreply.Name + ", Age:" + stdregreply.Age + ", RegistrationNumber:" + stdregreply.RegistrationNumber + ", RegistrationStatus:" + stdregreply.RegistrationStatus + "]";
                log.Info(logMessage);
                if (studentregd.Name == null)
                {
                    throw new NameIsNull();
                }
                else if  (studentregd.RegistrationNumber == null)
                {
                    throw new RegistrationNumberIsNull();
                }
                return stdregreply;
            }
            catch (NameIsNull name)
            {
                log.Warn(name.Message);
            }
            catch (RegistrationNumberIsNull rn)
            {
                log.Warn(rn.Message);
            }

            finally
            {
                //log.Info("dando sequencia");
            }
            return stdregreply;
        }
        
    }
}
