using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.

namespace Northwind.DataContext.SqlServer
{
    public static class NorthwindDbConnection
    {
        const string SQL_USR = "SQL_USR_VALUE";
        const string SQL_USR_VALUE = "sa";
        const string SQL_PWD = "SQL_PWD_VALUE";
        const string SQL_PWD_VALUE = "abc123";

        public static string ConnectionString()
        {
            //optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true;");

            SqlConnectionStringBuilder builder = new();

            Environment.SetEnvironmentVariable(SQL_USR, SQL_USR_VALUE);
            Environment.SetEnvironmentVariable(SQL_PWD, SQL_PWD_VALUE);

            builder.DataSource = @".\sqlexpress";  // "ServerName\InstanceName" e.g. @".\sqlexpress"
            builder.InitialCatalog = "";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;

            // Because we want to fail faster. Default is 15 seconds.
            builder.ConnectTimeout = 3;

            // If using Windows Integrated authentication.
            builder.IntegratedSecurity = true;

            // If using SQL Server authentication.
            builder.UserID = Environment.GetEnvironmentVariable(SQL_USR);
            builder.Password = Environment.GetEnvironmentVariable(SQL_PWD);

            return builder.ConnectionString;
        }
    }
}
