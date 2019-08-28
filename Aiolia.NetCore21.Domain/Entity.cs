using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aiolia.NetCore21.Domain
{
    public class BaseEntity : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public string CreateUser{ get; set; }

        public string LastUpdateUser { get; set; }
    }
}
