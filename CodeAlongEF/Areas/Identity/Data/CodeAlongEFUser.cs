using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CodeAlongEF.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CodeAlongEFUser class
public class CodeAlongEFUser : IdentityUser
{
    [PersonalData]
    public int BirthYear { get; set; }
    
    [PersonalData]
    public string Name { get; set; }
}

