using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService;
using ResponseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICEServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        static OrderServiceUtil orderServiceUtil = new OrderServiceUtil();

        [Route("/initAllOrderList")]
        [HttpGet]
        public Response initAllOrderList()
        {
            Response response = new Response();

            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }
            else if (id < 0)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }

            response = orderServiceUtil.InitAllOrderList((int)id);

            return response;
        }

        [Route("/getOrderList")]
        [HttpGet]
        public Response getOrderList(int status)
        {
            Response response = new Response();

            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }
            else if (id < 0)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }

            response = orderServiceUtil.GetOrderList((int)id, status);

            return response;
        }

        [Route("/confirmOrder")]
        [HttpGet]
        public Response confirmOrder(int orderId)
        {
            Response response = new Response();

            response = orderServiceUtil.ConfirmOrder(orderId);

            return response;
        }

        [Route("/deliverOrder")]
        [HttpGet]
        public Response deliverOrder(int orderId)
        {
            Response response = new Response();

            response = orderServiceUtil.DeliverOrder(orderId);

            return response;
        }

        [Route("/createOrder")]
        [HttpPost]
        public Response createOrder(Orders order)
        {
            Response response = new Response();

            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }
            else if (id < 0)
            {
                response.status = "500";
                response.error = "haven't logged in yet!";
                return response;
            }

            response = orderServiceUtil.CreateOrder((int)id, order);

            return response;
        }
    }
}
