using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class User
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// The group that the user belongs to (Admin or Bidder)
        /// </summary>
        public UserGroup UserType { get; }

        /// <summary>
        /// ID of the User
        /// </summary>
        public int UserID { get; }

        public User(string user, string pass, UserGroup userType, int userID)
        {
            this.Username = user;
            this.Password = pass;
            this.UserID = userID;
            this.UserType = userType;
        }

        /// <summary>
        /// Overwritten for easy file I/O
        /// </summary>
        /// <returns>a formatted string for use in FilIO</returns>
        public override string ToString()
        {
            //sets string to 'Bidder' if bidder, 'Admin' if admin, had to add the throw arg at the end so vs would stop being angry at me, realistically will never be thrown
            string type = this.UserType == UserGroup.Bidder ? "Bidder" : this.UserType == UserGroup.Admin ? "Admin" : throw new ArgumentOutOfRangeException();
            return this.Username + ":" + this.Password + ":" + type + ":" + this.UserID;
        }
    }
}
