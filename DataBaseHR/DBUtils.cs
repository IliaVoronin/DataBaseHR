﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseHR
{


    public class DBUtils
    {

        public static void ExecuteCommand(string cmdString)
        {
            using (var connection = CreateConnectionTest())
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdString;
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static OleDbConnection CreateConnection(string provider, string datasource, string security, string catalog)
        {
            return new OleDbConnection("Provider=" + provider + ";Data Source=" + datasource +
                ";Integrated Security=" + security + ";Initial Catalog=" + catalog);
        }

        public static OleDbConnection CreateConnectionTest()
        {
            return new OleDbConnection("Provider=MSOLEDBSQL.1;Data Source=188.134.88.224;Initial Catalog=HRD;User ID=sa;Password=Adminadmin1234;");
        }

        public static List<object[]> Select(string cmdString)
        {
            List<Object[]> o = new List<Object[]>();
            using (var connection = CreateConnectionTest())
            {
                OleDbCommand select = new OleDbCommand();
                select.Connection = connection;
                select.CommandText = cmdString;
                connection.Open();

                OleDbDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    for (var i = 0; i < reader.FieldCount; i++) data[i] = reader[i];
                    o.Add(data);
                }
            }
            return o;

        }

        public static void Fill(DataGridView gridView, List<Object[]> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                gridView.Rows.Add();
                for (int j = 0; j < gridView.ColumnCount; j++)
                {
                    gridView.Rows[i].Cells[j].Value = item[j];
                }
                i++;
            }
        }

        public static int countRows(string countBy, string table)
        {
            var c = Select(String.Format("SELECT {0} FROM {1};", countBy, table));
            int result = c.Count;
            return result;
        }

        public static bool CheckForLogin(string login)
        {
            var loginTable = Select(String.Format("SELECT userLogin FROM userTable WHERE userLogin ='{0}'", login));
            int num = loginTable.Count;

            return (num != 0);
        }
    }
}
