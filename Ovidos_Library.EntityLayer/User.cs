using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.EntityLayer
{
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Username { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual List<Log> Logs { get; set; }
        public virtual List<BookTransaction> BookTransactions { get; set; }
    }
}
