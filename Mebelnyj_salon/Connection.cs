using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mebelnyj_salon
{
    class Connection
    {
        string conStr = @"Data Source=10.10.1.24;Initial Catalog=GNEMebelnyjSalon;User ID=pro-41;Password=Pro_41student"; //Строка подключения к базе данных
        public SqlConnection Connect() //Метод для подключения
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = conStr;
            return connection;
        }

    }
}
