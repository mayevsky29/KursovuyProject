using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.EFContext.Data;

namespace WebLibrary.EFContext.Identity
{
    public class AppUser : IdentityUser<long>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
        public virtual ICollection<UserBook> UserBooks { get; set; }
    }
}
