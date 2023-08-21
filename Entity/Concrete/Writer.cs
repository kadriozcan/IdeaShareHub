using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Password { get; set; }

        public ICollection<Topic> Topics { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
