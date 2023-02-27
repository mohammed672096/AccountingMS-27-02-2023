using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassib.HR.Classes
{
    public static  class Settings
    {
        public static string ConnectionString { get; set; } = @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Hassib.Controller.DataContext;integrated security=True;MultipleActiveResultSets=True;pooling=true;connection lifetime=120;max pool size=2500;;App=EntityFramework";
    }
}
