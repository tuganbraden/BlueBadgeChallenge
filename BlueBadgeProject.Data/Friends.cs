﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Data
{
    public class Friends
    {
        [Required]
        public string MyUserId { get; set; }
        [Required]
        public string FriendUserId { get; set; }
        [Key]
        public int ID { get; set; }
        public Friends(string myUserId, string friendUserId)
        {
            MyUserId = myUserId;
            FriendUserId = friendUserId;           
        }
        public Friends()
        {
        }
    }
}
