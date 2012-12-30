namespace EpamAspProject.DataAccessor
{
    public class DataBasic
    {
        public static string GetConnectionString()
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["EpamProgectDB"].ConnectionString;
            //return "Data Source=(local);Initial Catalog=EpamProgectDB;Integrated Security=True";
        }
    }
}