using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public Int32 UserId
        {
            get; set;
        }
        public String Username
        {
            get; set;
        }
        public String Password
        {
            get; set;
        }
        public String FacultyNumber
        {
            get; set;
        }
        public UserRoles Role
        {
            get; set;
        }
        public DateTime Created
        {
            get; set;
        }
        public DateTime? IsActiveUntil
        {
            get; set;
        }

        public User()
        {
        }

        public User(string username, string password, string facultyNumber, UserRoles role, DateTime created, DateTime isActiveUntil)
        {
            this.Username = username;
            this.Password = password;
            this.FacultyNumber = facultyNumber;
            this.Role = role;
            this.Created = created;
            this.IsActiveUntil = isActiveUntil;
        }

        override public String ToString()
        {
            return String.Format("Username: {0}\nPassword: {1}\nFaculty number: {2}\nRole: {3}\nCreated: {4}\nActive until: {5}\n",
                this.Username, this.Password, this.FacultyNumber, this.Role, this.Created, this.IsActiveUntil);
        }
    }
}
