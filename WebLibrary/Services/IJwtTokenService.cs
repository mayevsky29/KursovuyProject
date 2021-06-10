using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.EFContext.Identity;

namespace WebLibrary.Services
{
   public interface IJwtTokenService
    {
        string CreateToken(AppUser user);
    }
}
