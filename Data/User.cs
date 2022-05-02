using System;
using System.Collections.Generic;

#nullable disable

namespace RPGCharacterBuilderMVC.Data
{
    public partial class User
    {
        public User()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string GamerTag { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
