using DataAccess.Controllers;
using DataAccessAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IndexService
{
    class GameInfo
    {
        static HasTagMapper hasTagMapper = new HasTagMapper();
        static RateGameMapper rateGameMapper = new RateGameMapper();
        static TagsMapper tagsMapper = new TagsMapper();
        public int id { get; set; }
        public String cover_path { get; set; }
        public float? price { get; set; }
        public String title { get; set; }
        public ArrayList tags_list { get; set; }


        public static GameInfo convertToGameInfo(Games game)
        {
            GameInfo result = new GameInfo();
            result.id = game.GameId;
            result.cover_path = game.CoverPath;
            result.price = game.Price;
            result.title = game.Title;

            ArrayList hasTags = hasTagMapper.SelectByGameId(game.GameId);
            ArrayList tagNames = new ArrayList();
            for (int i = 0; i < hasTags.Count; i++)
            {
                HasTag ht = (HasTag)hasTags[i];
                Tags t = tagsMapper.SelectByPrimaryKey(ht.TagId);
                tagNames.Add(t.TagName);
            }
            result.tags_list = tagNames;

            return result;
        }

        public static ArrayList sort(ArrayList gameList, int flag)
        {
            if(flag == 2||flag== 3){
                gameList = sortByPrice(gameList, flag);
            }
            else if(flag == 4||flag == 5){
                gameList = sortByRate(gameList, flag);
            }
            else
            {
                return gameList;
            }

            return gameList;
        }

        public static ArrayList sortByPrice(ArrayList gameList, int flag)
        {
            bool swapped = false;

            ArrayList toBeSorted = new ArrayList();
            foreach(var g in gameList)
            {
                toBeSorted.Add(g);
            }

            while (true)
            {
                swapped = false;
                for(int k = 0; k < toBeSorted.Count - 1; k++)
                {
                    Games crtGame = (Games)toBeSorted[k];
                    Games nextGame = (Games)toBeSorted[k+1];
                    if (crtGame.Price > nextGame.Price)
                    {
                        toBeSorted[k] = nextGame;
                        toBeSorted[k+1] = crtGame;
                        swapped = true;
                    }
                }
                if(swapped == false)
                {
                    break;
                }
            }

            if (flag == 2)
            {
                toBeSorted.Reverse();
            }

            return toBeSorted;
        }

        public static ArrayList sortByRate(ArrayList gameList, int flag)
        {
            bool swapped = false;

            ArrayList toBeSorted = new ArrayList();
            foreach (var g in gameList)
            {
                toBeSorted.Add(g);
            }

            while (true)
            {
                swapped = false;
                for (int k = 0; k < toBeSorted.Count - 1; k++)
                {
                    Games crtGame = (Games)toBeSorted[k];
                    Games nextGame = (Games)toBeSorted[k + 1];
                    if (rateGameMapper.GetAverage(crtGame.GameId) > rateGameMapper.GetAverage(nextGame.GameId))
                    {
                        toBeSorted[k] = nextGame;
                        toBeSorted[k + 1] = crtGame;
                        swapped = true;
                    }
                }
                if (swapped == false)
                {
                    break;
                }
            }

            if (flag == 4)
            {
                toBeSorted.Reverse();
            }

            return toBeSorted;
        }
    }
}
