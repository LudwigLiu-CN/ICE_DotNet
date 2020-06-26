using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherPageService;
using ResponseClass;

namespace ICEServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PubliserPageController : ControllerBase
    {
        PublisherPageServiceUtil publisherPageService = new PublisherPageServiceUtil();
        private readonly SecurityMaintainLib.SecurityOperatorClass HashTool = new SecurityMaintainLib.SecurityOperatorClass();
       
        
        [Route("/publisherLogin")]
        [HttpPost]
        public Response publisherLogin(Publishers publisher)
        {
            Response response = publisherPageService.publisherLogin(publisher);
            if (response.status == "200")
            {
                int id = int.Parse( response.error);
                HashTool.HashNameAndPassword(publisher.PublisherName, publisher.Pwd, out string hashCode);
                String hash_pwd = hashCode;
                HttpContext.Session.SetInt32("id", id);
                response.error = hashCode;
                return response;

            }
            return response;
        }
        [Route("/publisherInfo")]
        [HttpGet]
        public Response publisherInfo()
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id<0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = publisherPageService.publisherInfo(id.Value);
                return response;

            }

        }
        [Route("/updatePublisherInfo")]
        [HttpPost]
        public Response updatePublisherInfo(Publishers publisher)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null||id<0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                return publisherPageService.updatePublisherInfo(publisher, id.Value);

            }

        }

        [Route("/getPublishers")]
        [HttpGet]
        public Response getPublishers()
        {
            return publisherPageService.getPublishers();
        }
    }
}