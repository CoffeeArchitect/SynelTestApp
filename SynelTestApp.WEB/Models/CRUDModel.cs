﻿namespace SynelTestApp.WEB.Models
{
    public class CRUDModel<T> where T : class
    {
        public string action { get; set; }

        public string table { get; set; }

        public string keyColumn { get; set; }

        public int key { get; set; }

        public T value { get; set; }

        public List<T> added { get; set; }

        public List<T> changed { get; set; }

        public List<T> deleted { get; set; }

        public IDictionary<string, object> @params { get; set; }
    }
}
