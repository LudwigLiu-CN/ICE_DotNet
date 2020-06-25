using DataAccess.Controllers;
using DataAccessAPI.Models;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace PublisherManageOrderService
{
    public class PublisherManageOrderUtil
    {
        PublisherMapper publisherMapper = new PublisherMapper();
        OrdersMapper ordersMapper = new OrdersMapper();
        ConsolesMapper consolesMapper = new ConsolesMapper();
        UserMapper userMapper = new UserMapper();
        GamesMapper gamesMapper = new GamesMapper();
        SaleGameMapper saleGameMapper = new SaleGameMapper();
        private static List<Orders> allOrderList = new List<Orders>();

        private static List<Orders> presentOrderList = new List<Orders>();

        public OrderManager convertToOrderManager(Orders order)
        {
            OrderManager orderManager = new OrderManager();
            orderManager.order_id = order.OrderId;
            orderManager.order_date = (DateTime)order.Date;
            orderManager.address = order.Address;
            orderManager.console = consolesMapper.SelectByPrimaryKey((int)order.ConsoleId);
            orderManager.contact_tel = order.ContactTel;
            orderManager.status = (int)order.Status;
            orderManager.price = (float)order.Price;

            orderManager.user_id = (int)order.UserId;
            orderManager.user_name = userMapper.SelectByPrimaryKey((int)order.UserId).UserName;

            orderManager.game_id = (int)order.GameId;
            orderManager.game_name = gamesMapper.SelectByPrimaryKey((int)order.GameId).Title;

            return orderManager;


        }
        //initOrderList
        public Response initOrderList(int pageSize, int id)
        {
            Response response = new Response();
            int pubId = id;
            if (publisherMapper.SelectByPrimaryKey(pubId) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }
            allOrderList.Clear();
            allOrderList = ordersMapper.SelectByPublishierId(pubId);
            presentOrderList.Clear();
            presentOrderList = ordersMapper.SelectByPublishierId(pubId);

            ArrayList result = new ArrayList();
            for (int i = 0; i < pageSize; i++)
            {
                if (i > presentOrderList.Count-1)
                {
                    break;
                }
                response.result.Add(this.convertToOrderManager(presentOrderList[i]));
            }
            response.status = "200";
            return response;
        }

        //orderNumber
        public Response orderNumber(int id)
        {
            Response response = new Response();
            int pubId = id;
            if (publisherMapper.SelectByPrimaryKey(pubId) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }

            response.result.Add(presentOrderList.Count);
            response.status = "200";
            return response;
        }

        //searchOrder
        public Response searchOrder(String query, int currentPage, int pageSize, int id)
        {
            Response response = new Response();
            int pubId = id;
            if (publisherMapper.SelectByPrimaryKey(pubId) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }
            
            initOrderList(pageSize, id);
            

            presentOrderList.Clear();
            for (int i = 0; i < allOrderList.Count; i++)
            {
                Orders temp_order = allOrderList[i];
                String temp_title = gamesMapper.SelectByPrimaryKey((int)temp_order.GameId).Title;
                if (temp_title.ToLower().Contains(query.ToLower()))
                {
                    presentOrderList.Add(temp_order);
                }
            }

            for (int i = currentPage * pageSize; i < (currentPage + 1) * pageSize; i++)
            {
                if (i > presentOrderList.Count - 1)
                {
                    break;
                }
                response.result.Add(this.convertToOrderManager(presentOrderList[i]));
            }

            response.status = "200";
            return response;
        }
        //jumpToOrderPage
        public Response jumpToOrderOage(int targetPage, int pageSize, int id)
        {
            Response response = new Response();
            int pubId = id;

            if (publisherMapper.SelectByPrimaryKey(pubId) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }
            for (int i = targetPage * pageSize; i < (targetPage + 1) * pageSize; i += 1)
            {
                if (i > presentOrderList.Count - 1)
                {
                    break;
                }
                response.result.Add(this.convertToOrderManager(presentOrderList[i]));

            }
            if (response.result.Count == 0)
            {
                response.status = "404";
                response.error = "Out of boundary!";
            }
            response.status = "200";
            return response;
        }

        //alterOrder
        public Response alterOrder(int order_id,int? status,float? price,String address,String contact_tel,int id)
        {
            Response response = new Response();
            int pubId = id;
            if (publisherMapper.SelectByPrimaryKey(pubId) == null)
            {
                response.status="403";
                response.error="";
                return response;
            }
            Orders origin_order = ordersMapper.SelectByPrimaryKey(order_id);
            SaleGame saleGame = ( SaleGame)saleGameMapper.SelectByGameId((int)origin_order.GameId)[0];
            if (saleGame.PublisherId != pubId)
            {
                response.status = "403";
                response.error = "";
                return response;
            }
            //Orders orders = new Orders();
            //orders.OrderId = order_id;

            if (status != null)
            {
                if (status >= 0 && status <= 4)
                {
                    origin_order.Status=status;
                }
            }
            if (price != null)
            {
                origin_order.Price=price;
            }
            if (address != null)
            {
                origin_order.Address=address;
            }
            if (contact_tel != null)
            {
                origin_order.ContactTel=contact_tel;
            }
            try
            {
                ordersMapper.UpdateByPrimaryKeySelective(origin_order);
            }catch(Exception e)
            {
                response.status = "500";
                response.error = "Altering Failed!";
                return response;
            }

            Orders currentOrder = ordersMapper.SelectByPrimaryKey(order_id);
            response.result.Add(this.convertToOrderManager(currentOrder));

            response.status = "200";
            response.error = "Alerting success!";

            return response;
        }
    }
}
