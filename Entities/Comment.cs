using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniApp1.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AssignmentId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }

        public Assignment Assignment { get; set; }
        public User User { get; set; }

    }
}
