using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Content
    {
        public int Id { get; set; }
        public string BodyText { get; set; }
        public DateTime CreatedAt { get; set; }


        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
