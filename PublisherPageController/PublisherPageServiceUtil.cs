using DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessAPI.Models;
using DataAccessAPI.Controllers;
using System.Collections;
using PublisherPageService.Models;
using ResponseClass;

namespace PublisherPageService
{
    public class PublisherPageServiceUtil
    {
        PublisherMapper publisherMapper = new PublisherMapper();

        // publisherLogin
        public Response publisherLogin(Publishers publishers)
        {
            Response response = new Response();
            if (publisherMapper.SelectByName(publishers.PublisherName).Count==0)
            {
                response.status = "404";
                response.error = "Publisher not exist";
                return response;
            }
            else
            {
                Publishers publisherRecord = publisherMapper.SelectByName(publishers.PublisherName)[0];
                if (publisherRecord.Pwd != publishers.Pwd)
                {
                    response.status = "403";
                    response.error = "Wrong password !";
                    return response;
                }
                else
                {
                    response.status = "200";
                    return response;
                }
            }
        }
        

        
        
        // publishInfo
        public Response publisherInfo(int id)
        {
            Response response = new Response();
            if (publisherMapper.SelectByPrimaryKey(id) == null)
            {
                response.status = "403";
                response.error = "";
                return response;

            }

            Publishers publishers = publisherMapper.SelectByPrimaryKey(id);
            ArrayList result = new ArrayList();
            result.Add(publishers);
            response.result = result;

            response.status = "200";
            return response;

        }
        //updatePublisherInfo
        public Response updatePublisherInfo(Publishers publisher, int id)
        {
            Response response = new Response();
            if(publisherMapper.SelectByPrimaryKey(id) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }

            publisher.PublisherId = id;
            try
            {
                publisherMapper.UpdateByPrimaryKeySelective(publisher);
            }catch(Exception e)
            {
                response.status = "500";
                response.error = "Update Failed ！";
                return response;
            }
            response.error = "Update Success!";
            response.status = "200";
            return response;
        }
    }
}
