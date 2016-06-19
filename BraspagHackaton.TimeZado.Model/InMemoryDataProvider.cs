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
    public class InMemoryDataProvider
    {
        private InMemoryDataProvider()
        {
            tables = new Dictionary<Type, List<Object>>();
        }

        public static InMemoryDataProvider GetDataProvider()
        {
            return new InMemoryDataProvider();
        }

        private Dictionary<Type, List<object>> tables;
        
        public List<T> Read<T>() where T : new()
        {
            var table = tables[typeof(T)];
            if (table == null)
                return Enumerable.Empty<T>().ToList();

            return table.Cast<T>().ToList();
        }


        public void Insert(object obj)
        {
            var table = tables[obj.GetType()];
            if(table == null)
            {
                table = new List<object>();
                tables[obj.GetType()] = table;
            }
            table.Add(obj);
        }

        public void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}