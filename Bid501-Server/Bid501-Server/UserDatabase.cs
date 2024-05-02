using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Dictionary<User, int> registeredUsers = new Dictionary<User, int>();

        /// <summary>
        /// FileIO object for reading in / saving user credentials
        /// </summary>
        private FileIO fio;

        private int nextID;

        /// <summary>
        /// Constructor for UserDatabase
        /// </summary>
        public UserDatabase()
        {
            fio = new FileIO("users.txt", this);
            nextID = 1;
            fio.ReadUsersFromFile();
        }

        /// <summary>
        /// Handles login attempts from clients and server administrators
        /// </summary>
        /// <param name="user">The attempted username</param>
        /// <param name="pass">The attempted password</param>
        /// <param name="type">Determines the type of user, 0 for bidder, 1 for admin</param>
        /// <returns>returns userid for a valid login, -1 for valid user, invalid password, and 2 for a valid user/pass but already logged in</returns>
        public int LoginAttempt(string user, string pass, int type)
        {
            foreach(var kp in registeredUsers)
            {
                if(kp.Key.Username == user)
                {
                    if(kp.Key.Password == pass)
                    {
                        if (!activeUsers.Contains(kp.Key))
                        {
                            activeUsers.Add(kp.Key);
                            return kp.Key.UserID;
                        }

                        return kp.Key.UserID * -1;
                    }

                    return -1;
                }
            }

            UserGroup g;

            if(type == 1)
            {
                g = UserGroup.Admin;
            }
            else
            {
                g = UserGroup.Bidder;
            }

            //creates a new user in the case the provided user/pass does not exist. 
            User newUser = new User(user, pass, g, nextID);
            nextID++;
            activeUsers.Add(newUser);
            registeredUsers.Add(newUser, newUser.UserID);
            fio.PrintCredsToFile(registeredUsers);

            return newUser.UserID; //note: this was returning 0, should return new user ID - Aidan, 5/2
        }

        /// <summary>
        /// Handles a log out, currently just removes from active list, not sure if this needs to be something more 
        /// </summary>
        /// <param name="u">The user that is logging out</param>
        public void Logout(int userID)
        {
            User u = activeUsers.First(x => x.UserID == userID);

            if(u != null)
            {
                activeUsers.Remove(u);
            }
        }

        /// <summary>
        /// Adds a new User to the registered user list
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="pass">Password for the user</param>
        /// <param name="type">The type of user (admin/bidder)</param>
        public void AddUser(string name, string pass, UserGroup type)
        {
            User u = new User(name, pass, type, nextID);
            nextID++;
            registeredUsers.Add(u, u.UserID);
        }

        /// <summary>
        /// Returns a bindinglist of all active users for use within the gui
        /// </summary>
        /// <returns></returns>
        public BindingList<User> GetActiveUsers()
        {
            BindingList<User> bl = new BindingList<User>();

            foreach(var u in activeUsers)
            {
                bl.Add(u);
            }

            return bl;
        }
    }
}
