namespace SNMedicTreatment.Models.Config
{
    public class AppConfig
    {
        public JwtConfig JwtConfig { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
            
    }

    public class JwtConfig
    {
        public string JwtSecret { get; set; }
    }

    public class ConnectionStrings
    {
        public string DataBase { get; set; }
    }
}
