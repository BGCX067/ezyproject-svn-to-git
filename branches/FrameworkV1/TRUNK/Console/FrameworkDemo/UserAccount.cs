using System.Collections.Generic;

namespace FrameworkDemo
{
    public class UserAccount
    {

        public virtual string Username { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual int Id { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Id, Username, Email);
        }

        public virtual Department Department { get; set; }        
    }

    public class Department
    {
        public virtual int Id { get; set; }
        public virtual string DepartmentName { get; set; }
        public virtual IList<UserAccount> Users { get; set; }
    }
}