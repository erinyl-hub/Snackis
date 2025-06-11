using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Snackis.Models.Postings;

namespace Snackis.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SnackisUser class
public class SnackisUser : IdentityUser
{
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    //public ICollection<Models.Messages.Message> SentMessages { get; set; } = new List<Models.Messages.Message>();
    //public ICollection<Models.Messages.Message> ReceivedMessages { get; set; } = new List<Models.Messages.Message>();


    [PersonalData]
    public string Name { get; set; }

    [PersonalData]
    public string? UserImage { get; set; }
}

