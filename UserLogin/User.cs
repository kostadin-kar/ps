using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public string username
        {
            get; set;
        }
        public string password
        {
            get; set;
        }
        public string facultyNumber
        {
            get; set;
        }
        public UserRoles role
        {
            get; set;
        }
        public DateTime created
        {
            get; set;
        }
        public DateTime isActiveUntil
        {
            get; set;
        }

        public User()
        {
        }

        public User(string username, string password, string facultyNumber, UserRoles role, DateTime created, DateTime isActiveUntil)
        {
            this.username = username;
            this.password = password;
            this.facultyNumber = facultyNumber;
            this.role = role;
            this.created = created;
            this.isActiveUntil = isActiveUntil;
        }

        override public String ToString()
        {
            return String.Format("Username: {0}\nPassword: {1}\nFaculty number: {2}\nRole: {3}\nCreated: {4}\nActive until: {5}\n",
                this.username, this.password, this.facultyNumber, this.role, this.created, this.isActiveUntil);
        }
    }
}
