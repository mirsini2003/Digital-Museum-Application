using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ergasia_alilepidrasi
{
    public class User
    {
        private string name;
        private string password;
        private string role;
        public User(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        
        public string Name   // property
        {
            get { return name; }   // get method
            set { name = value; }  // set method
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

    }
}
