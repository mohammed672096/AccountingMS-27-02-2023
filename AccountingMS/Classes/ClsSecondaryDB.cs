using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace accounting_1._0
{
    public class ClsSecondaryDB
    {
        SqlConnectionStringBuilder sqlBuilder;
        EntityConnectionStringBuilder entityBuilder;

        private string serverName, userId, password;
        
        public ClsSecondaryDB(string serverName, string userId, string password)
        {
            SetStrings(serverName, userId, password);
            InitSqlBulider();
            InitEntityBuilder();
        }

        private void SetStrings(string serverName, string userId, string password)
        {
            this.serverName = serverName;
            this.userId = userId;
            this.password = password;
        }

        private void InitSqlBulider()
        {
            this.sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = this.serverName,
                InitialCatalog = "accounting",
                IntegratedSecurity = false,
                UserID = this.userId,
                Password = this.password
            };
        }

        private void InitEntityBuilder()
        {
            this.entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = this.sqlBuilder.ConnectionString,
                Metadata = @"res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl"
            };
        }

        protected internal bool TestConnectionString()
        {
            if (string.IsNullOrWhiteSpace(serverName) || string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password)) return false;

            try
            {
                using (EntityConnection entityConnection = new EntityConnection(this.entityBuilder.ConnectionString))
                {
                    entityConnection.Open();
                    Console.WriteLine("Just testing the connection.");
                    entityConnection.Close();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
