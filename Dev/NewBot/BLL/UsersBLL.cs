using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBot.Common;
using NewBot.Models;

namespace NewBot.BLL
{
    public class UsersBLL : IUsersBLL
    {
        MySqlHelper nh=new MySqlHelper();

        public string Hello()
        {
            var sqlstr = "select * from users";
            var dt=nh.ExecuteQuery(sqlstr, CommandType.Text);
            var users=new UsersModel();
            users.UserName= dt.Rows[0].ItemArray[1].ToString();
            return users.UserName;
        }
    }
}
