using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.WebApi.Demo.Data
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        // If something changing about related form
        // Admin user can get the updates in real time
        public bool IsAdmin { get; set; }

        #region [ Navigation Properties ]

        [JsonIgnore]
        public ICollection<Form> Forms { get; set; }

        #endregion
    }
}