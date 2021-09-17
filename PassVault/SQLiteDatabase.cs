using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassVault {
    public class SQLiteDatabase {
        public string Filename { get; private set; }
        public SQLiteDatabase(string filename) {
            Filename = filename;
        }

        private DbConnection GetConnection() =>
            new SqliteConnection("Data Source=" + Filename);

        private static bool TableExists(string table, DbConnection connection) {
            try {
                using var cmd = connection.CreateCommand();
                cmd.CommandText = "SHOW TABLES LIKE @Table";
                cmd.Parameters.Add(cmd.CreateParameter());
                cmd.Parameters[0].ParameterName = "@Table";
                cmd.Parameters[0].Value = table;

                using var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    return false;
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool Setup() {
            using var connection = GetConnection();
            try {
                connection.Open();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!TableExists("data", connection)) {
                using var cmd = connection.CreateCommand();
                cmd.CommandText = "";
                int r = cmd.ExecuteNonQuery();
                Debug.WriteLine(r);
                if (r == -1)
                    return false;
            }
            return true;
        }

        public bool Add() {
            throw new NotImplementedException();
        }

        public bool Remove() {
            throw new NotImplementedException();
        }

        public bool Update() {
            throw new NotImplementedException();
        }
    }
}
