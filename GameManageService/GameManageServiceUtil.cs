using DataAccess.Controllers;
using DataAccessAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ubiety.Dns.Core;

namespace GameManageService
{
    class GameManageServiceUtil
    {
        TagsMapper tagsMapper = new TagsMapper();
        //getAllTags
        public Response getAllTags()
        {
            Response response = new Response();
            ArrayList result = tagsMapper.SelectAll();

            response.result = result;
            response.status = "200";
            return response;
        }
    }
}
