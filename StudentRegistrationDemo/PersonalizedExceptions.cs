using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public class NameIsNull : Exception
    {
        public NameIsNull() : base("Name is NULL") { }

        public NameIsNull(string message) : base(message) { }
    }

    public class RegistrationNumberIsNull : Exception
    {
        public RegistrationNumberIsNull() :base("Registration Number is NULL") { }

        public RegistrationNumberIsNull(string message) : base(message) { }
    }
}