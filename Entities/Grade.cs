using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniApp1.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public int NumGrade { get; set; }

        public Assignment Assignment { get; set; }
        public User User { get; set; }
    }
}
