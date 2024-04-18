using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class UserDatabase
    {
        /// <summary>
        /// All users that are active now
        /// </summary>
        private List<User> activeUsers = new List<User>();

        /// <summary>
        /// Dictionary containing all valid Users along with their ID
        /// </summary>
        private Dictionary<User, int> registeredUsers;

        private FileIO fio;

        /// <summary>
        /// Constructor for UserDatabase
        /// </summary>
        public UserDatabase()
        {
            registeredUsers = fio.ReadUsersFromFile();
        }

        /// <summary>
        /// Handles login attempts from clients and server administrators
        /// </summary>
        /// <param name="user">The attempted username</param>
        /// <param name="pass">The attempted password</param>
        /// <returns>0 for a valid login, -1 for an invalid login</returns>
        public int LoginAttempt(string user, string pass)
        {
            foreach(var kp in registeredUsers)
            {
                if(kp.Key.Username == user && !activeUsers.Contains(kp.Key))
                {
                    if(kp.Key.Password == pass)
                    {
                        return 0;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Handles a log out, currently just removes from active list, not sure if this needs to be something more 
        /// </summary>
        /// <param name="u">The user that is logging out</param>
        public void Logout(User u)
        {
            if (activeUsers.Contains(u))
            {
                activeUsers.Remove(u);
            }
        }
    }
}
