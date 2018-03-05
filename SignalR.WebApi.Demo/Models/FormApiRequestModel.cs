using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SignalR.WebApi.Demo.Models
{
    public partial class FormApiRequestModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Title")]
        [Required]
        public string Title { get; set; }

        [JsonProperty("Description")]
        [Required]
        public string Description { get; set; }

        [JsonProperty("Content")]
        [Required]
        public string Content { get; set; }

        [JsonProperty("CreateTime")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [JsonProperty("Users")]
        public List<Users> Users { get; set; }
    }

    public partial class Users
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}