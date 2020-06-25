using DataAccess.Controllers;
using DataAccessAPI.Controllers;
using DataAccessAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GameService
{
    class GameServiceUtil
    {
        GamesMapper gamesMapper = new GamesMapper();
        PlayedOnsMapper playedOnsMapper = new PlayedOnsMapper();
        ConsolesMapper consolesMapper = new ConsolesMapper();
        HasTagMapper hasTagMapper = new HasTagMapper();
        TagsMapper tagsMapper = new TagsMapper();
        BelongMapper belongMapper = new BelongMapper();
        CategoriesMapper categoriesMapper = new CategoriesMapper();
        SaleGameMapper saleGameMapper = new SaleGameMapper();
        PublisherMapper publisherMapper = new PublisherMapper();
        public Response GetGameDetail(int gameId)
        {
            Response response = new Response();
            Games target = gamesMapper.SelectByPrimaryKey(gameId);

            response.status = "200";
            response.result.Add(target);

            return response;
        }

        public Response GetGameConsole(int gameId)
        {
            Response response = new Response();
            Games target = gamesMapper.SelectByPrimaryKey(gameId);

            List<PlayedOn> playedOns = playedOnsMapper.SelectByGameId(gameId);
            foreach(PlayedOn po in playedOns)
            {
                response.result.Add(consolesMapper.SelectByPrimaryKey(po.ConsoleId));
            }

            response.status = "200";
            return response;
        }

        public Response GetGameTag(int gameId)
        {
            Response response = new Response();
            var hasTags = hasTagMapper.SelectByGameId(gameId);
            foreach(var ht in hasTags)
            {
                HasTag temp = (HasTag)ht;
                response.result.Add(tagsMapper.SelectByPrimaryKey(temp.TagId));
            }
            response.status = "200";
            return response;
        }

        public Response GetGameCate(int gameId)
        {
            Response response = new Response();
            Belong belong = belongMapper.SelectByPrimaryKey(gameId);
            response.result.Add(categoriesMapper.SelectByPrimaryKey(belong.CateId));

            response.status = "200";
            return response;
        }

        public Response GetGamePublisher(int gameId)
        {
            Response response = new Response();
            ArrayList sales = saleGameMapper.SelectByGameId(gameId);
            foreach(var sale in sales)
            {
                SaleGame temp = (SaleGame)sale;
                response.result.Add(publisherMapper.SelectByPrimaryKey(temp.PublisherId));
            }

            response.status = "200";
            return response;
        }

        //unfinished file stream
        public Response getPics(int gameId)
        {
            Response response = new Response();

            return response;
        }
    }
}
