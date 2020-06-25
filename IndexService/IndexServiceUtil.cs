using DataAccess.Controllers;
using DataAccessAPI.Controllers;
using DataAccessAPI.Models;
using Org.BouncyCastle.Utilities;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IndexService
{
    public class IndexServiceUtil
    {
        private static ArrayList gameList = new ArrayList();
        private static int askTimes = 0;

        GamesMapper gamesMapper = new GamesMapper();
        BelongMapper belongMapper = new BelongMapper();
        PlayedOnsMapper playedOnsMapper = new PlayedOnsMapper();
        SaleGameMapper saleGameMapper = new SaleGameMapper();

        /*Unfinished File path access*/
        public Response GetGames(bool reset)
        {
            Response response = new Response();
            if (reset)
            {
                gameList = gamesMapper.GetAll();
            }

            ArrayList result = new ArrayList();
            for (int i = askTimes * 12; i < (askTimes + 1) * 12; i++)
            {
                if (i > gameList.Count)
                {
                    break;
                }

                GameInfo gameInfo = GameInfo.convertToGameInfo((Games)gameList[i]);
                /*
                 get cover path
                 */
                result.Add(gameInfo);
            }

            response.status = "200";
            response.result = result;
            askTimes++;

            return response;
        }

        public Response SortGames(int flag)
        {
            askTimes = 0;
            Response response = new Response();
            if (flag == 1)
            {
                response = GetGames(false);
                return response;
            }

            gameList = GameInfo.sort(gameList, flag);
            return GetGames(false);
        }


        public Response resetGamesByTitle(String keyWords)
        {
            Response response = new Response();
            askTimes = 0;
            gameList = gamesMapper.SearchByTitle(keyWords);

            return GetGames(false);
        }

        public Response resetGamesByCate(int cateId)
        {
            Response response = new Response();
            askTimes = 0;
            ArrayList belongList = belongMapper.SelectByCateId(cateId);
            gameList.Clear();
            foreach (var belong in belongList)
            {
                Belong tempBelong = (Belong)belong;
                gameList.Add(tempBelong.Game);
            }

            return GetGames(false);
        }

        public Response resetGamesByConsole(int consoleId)
        {
            Response response = new Response();
            askTimes = 0;
            List<PlayedOn> playedOnList = playedOnsMapper.SelectByConsoleId(consoleId);
            gameList.Clear();
            foreach (PlayedOn playedOn in playedOnList)
            {
                gameList.Add(playedOn.Game);
            }

            return GetGames(false);
        }

        public Response resetGamesByPublisher(int publisherId)
        {
            Response response = new Response();
            askTimes = 0;
            ArrayList saleGameList = saleGameMapper.SelectByPublisherId(publisherId);
            gameList.Clear();
            foreach (var sg in saleGameList)
            {
                SaleGame tempSaleGame = (SaleGame)sg;
                gameList.Add(tempSaleGame.Game);
            }

            return GetGames(false);
        }

        public Response SearchGamesByTitle(String keyWords, bool reset)
        {
            if (reset)
            {
                return resetGamesByTitle(keyWords);
            }

            askTimes = 0;
            ArrayList tempGameList = new ArrayList();
            foreach (var g in gameList)
            {
                Games tempGame = (Games)g;
                if (tempGame.Title.ToLower().Contains(keyWords.ToLower())){
                    tempGameList.Add(tempGame);
                }
            }
            gameList = tempGameList;

            return GetGames(false);
        }

        public Response SearchGamesByCate(int cateId, bool reset)
        {
            if (reset)
            {
                return resetGamesByCate(cateId);
            }

            askTimes = 0;
            ArrayList tempGameList = new ArrayList();
            foreach (var g in gameList)
            {
                Games tempGame = (Games)g;
                Belong tempBelong = belongMapper.SelectByPrimaryKey(tempGame.GameId);
                if (tempBelong.CateId == cateId) {
                    tempGameList.Add(tempGame);
                }
            }
            gameList = tempGameList;

            return GetGames(false);
        }

        public Response SearchGamesByConsole(int consoleId, bool reset)
        {
            if (reset)
            {
                return resetGamesByConsole(consoleId);
            }

            askTimes = 0;
            ArrayList tempGameList = new ArrayList();
            foreach (var g in gameList)
            {
                Games tempGame = (Games)g;
                PlayedOn tempPlayedOn = playedOnsMapper.SelectPrimaryKey(tempGame.GameId, consoleId);
                if (tempPlayedOn != null)
                {
                    tempGameList.Add(tempGame);
                }
            }
            gameList = tempGameList;

            return GetGames(false);
        }

        public Response SearchGamesByPublisher(int publisherId, bool reset)
        {
            if (reset)
            {
                return resetGamesByPublisher(publisherId);
            }

            askTimes = 0;
            ArrayList tempGameList = new ArrayList();
            foreach (var g in gameList)
            {
                Games tempGame = (Games)g;
                SaleGame tempSaleGame = saleGameMapper.SelectByPrimaryKey(publisherId, tempGame.GameId);
                if (tempSaleGame != null)
                {
                    tempGameList.Add(tempGame);
                }
            }
            gameList = tempGameList;

            return GetGames(false);
        }
    } 
}
