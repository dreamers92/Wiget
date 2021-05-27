using System;
using System.Collections.Generic;

#nullable disable

namespace AcmeWidget.Models
{
    public partial class Applicant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Activity { get; set; }
        public string Comments { get; set; }
        public DateTime DateModified { get; set; }
    }
}
