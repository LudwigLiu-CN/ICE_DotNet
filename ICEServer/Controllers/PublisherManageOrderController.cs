using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherManageOrderService;
using ResponseClass;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherManageOrderController : ControllerBase
    {
        PublisherManageOrderUtil publisherManageOrderServie = new PublisherManageOrderUtil();

        [Route("/initOrderList")]
        [HttpGet]
        public Response initOrderList(int pageSize)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = publisherManageOrderServie.initOrderList(pageSize, id.Value);
                return response;
            }
        }

        [Route("/orderNumber")]
        [HttpGet]
        public Response orderNumber()
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = publisherManageOrderServie.orderNumber( id.Value);
                return response;
            }
        }

        [Route("/searchOrder")]
        [HttpGet]
        public Response searchOrder(String query, int currentPage,int pageSize)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = publisherManageOrderServie.searchOrder(query,currentPage,pageSize,id.Value);
                return response;
            }
        }

        [Route("/jumpToOrderPage")]
        [HttpGet]
        public Response jumpToOrderPage(int targetPage, int pageSize)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = publisherManageOrderServie.jumpToOrderOage(targetPage, pageSize, id.Value);
                return response;
            }
        }

        [Route("/alterOrder")]
        [HttpGet]
        public Response alterOrder(int order_id, int status, float price, String address,String contact_tel)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null || id < 0)
            {
                Response response = new Response();
                response.status = "500";
                response.error = "Haven't logged in yet!";
                return response;
            }
            else
            {
                Response response = publisherManageOrderServie.alterOrder(order_id,status,price,address,contact_tel, id.Value);
                return response;
            }
        }
    }
}