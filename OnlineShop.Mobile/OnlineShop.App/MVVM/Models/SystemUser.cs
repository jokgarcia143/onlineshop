using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.MVVM.Models
{
    [Table("SystemUsers")]
    public class SystemUser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("user_name"), NotNull]
        public string UserName { get; set; }

        [Column("password"), NotNull]
        public string Password { get; set; }

        [Column("role"), NotNull]
        public int Role { get; set; }
    }
}
