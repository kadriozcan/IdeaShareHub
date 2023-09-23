using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1000)]
        public string BodyText { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Status { get; set; }

        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    } 
}
