using DataAccess.Controllers;
using DataAccessAPI.Models;
using Org.BouncyCastle.Asn1.X509;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UserService
{
    public class UserServiceUtil
    {
        UserMapper usersMapper = new UserMapper();
        public int Login(Users user)
        {
            ArrayList targets = usersMapper.SelectByUserName(user.UserName);
            if (targets.Count == 0)
            {
                return -2;
            }
            Users target = (Users)targets[0];
            if (target.UserName == user.UserName && target.Pwd == user.Pwd)
            {
                return target.UserId;
            }
            return -1;
        }

        //Logout:之后在controller层直接操作session实现

        public Response Register(Users user)
        {
            Response response = new Response();
            ArrayList targets = usersMapper.SelectByUserName(user.UserName);
            if (targets.Count > 0)
            {
                response.status = "500";
                response.error = "This user name has been taken";
                return response;
            }
            user.UserId = 1000000;
            usersMapper.Insert(user);
            targets = usersMapper.SelectByUserName(user.UserName);
            Users target = (Users)targets[0];
            response.status = "200";
            response.error = "Register Success!";
            response.result.Add(target.UserId);
            return response;
        }

        public Response UpdateInfo(Users user)
        {
            Response response = new Response();

            usersMapper.UpdateByPrimaryKeySelective(user);
            response.status = "200";
            response.error = "Update Success!";
            return response;
        }

        //UpdateAvatar:文件流

        public Response getAddress(int userId)
        {
            Response response = new Response();
            Users target = usersMapper.SelectByPrimaryKey(userId);
            String allAddress = target.Address;
            if(allAddress == null)
            {
                response.status = "200";
                return response;
            }
            String[] seperateAddresses = allAddress.Split('%');
            foreach(var a in seperateAddresses)
            {
                response.result.Add(a);
            }
            response.status = "200";
            return response;
        }

        public Response UpdateAddress(ArrayList addresses, int userId)
        {
            Response response = new Response();
            Users target = usersMapper.SelectByPrimaryKey(userId);
            String all = (String)addresses[0];
            for(int i = 1; i < addresses.Count; i++)
            {
                all = all + '%' + (String)addresses[i];
            }
            target.Address = all;
            usersMapper.UpdateByPrimaryKeySelective(target);
            response.status = "200";
            return response;
        }


    }
}
