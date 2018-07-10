using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.EntityLayer
{
    public class Book
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Publisher { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Author { get; set; }
        [Column(TypeName = "INT")]
        public int? PublicationDate { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Language { get; set; }
        [Column(TypeName = "INT")]
        public int? PrintLength { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string ISBN { get; set; }

        public virtual List<BookStock> BookStocks{ get; set; }
}
}
