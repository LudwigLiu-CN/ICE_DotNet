using DataAccessAPI.Models;
using ResponseClass;
using System;
using System.Collections;

namespace GameManageService
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameManageServiceUtil gameManageServiceUtil = new GameManageServiceUtil();
            Response response = gameManageServiceUtil.getAllTags();
            Console.WriteLine(response);
            Console.WriteLine(response.status);
            Console.WriteLine(response.result);
            Console.WriteLine(response.result.Count);
            Tags tag = (Tags)response.result[0];
            Console.WriteLine(tag.TagName);
            

            Console.WriteLine("1--------------------------------");
            Response response1 = gameManageServiceUtil.initGameList(10, 2);
            Console.WriteLine("status:"+response1.status);
            Console.WriteLine("count:"+response1.result.Count);
            GameManager gm = (GameManager) response1.result[2];
            Console.WriteLine("gameId:"+gm.game_id);
            Console.WriteLine("gameTitle:"+gm.title);
            Console.WriteLine("release_date:"+gm.release_date);


            Console.WriteLine("2--------------------------------");
            Response response2 = gameManageServiceUtil.searchPublishedGames("d", 0, 10, 2);
            Console.WriteLine("status:"+response2.status);
            Console.WriteLine("count ："+response2.result.Count);

            GameManager gm2 = (GameManager) response2.result[0];
            Console.WriteLine(gm2.game_id);
            Console.WriteLine(gm2.title);
            Console.WriteLine(gm2.release_date);

            Console.WriteLine("3--------------------------------");
            Response response3 = gameManageServiceUtil.jumpToGamePage(1,1,2);
            Console.WriteLine("status:"+response3.status);
            Console.WriteLine("count:"+response3.result.Count);

            GameManager gm3 = (GameManager)response1.result[0];
            Console.WriteLine(gm3.game_id);
            Console.WriteLine(gm3.title);
            Console.WriteLine(gm3.release_date);

            // !!!!!!!!!!!!!!!!!!!!!!!!!!要加一个生成新id的东西
            //Console.WriteLine("-----------44444---------------------");
            //GameAdder gameAdder = new GameAdder();
            //gameAdder.title = "woxiaxiede";
            //Response response4 = gameManageServiceUtil.addGame(gameAdder,2);

            //Console.WriteLine("----------5---------------------");
            //Response response5 = gameManageServiceUtil.deleteGame(1, 1, 2);

            Console.WriteLine("---------------666-----------------");
            GameModifier gameModifier = new GameModifier();
            gameModifier.game_id = 2;

            gameModifier.discount = true;
            Response response6 = gameManageServiceUtil.modifyGame(gameModifier,2);
            Console.WriteLine(response6.status);


            Console.WriteLine("Hello World!");
        }
    }
}
