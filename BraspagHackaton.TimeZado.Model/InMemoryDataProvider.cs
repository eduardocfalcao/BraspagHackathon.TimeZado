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
    
            if (tables.ContainsKey(typeof(T)) == false)
                return Enumerable.Empty<T>().ToList();

            return tables[typeof(T)].Cast<T>().ToList();
        }


        public void Insert(object obj)
        {
            if(tables.ContainsKey(obj.GetType()) == false)
            {
                tables[obj.GetType()] = new List<object>(); ;
            }
            var table = tables[obj.GetType()];
            table.Add(obj);
        }

        public void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}