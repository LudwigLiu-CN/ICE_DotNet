using DataAccess.Controllers;
using DataAccessAPI.Models;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UserService
{
    class UserServiceUtil
    {
        UserMapper usersMapper = new UserMapper();
        public int Login(Users user)
        {
            ArrayList targets = usersMapper.SelectByUserName(user.UserName);
            Users target = (Users)targets[0];
            if (target.UserName == user.UserName && target.Pwd == user.Pwd)
            {
                return target.UserId;
            }
            return -1;
        }
    }
}
