using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace AccountingMS
{
    public class ClsTestDBConnection
    {
        SqlConnectionStringBuilder sqlBuilder;
        EntityConnectionStringBuilder entityBuilder;

        public ClsTestDBConnection(string serverName = null)
        {
            if (serverName == null) return;

            InitSqlBuilder(serverName);
            InitEntityBuilder();
        }

        private void InitSqlBuilder(string serverName)
        {
            this.sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = serverName,
                InitialCatalog = "accounting",
                IntegratedSecurity = true
            };
        }

        private void InitEntityBuilder()
        {
            entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = this.sqlBuilder.ConnectionString,
                Metadata = @"res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl"
            };
        }

        public bool TestConnection(string connectionString = null)
        {
            return TestConnectionString((connectionString == null) ? this.entityBuilder.ConnectionString : connectionString);
        }

        private bool TestConnectionString(string connectionString)
        {
            try
            {
                using (EntityConnection entityConnection = new EntityConnection(connectionString))
                {
                    entityConnection.Open();
                    Console.WriteLine("Just testing the connection.");
                    entityConnection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
