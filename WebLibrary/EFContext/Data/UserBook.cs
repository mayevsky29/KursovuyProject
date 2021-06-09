using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.EFContext.Identity;

namespace WebLibrary.EFContext.Data
{
    [Table("tblUserBooks")]
    public class UserBook
    {
        public long BookId { get; set; }
        public virtual Book Book { get; set; }
        public long UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
