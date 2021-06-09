using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibrary.EFContext.Data
{
    [Table("tblBooks")]
    public class Book
    {
        [Key]
        public int  Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Author { get; set; }
        [Required, StringLength(4000)]
        public string Description { get; set; }
        public int Year { get; set; }
        
    }
}
