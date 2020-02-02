using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.gov.sg.Models
{
    public class CGraduates_From_University
    {
        public CGraduates_From_University()
        {
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public string Sex { get; set; }
        public string TypeOfCourse { get; set; }
        public int NoOfGraduates { get; set; }
    }
}