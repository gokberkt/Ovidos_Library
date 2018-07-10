using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.EntityLayer
{
    public class BookTransaction
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "INT")]
        public int BookID { get; set; }
        [Column(TypeName = "INT")]
        public int UserID { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime DateOfReserved { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime ExpirationOfReserveDate { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime? DateOfReturned { get; set; }
        [Column(TypeName = "INT")]
        public BookTransactionStatus Status { get; set; }


        public virtual Book Book { get; set; }
        public virtual User User{ get; set; }
    }
}
