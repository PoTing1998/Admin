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
            //依照需求撈資料
            var mydata = _context.Items.
                GroupBy(m => m.賣方id).
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

            var 銷量 = _context.OrderOrderings.GroupBy(m => m.子項名稱快照).OrderByDescending(x => x.Count()).
                Select(x => new { label = x.Key, data = x.Count() }).ToList()
                ;
            //var 瀏覽次數 = _context.Items.Select(p => p.瀏覽次數).OrderByDescending(x => x).ToList();
         


                //var 金額 = from s in _context.OrderInfos
                //          where s.付款金額.CompareTo("2017/04/12") >= 0 && s.創建時間.CompareTo("2017/04/15") <= 0
                //          select s;

            //把資料存成List
            foreach (var item in mydata)
            {
                itemsList.Add(item.data);
            }

            foreach (var item in 銷量)
            {
                銷售數量.Add(item.data);

            }

            //foreach (var item in 瀏覽次數)
            //{
            //    觀看次數.Add(item.Value);

            //}

            觀看次數.Sort();
            觀看次數.Reverse();


            //序列化
            ViewBag.itemsData = JsonSerializer.Serialize(itemsList);
            ViewBag.銷售數量 = JsonSerializer.Serialize(銷售數量);
            //ViewBag.瀏覽次數 = JsonSerializer.Serialize(觀看次數);
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