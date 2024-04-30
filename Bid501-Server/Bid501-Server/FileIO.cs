using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class FileIO
    {
        private string userFileName;
        private string prodFileName;
        private ProductDatabase pd;

        /// <summary>
        /// an object for simple file io
        /// </summary>
        /// <param name="fn">the filename or path to the file</param>
        public FileIO(string un, string pn)
        {
            userFileName = un;
            prodFileName = pn;
        }

        /// <summary>
        /// Reads in all registered users from a file
        /// </summary>
        /// <returns>A dictionary containing the user/userid combinations</returns>
        /// <exception cref="Exception">Thrown if the filename is invalid</exception>
        public Dictionary<User, int> ReadUsersFromFile()
        {
            Dictionary<User, int> users = new Dictionary<User, int>();


            try
            {
                using(StreamReader sr = new StreamReader(userFileName))
                {
                    string line;
                    string user;
                    string pass;
                    int userID;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if(parts.Length == 4)
                        {
                            user = parts[0];
                            pass = parts[1];
                            UserGroup userType;

                            switch (parts[2])
                            {
                                case "Admin":
                                    userType = UserGroup.Admin;
                                    break;
                                default:
                                    userType = UserGroup.Bidder;
                                    break;
                            }

                            userID = int.Parse(parts[3]);

                            User u = new User(user, pass, userType, userID);

                            users[u] = userID;
                        }

                        
                    }
                }
            } catch(IOException e)
            {
                throw new Exception("Couldn't find / read the file specified in fileName");
            }

            return users;
        }

        /// <summary>
        /// Prints the current Dictionary of users to the file
        /// </summary>
        /// <param name="users">All registered users from UserDatabase</param>
        /// <exception cref="Exception"></exception>
        public void PrintCredsToFile(Dictionary<User, int> users)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(userFileName))
                {
                    foreach (var kp in users)
                    {
                        sw.WriteLine(kp.Key.ToString());
                    }
                }
            }catch(IOException e)
            {
                throw new Exception("Couldn't find / write to the file specified in fileName");
            }
        }

        /// <summary>
        /// Reads in all products from the file, adds them to the product list in ProductManager
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ReadProductFromFile()
        {
            List<Product> prods = new List<Product>();

            try
            {
                using (StreamReader sr = new StreamReader(prodFileName))
                {
                    string line;

                    string name;
                    string desc;
                    decimal price;

                    while((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if(parts.Length == 3)
                        {
                            name = parts[0];
                            desc = parts[1];
                            price = Decimal.Parse(parts[2]);

                            Product p = new Product(name, desc, price);

                            pd.AddProduct(p);
                        }
                    }
                }
            } catch(IOException ex)
            {
                throw new Exception("Could not find the specified file.");
            }
        }

        /// <summary>
        /// Prints all product information to the a file.
        /// </summary>
        /// <param name="p">The list of all the products</param>
        /// <exception cref="Exception"></exception>
        public void PrintProductToFile(Dictionary<Product, int> p)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(prodFileName))
                {
                    foreach(var kp in p)
                    {
                        sw.WriteLine(kp.Key.ToFileString());
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception("Could not find the specified file.");
            }
        }
    }
}
