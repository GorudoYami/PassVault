using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault {
    public class SQLiteDB {
        private string fileName;
        public SQLiteDB(string fileName) {
            this.fileName = fileName;
        }

        private DbConnection GetConnection() =>
            new SqliteConnection("Data Source=" + fileName);

        public bool Setup() {
            using var connection = GetConnection();
            try {
                connection.Open();
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}
