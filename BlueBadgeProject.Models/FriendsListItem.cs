﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class FriendsListItem
    {
        [Key]
        public string MyUserId { get; set; }
        [Required]
        public string FriendUserId { get; set; }
        [Required]
        public string FriendsName { get; set; }
    }
}
