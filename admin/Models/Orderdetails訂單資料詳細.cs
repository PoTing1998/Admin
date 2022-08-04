using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class Orderdetails訂單資料詳細
    {
        public string 訂單id { get; set; } = null!;
        public int? 子項獨立編號 { get; set; }
        public int? 付款金額 { get; set; }
        public DateTime? 創建時間 { get; set; }
        public string? 下單id { get; set; }
        public string? 訂單留言 { get; set; }
        public string? 付款方式 { get; set; }
        public string? 折扣代碼 { get; set; }
        public int? 折扣數據 { get; set; }
        public string? 付款id { get; set; }
        public DateTime? 啟用日期 { get; set; }
        public DateTime? 停用日期 { get; set; }
        public string? 商品id快照 { get; set; }
        public string? 商品名稱快照 { get; set; }
        public string? 子項名稱快照 { get; set; }
        public int? 長快照 { get; set; }
        public int? 寬快照 { get; set; }
        public int? 高快照 { get; set; }
        public int? 商品郵遞區號快照 { get; set; }
        public string? 商品地址快照 { get; set; }
        public string 商品主圖快照 { get; set; } = null!;
        public bool? Is買方取消 { get; set; }
        public bool? Is賣方取消 { get; set; }
        public string? 賣方id { get; set; }
        public string? 賣方暱稱 { get; set; }
    }
}
