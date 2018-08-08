using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace CoreSqLite
{
    public class SqlLiteUpdateRepository : IDisposable
    {
        private SQLiteConnection _sqLiteConnection;
        private bool _disposed;
        private const string DbName = "MyDataBase.sqlite";

        public SqlLiteUpdateRepository()
        {
            
            EnsureDbExists();
        }

        public void InsertBsd(IEnumerable<MyEntity> myEntitys)
        {
            _sqLiteConnection.Execute(@"INSERT INTO MyEntity 
                                        (MyEntityNum, MyEntityDate, MyEntityLibelle)
                                        VALUES (@MyEntityNum, @MyEntityDate, @MyEntityLibelle)", myEntitys);
        }

        private void EnsureDbExists()
        {
            _sqLiteConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3", DbFile));

            _sqLiteConnection.Open();

            _sqLiteConnection.Execute(@"CREATE TABLE IF NOT EXISTS MyEntity
              (
                 Id                          integer primary key AUTOINCREMENT,
                 MyEntityNum                 integer,
                 MyEntityDate                datetime not null,
                 MyEntityLibelle             varchar(100)
                 
              )");
        }



        private static string DbFile
        {
            get { return Path.Combine(Environment.CurrentDirectory, DbName); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (!disposing) return;

            if (_sqLiteConnection != null)
            {
                _sqLiteConnection.Dispose();
                _sqLiteConnection = null;
            }
            _disposed = true;
        }
    }

    public class MyEntity
    {
        public int MyEntityNum { get; set; }
        public DateTime MyEntityDate { get; set; }
        public string MyEntityLibelle { get; set; }
        
    }
}