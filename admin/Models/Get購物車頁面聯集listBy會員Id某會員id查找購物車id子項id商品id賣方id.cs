using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class Get購物車頁面聯集listBy會員Id某會員id查找購物車id子項id商品id賣方id
    {
        public string 購物車項目id { get; set; } = null!;
        public int? 購物車項目數量 { get; set; }
        public string? 子項id { get; set; }
        public string? 商品id { get; set; }
        public string? 商品主圖 { get; set; }
        public string? 賣方id { get; set; }
        public string? 賣方頭像檔名 { get; set; }
        public string? 賣方暱稱 { get; set; }
        public string? 商品名稱 { get; set; }
        public string? 子項名稱 { get; set; }
        public int? 長 { get; set; }
        public int? 寬 { get; set; }
        public int? 高 { get; set; }
        public int? 子項單價 { get; set; }
    }
}
