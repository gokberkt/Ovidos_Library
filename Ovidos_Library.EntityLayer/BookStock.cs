using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.EntityLayer
{
    public class BookStock
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "INT")]
        public int BookID { get; set; }
        [Column(TypeName = "INT")]
        public BookStockStatus Status { get; set; }

        public virtual Book Book{ get; set; }
}
}
