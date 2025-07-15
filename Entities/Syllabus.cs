using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniApp1.Entities
{
    public class Syllabus
    {
        public int SyllabusId { get; set; }
        public string Description { get; set; }

        public Course Course { get; set; }
    }
}
