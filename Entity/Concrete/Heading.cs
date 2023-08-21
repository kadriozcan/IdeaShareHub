using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Heading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        // foreign key that relates this heading to a specific category.
        public int CategoryId { get; set; }
        //navigation property, allowing you to access the related Category object from a Heading object
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }


    }
}
