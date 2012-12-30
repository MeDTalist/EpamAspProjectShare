namespace EpamAspProject.Types
{
    public class RichUser
    {
        public string EMail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public RichUser Clone()
        {
            return new RichUser
                       {
                           EMail = this.EMail,
                           IsAdmin = this.IsAdmin,
                           Login = this.Login,
                           Password = this.Password
                       };
        }
    }
}