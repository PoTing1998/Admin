using admin.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System;

using System.Text.Json;
using Microsoft.Data.SqlClient;

namespace admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly LockerLuckContext _context;

        public HomeController(ILogger<HomeController> logger, LockerLuckContext context)
        {
            _logger = logger;
            _context = context;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Index()
        {
           

            List<int> itemsList = new List<int>();
            List<int> 銷售數量 = new List<int>();
            List<int> 觀看次數 = new List<int>();
            List<int> 會員成長數 = new List<int>();
            List<int> 金額總和 = new List<int>();

            //依照需求撈資料
            var mydata = _context.Items.
                GroupBy(m => m.賣方id).OrderByDescending(m => m.Count()).
                Select(x => new { label = x.Key, data = x.Count() }).ToList()
                ;

            //var 銷量 = _context.OrderOrderings.
            //    GroupBy(m => m.子項名稱快照).
            //    Select(x => new
            //    {
            //        label = x.Key,
            //        data = x.Count
            //    ()
            //    }).ToList();

            DateTime date6 = new DateTime(2022, 6, 1, 0, 0, 0);
            DateTime date7 = new DateTime(2022, 7, 1, 0, 0, 0);
            DateTime date8 = new DateTime(2022, 8, 1, 12, 0, 0);
            DateTime date9 = new DateTime(2022, 9, 1, 12, 0, 0);

            var 銷量 = _context.OrderOrderings.GroupBy(m => m.子項名稱快照).OrderByDescending(x => x.Count()).
                Select(x => new { label = x.Key, data = x.Count() }).ToList()
                ;


            var 瀏覽次數 = _context.Items.Select(p => p.瀏覽次數).OrderByDescending(x => x).ToList();

            var  七月金額 =( from num  in  _context.OrderInfos
                      where num.創建時間 >date7 && num.創建時間<date8                    
                      select num.付款金額).Sum();

            var 八月金額 = (from num in _context.OrderInfos
                        where num.創建時間 > date8 && num.創建時間 < date9

                        select num.付款金額).Sum();


            var 六月人數 = (from number in _context.Users
                        where number.註冊時間 > date6 && number.註冊時間 < date7

                        select number.會員帳號).Count();
            var 七月人數 = (from number in _context.Users
                       where number.註冊時間 > date6 && number.註冊時間 < date8

                       select number.會員帳號).Count();
            var 八月人數 = (from number in _context.Users
                        where number.註冊時間 > date6 && number.註冊時間 < date9

                        select number.會員帳號).Count();
            //var 金額 = from s in _context.OrderInfos
            //          where s.付款金額.CompareTo("2017/04/12") >= 0 && s.創建時間.CompareTo("2017/04/15") <= 0
            //          select s;

            //把資料存成List
            foreach (var item in mydata)
            {
                itemsList.Add(item.data);
            }


            int sales = 0;
                foreach (var item in 銷量)
                {
                if (sales >= 4) break;
                    銷售數量.Add(item.data);
                sales ++;

                }
            
       

            foreach (var item in 瀏覽次數)
            {
                觀看次數.Add(item.Value);

            }

            觀看次數.Sort();
            觀看次數.Reverse();

            會員成長數.Add(六月人數);
            會員成長數.Add(七月人數);
            會員成長數.Add(八月人數);

            金額總和.Add(七月金額.Value);
            金額總和.Add(八月金額.Value);


            //序列化
            ViewBag.itemsData = JsonSerializer.Serialize(itemsList);
            ViewBag.銷售數量 = JsonSerializer.Serialize(銷售數量);
            ViewBag.瀏覽次數 = JsonSerializer.Serialize(觀看次數);
            ViewBag.銷售金額 = JsonSerializer.Serialize(金額總和);
            ViewBag.成長人數 = JsonSerializer.Serialize(會員成長數);
            return View();
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

//        public List<Item> Get子項List()
//        {
//            List<int> 觀看次數 = new List<int>();
//            var sql = @"
//SELECT          SUM(付款金額) AS Expr1
//FROM              dbo.[Order-Info]
//WHERE          (創建時間 < CONVERT(DATETIME, '2022-08-01 00:00:00', 102))

//";

//            using (_context)
//            {
//                觀看次數 = _context.
//            }


//                return 觀看次數;
//        }

    }

}