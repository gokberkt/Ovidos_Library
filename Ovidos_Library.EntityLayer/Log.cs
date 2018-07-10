using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.EntityLayer
{
    public class Log
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "INT")]
        public int UserID { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(250)]
        public string TransactionDescription { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime TransactionDate { get; set; }

        public virtual User User{ get; set; }
    }
}
