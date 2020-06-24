using DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessAPI.Models;
using DataAccessAPI.Controllers;
using System.Collections;
using PublisherPageService.Models;
using System.Security.Policy;

namespace PublisherPageService
{
    class PublisherPageServiceUtil
    {
        PublisherMapper publisherMapper = new PublisherMapper();

        

        public Response<Publishers> publisherInfo(int id)
        {
            Response<Publishers> response = new Response<Publishers>();
            if (publisherMapper.SelectByPrimaryKey(id) == null)
            {
                response.status = "403";
                response.error = "";
                return response;

            }

            Publishers publishers = publisherMapper.SelectByPrimaryKey(id);
            List<Publishers> result = new List<Publishers>();
            result.Add(publishers);
            response.result = result;

            response.status = "200";
            return response;


            
        }
    }
}
