using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Status { get; set; }

        // foreign key that relates this topic to a specific category.
        public int CategoryId { get; set; }
        //navigation property, allowing you to access the related Category object from a Topic object
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Entry> Contents { get; set; }


    }
}
