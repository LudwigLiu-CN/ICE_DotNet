using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1;

namespace DataAccess.Controllers
{
    public class UserMapper : ControllerBase
    {
        iceContext iceContext_ = new iceContext();

        public Users SelectByPrimaryKey(int id)
        {
            Users target = iceContext_.Users.Find(id);
            return target;
        }

        public void DeleteByPrimaryKey(int id)
        {
            Users target = iceContext_.Users.Find(id);
            iceContext_.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(Users user)
        {
            iceContext_.Add(user);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKey(Users user)
        {
            iceContext_.Update(user);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKeySelective(Users user)
        {
            Users target = iceContext_.Users.Find(user.UserId);
            if (user.UserName != null)
            {
                target.UserName = user.UserName;
            }
            if (user.Gender != null)
            {
                target.Gender = user.Gender;
            }
            if (user.Birthday != null)
            {
                target.Birthday = user.Birthday;
            }
            if (user.Tel != null)
            {
                target.Tel = user.Tel;
            }
            if (user.AvatarPath != null)
            {
                target.AvatarPath = user.AvatarPath;
            }
            if (user.Address != null)
            {
                target.Address = user.Address;
            }
            if (user.Pwd != null)
            {
                target.Pwd = user.Pwd;
            }

            iceContext_.Users.Update(target);
            iceContext_.SaveChanges();
        }

        public ArrayList SelectByUserName(String name)
        {
            var targets = from u in iceContext_.Users where u.UserName == name select u;
            ArrayList results = new ArrayList();
            foreach(var u in targets)
            {
                results.Add(u);
            }
            return results;
        }

        //精确匹配
        public ArrayList SelectUser(Users user)
        {
            var targets = from u in iceContext_.Users
                          where u.UserId == user.UserId
                          where u.UserName == user.UserName
                          where u.Pwd == user.Pwd
                          where u.Gender == user.Gender
                          where u.Birthday == user.Birthday
                          where u.Tel == user.Tel
                          where u.Address == user.Address
                          select u;
            ArrayList results = new ArrayList();
            foreach(var u in targets)
            {
                results.Add(u);
            }
            return results;
        }

    }
}
