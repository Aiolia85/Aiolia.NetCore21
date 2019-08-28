using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aiolia.NetCore21.Domain
{
    [Table("UserInfo")]
    public class UserInfo:BaseEntity
    {
        public string Name { get; set; }
    }
}
