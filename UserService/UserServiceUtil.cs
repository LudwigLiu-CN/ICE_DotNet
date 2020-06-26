﻿using DataAccess.Controllers;
using DataAccessAPI.Models;
using Org.BouncyCastle.Asn1.X509;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;
using HandleAddress;
using System.Runtime.InteropServices;

namespace UserService
{
    public class UserServiceUtil
    {
        [DllImport("tsetDll.dll")]
        public static extern void SetTable(string source);

        [DllImport("tsetDll.dll")]
        public static extern int Base64Encode(byte[] source, int lSource, StringBuilder target, int lTarget);

        [DllImport("tsetDll.dll")]
        public static extern int Base64Decode(string source, int lSource, byte[] target, int lTarget);

        [DllImport("tsetDll.dll")]
        public static extern int test_fun();

        public string Base64Encode_string(string input)
        {
            var baSrc = Encoding.UTF8.GetBytes(input);
            var lSrc = baSrc.Length;
            var lTgt = (lSrc + 2) / 3 * 4;
            var tgt = new StringBuilder(lTgt);
            var n = UserServiceUtil.Base64Encode(baSrc, lSrc, tgt, lTgt);
            if (n >= 0)
                return tgt.ToString(0, n);
            else
                return "-1";
        }


        UserMapper usersMapper = new UserMapper();
        public int Login(Users user)
        {
            ArrayList targets = usersMapper.SelectByUserName(user.UserName);
            if (targets.Count == 0)
            {
                return -2;
            }
            Users target = (Users)targets[0];
            if (target.UserName == user.UserName)
            {
                if(target.Pwd == Base64Encode_string(user.Pwd))
                {
                    return target.UserId;
                }
            }
            return -1;
        }

        //Logout:之后在controller层直接操作session实现
        public Response getUser(int userId)
        {
            Users user = usersMapper.SelectByPrimaryKey(userId);

            Response response = new Response();
            response.status = "200";
            response.result.Add(user);
            return response;
        }

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
            user.Pwd = Base64Encode_string(user.Pwd);
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

            if (user.Pwd != null)
            {
                user.Pwd = Base64Encode_string(user.Pwd);
            }

            usersMapper.UpdateByPrimaryKeySelective(user);
            response.status = "200";
            response.error = "Update Success!";
            return response;
        }

        public Response updateAvatar(String path, int userId)
        {
            Response response = new Response();

            Users user = usersMapper.SelectByPrimaryKey(userId);
            user.AvatarPath = path;
            usersMapper.UpdateByPrimaryKeySelective(user);

            response.status = "200";
            response.error = "Success!";
            return response;
        }

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
            /*
            sbyte[] sbArray = (sbyte[])((Array)System.Text.Encoding.Default.GetBytes(allAddress));
            unsafe
            {
                fixed (sbyte* psb = sbArray)
                {
                    AddressHelper addressHelper = new AddressHelper(psb);
                    addressHelper.test();
                    string address1 = new string(addressHelper.add1);
                    string address2 = new string(addressHelper.add2);
                    string address3 = new string(addressHelper.add3);
                    string address4 = new string(addressHelper.add4);
                    string address5 = new string(addressHelper.add5);
                    int b = 0;
                }
            }
            */

            foreach (var a in seperateAddresses)
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
            JsonElement first = (JsonElement)addresses[0];
            String all = first.ToString();
            for(int i = 1; i < addresses.Count; i++)
            {
                all = all + '%' + ((JsonElement)addresses[i]).ToString();
            }
            target.Address = all;
            usersMapper.UpdateByPrimaryKeySelective(target);
            response.status = "200";
            return response;
        }


    }
}
