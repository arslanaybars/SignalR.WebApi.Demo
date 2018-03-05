using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalR.WebApi.Demo.Data
{
    public class Form
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Title { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        #region [ Navigation Properties ]

        public List<User> Users { get; set; }

        #endregion

    }
}