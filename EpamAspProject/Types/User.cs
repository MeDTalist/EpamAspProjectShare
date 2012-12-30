using System;

namespace EpamAspProject.Types
{
    public class User
    {
        public String Login { get; set; }
        public String Password { get; set; }

        public User Clone()
        {
            return new User
                       {
                           Login = this.Login,
                           Password = this.Password
                       };
        }
    }
}