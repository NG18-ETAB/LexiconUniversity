using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconUniversity.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int StudentId { get; set; }

        // Navigational properties
        public virtual Student Student { get; set; }

    }
}