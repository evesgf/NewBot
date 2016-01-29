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
            var dt = nh.Select(sqlstr);
            var users=new UsersModel();
            users.UserName= dt.Rows[0].ItemArray[1].ToString();
            return users.UserName;
        }

        public int Create()
        {
            var sqlstr = "INSERT INTO `newbot`.`users` (`Id`, `UserName`, `PassWord`, `CreateTime`, `ModifyTime`) VALUES ('1', 'newusers', '1234556', '1', '1');";
            var res = nh.CUD(sqlstr);
            return res;
        }

        public int Update()
        {
            var sqlstr = "UPDATE `users` SET `UserName`=[newuser],`PassWord`=[123],`CreateTime`=[1],`ModifyTime`=[1] WHERE Id='1'";
            var res = nh.CUD(sqlstr);
            return res;
        }

        public int Delete()
        {
            var sqlstr = "DELETE FROM `users` WHERE Id='1'";
            var res = nh.CUD(sqlstr);
            return res;
        }
    }
}
