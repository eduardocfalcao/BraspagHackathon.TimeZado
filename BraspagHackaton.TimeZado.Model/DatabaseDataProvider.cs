using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;
using BraspagHackathon.TimeZado.Model.Entities;
using Android.Database.Sqlite;

namespace BraspagHackaton.TimeZado.Model
{
    public class DatabaseDataProvider
    {
        public DatabaseDataProvider(string dbName)
        {
            this.dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);
        }

        public const string DBName = "timezado.db";

        public static DatabaseDataProvider GetDataProvider()
        {
            return new DatabaseDataProvider(DBName);
        }

        private readonly string dbPath;

        public void InitDatabase()
        {
            var database =  SQLiteDatabase.OpenDatabase(dbPath, null, DatabaseOpenFlags.CreateIfNecessary);
            database.Close();

            var db = new SQLiteConnection(dbPath);
            
            if(db.Execute("SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = 'CreditCard'") == 0)
                db.CreateTable<CreditCard>();

            if (db.Execute("SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = 'Merchant'") == 0)
                db.CreateTable<Merchant>();

            if (db.Execute("SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = 'GlobalConfiguration'") == 0)
                db.CreateTable<GlobalConfiguration>();
        }

        public void DropAllTables()
        {
            var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            db.DropTable<CreditCard>();
            db.DropTable<Merchant>();
            db.DropTable<GlobalConfiguration>();
        }

        public T Get<T>(object key) where T : new()
        {
            var db = new SQLiteConnection(dbPath);
            return db.Get<T>(key);
        }

        public IEnumerable<T> Read<T>() where T : new()
        {
            var db = new SQLiteConnection(dbPath);
            return db.Table<T>();
        }

        public IEnumerable<T> Query<T>(string query) where T : new()
        {
            var db = new SQLiteConnection(dbPath);
            return db.Query<T>(query);
        }

        public void Insert(object obj)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(obj);
        }

        public void Update(object obj)
        {
            var db = new SQLiteConnection(dbPath);
            db.Update(obj);
        }

        public void Delete<T>(object key)
        {
            var db = new SQLiteConnection(dbPath);
            db.Delete<T>(key);
        }
    }
}