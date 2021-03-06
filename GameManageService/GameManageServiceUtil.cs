﻿using DataAccess.Controllers;
using DataAccessAPI.Controllers;
using DataAccessAPI.Models;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace GameManageService
{
    public class GameManageServiceUtil
    {
        TagsMapper tagsMapper = new TagsMapper();
        PublisherMapper publisherMapper = new PublisherMapper();
        SaleGameMapper saleGameMapper = new SaleGameMapper();
        GamesMapper gamesMapper = new GamesMapper();
        BelongMapper belongMapper = new BelongMapper();
        HasTagMapper hasTagMapper = new HasTagMapper();
       
        PlayedOnsMapper playedOnsMapper = new PlayedOnsMapper();
        ConsolesMapper consolesMapper = new ConsolesMapper();
        CategoriesMapper categoriesMapper = new CategoriesMapper();
        static List<Games> allGameList = new List<Games>();
        static List<Games> presentGameList = new List<Games>();
        static List<Orders> allOrderList = new List<Orders>();
        static List<Orders> presentOrderList = new List<Orders>();

        public GameManager convertToGameManager(Games game)
        {
            GameManager gameManager = new GameManager();
            gameManager.game_id = game.GameId;
            gameManager.title = game.Title;
            gameManager.price = (float)game.Price;
            if (game.Discount != null)
            {
                gameManager.discount = (bool)game.Discount.Value;

            }
            if (game.AverageRate == null)
            {
                gameManager.average_rate = -1;
            }
            else
            {
                gameManager.average_rate = (float)game.AverageRate;
            }
            if (game.ReleaseDate != null)
            {
                gameManager.release_date = (DateTime)game.ReleaseDate;

            }
            if (game.PreOrder != null)
            {
                gameManager.pre_order = (bool)game.PreOrder;

            }
            if (game.RateCount != null)
            {
                gameManager.rate_count = (int)game.RateCount;

            }
            
            gameManager.cover = game.CoverPath;
            gameManager.description = game.Description;
            gameManager.on_sale = (bool)game.OnSale;

            //Cate
            
            Belong belong = belongMapper.SelectByPrimaryKey(game.GameId);
            if (belong != null)
            {
                Categories categories = categoriesMapper.SelectByPrimaryKey(belong.CateId);
                gameManager.category = categories;
            }
            

            //Tags
            ArrayList hasTags = hasTagMapper.SelectByGameId(game.GameId);

            for (int i = 0; i < hasTags.Count; i += 1)
            {
                HasTag hastag = (HasTag)hasTags[i];
                Tags temp = tagsMapper.SelectByPrimaryKey(hastag.TagId);
                gameManager.tags_list.Add(temp);

            }

            //Pictures
            //需要填写图片路径heduqu
            List<String> picList = new List<string>();
            String path = game.GameId.ToString();

            //Consoles
            List<PlayedOn> playedOns = playedOnsMapper.SelectByGameId(game.GameId);
            for (int i = 0; i < playedOns.Count; i++)
            {
                gameManager.consoles.Add(consolesMapper.SelectByPrimaryKey(playedOns[i].ConsoleId));
            }

            return gameManager;


        }


        //getAllTags
        public Response getAllTags()
        {
            Response response = new Response();
            ArrayList result = tagsMapper.SelectAll();
            Console.WriteLine(result[0]);
            response.result = result;
            response.status = "200";
            return response;
        }
        //initGamelist
        public Response initGameList(int pageSize, int id)
        {
            Response response = new Response();
            allGameList.Clear();

            if (publisherMapper.SelectByPrimaryKey(id) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }

            ArrayList saleGameList = saleGameMapper.SelectByPublisherId(id);
            //List < SaleGame > = (List<SaleGame>)saleGameMapper.SelectByPublisherId(id);
            allGameList.Clear();

            /*
             *  加分页器重构
             */
            for (int i = 0; i < saleGameList.Count; i += 1)
            {
                SaleGame saleGame = (SaleGame)saleGameList[i];
                Games temp = gamesMapper.SelectByPrimaryKey(saleGame.GameId);
                allGameList.Add(temp);
            }

            presentGameList.Clear();
            for (int i = 0; i < allGameList.Count; i += 1)
            {
                presentGameList.Add(allGameList[i]);
            }

            ArrayList result = new ArrayList();
            for (int i = 0; i < pageSize; i++)
            {
                if (i > presentGameList.Count - 1)
                {
                    break;
                }
                result.Add(this.convertToGameManager(presentGameList[i]));
            }
            response.result = result;



            response.status = "200";
            return response;
        }

       

        // searchPublishedGames
        public Response searchPublishedGames(String query, int currentPage, int pageSize, int id)
        {
            Response response = new Response();
            
            if (publisherMapper.SelectByPrimaryKey(id) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }
            

            
            initGameList(pageSize, id);
            

            presentGameList.Clear();
            for (int i = 0; i < allGameList.Count; i++)
            {

                if (allGameList[i].Title.ToLower().Contains(query.ToLower()))
                {
                    Console.WriteLine("title" + allGameList[i].Title.ToLower());

                    presentGameList.Add(allGameList[i]);
                }
            }

            //List<GameManager> result = new List<GameManager>();
            for (int i = currentPage * pageSize; i < (currentPage + 1) * pageSize; i++)
            {
                if (i > presentGameList.Count - 1)
                {
                    break;
                }
                Console.WriteLine("add");
                response.result.Add(this.convertToGameManager(presentGameList[i]));
            }
            //分页器实现
            response.status = "200";
            return response;
        }
        //jumpToGamePage Session
        public Response jumpToGamePage(int targetPage, int pageSize, int id)
        {
            Response response = new Response();

   
            if (publisherMapper.SelectByPrimaryKey(id) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }
            for (int i = targetPage * pageSize; i < (targetPage + 1) * pageSize; i += 1)
            {
                if (i > presentGameList.Count - 1)
                {
                    break;
                }
                response.result.Add(this.convertToGameManager(presentGameList[i]));

            }
            if (response.result.Count == 0)
            {
                response.status = "404";
                response.error = "Out of boundary!";
                return response;
            }
            response.status = "200";
            return response;


        }
        // AddGame Session
        public Response addGame(GameAdder gameAdder, int id)
        {
            Response response = new Response();

            int pubId = id;

            if (publisherMapper.SelectByPrimaryKey(pubId) == null)
            {
                response.status="403";
                response.error = "";
                return response;
            }
            Games game = new Games();

            game.Title=gameAdder.title;
            game.Price=gameAdder.price;
            game.Discount=gameAdder.discount;
            game.ReleaseDate=gameAdder.release_date;
            game.PreOrder=gameAdder.pre_order;
            game.Description=gameAdder.description;

            int? cate_id = gameAdder.cate_id;
            String cover = gameAdder.cover;
            List<int> list_console_id = gameAdder.list_console_id;
            List<int> list_tag_id = gameAdder.list_tag_id;
            List<String> pictures = gameAdder.pictures;
            //Console.WriteLine("----2323232323-------------------23232323----------:" + saleGameMapper.getMaxGameId()[0]);
            SaleGame maxgame = (SaleGame)saleGameMapper.getMaxGameId()[0];
            game.GameId =  maxgame.GameId+ 1;
            Console.WriteLine("max_game_id" + game.GameId);

            game.RateCount = 0;
            game.OnSale = true;
            try
            {
                gamesMapper.Insert(game);
            }catch(Exception e)
            {
                
                response.status = "500";
                response.error = "Error: Information format of noncompliance with requirements.";
                return response;
            }
            //sequeceMapper!!!!!!!!!!!
            
            SaleGame saleGame = new SaleGame();
            saleGame.GameId = game.GameId;
            saleGame.PublisherId = pubId;
            saleGameMapper.Insert(saleGame);

            //Consoles
            for(int i = 0; i < list_console_id.Count; i++)
            {
                PlayedOn playedOn = new PlayedOn();
                playedOn.ConsoleId = list_console_id[i];
                playedOn.GameId = game.GameId;
    
                playedOnsMapper.Insert(playedOn);
            }
            if (cate_id != null)
            {
                Belong belong = new Belong();
                belong.CateId = cate_id.Value;
                belong.GameId = game.GameId;
                belongMapper.Insert(belong);
            }
            

            //Tags
            for(int i = 0; i < list_tag_id.Count; i++)
            {
                HasTag hastag = new HasTag();
                hastag.GameId = game.GameId;
                hastag.TagId = list_tag_id[i];
                hasTagMapper.Insert(hastag);
            }

            //Cover and pics
            //imageProcess(cover, pictures, gameId);

            ArrayList result = new ArrayList();
            Games temp = gamesMapper.SelectByPrimaryKey(game.GameId);
            GameManager gm = this.convertToGameManager(temp);
            result.Add(gm);
            response.error = "Upload Success!";
            response.status = "200";
            return response;
        }

        //postImg daiding
        //public Response postImg()
        //{

        //}
        

        //deleteGame
        public Response deleteGame(int gameId,int id)
        {
            Response response = new Response();
            int pubId = id;
            if (publisherMapper.SelectByPrimaryKey(pubId) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }
            SaleGame sg =(SaleGame)saleGameMapper.SelectByGameId(gameId)[0];
            if (sg.PublisherId != pubId)
            {
                response.status = "403";
                response.error = "Not sell by this publisher";
                return response;
            }
            try
            {
                gamesMapper.DeleteByPrimaryKey(gameId);
            }catch(Exception e)
            {
                response.error = "Deleting Error";
                response.status = "500";
                return response;
            }

            response.status = "204";
            response.error = "Deleting Success";
            return response;


        }

        //modifGame
        public Response modifyGame(GameModifier gameModifier ,int id)
        {
            Response response = new Response();
            int pubId = id;

            if (publisherMapper.SelectByPrimaryKey(pubId) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }
            SaleGame sg = (SaleGame)saleGameMapper.SelectByGameId(gameModifier.game_id)[0];
            if (sg.PublisherId != pubId)
            {
                response.status = "403";
                response.error = "Not sell by this publisher";
                return response;
            }

            Games gameRecord = gamesMapper.SelectByPrimaryKey(gameModifier.game_id);
            if (gameModifier.title != null)
            {
                gameRecord.Title = gameModifier.title;

            }
            if (gameModifier.discount != null)
            {
                gameRecord.Discount = gameModifier.discount;

            }
            if (gameModifier.pre_order != null)
            {
                gameRecord.PreOrder = gameModifier.pre_order;

            }
            if (gameModifier.description != null)
            {
                gameRecord.Description = gameModifier.description;
            }
            if (gameModifier.price != null)
            {
                gameRecord.Price = gameModifier.price;
            }

            gamesMapper.UpdatePrimaryKeySelective(gameRecord);

            //console
            if (gameModifier.list_console_id == null)
            {
                response.error="Successfully Modified!";
                response.status="200";
                return response;
            }
            List<int> consoleIds = gameModifier.list_console_id;
            playedOnsMapper.DeleteByGameId(gameRecord.GameId);
            for (int
                i = 0; i < consoleIds.Count; i++)
            {
                PlayedOn temp = new PlayedOn();
                temp.GameId = gameRecord.GameId;
                temp.ConsoleId = consoleIds[i];
                playedOnsMapper.Insert(temp);
            }
            response.error = "Successfully Modified!";
            response.status = "200";
            return response;

        }
    }
}
