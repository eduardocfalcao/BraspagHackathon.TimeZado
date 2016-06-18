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
using SQLite;

namespace BraspagHackathon.TimeZado.Model.Entities
{
    public class GlobalConfiguration
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Key { get; set; }

        public string Value { get; set; }
    }

    public class GlobalConfigurationKeys
    {
        public const string CostumerId = "CostumerId";
    }
}