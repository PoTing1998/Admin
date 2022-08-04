using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class OrderOrdering
    {
        public string 訂單id { get; set; } = null!;
        public string? 商品id快照 { get; set; }
        public string? 子項id快照 { get; set; }
        public string? 商品名稱快照 { get; set; }
        public string? 子項名稱快照 { get; set; }
        public string 商品主圖快照 { get; set; } = null!;
        /// <summary>
        /// 舉例：子項(頭等倉)有10格，此處存編號3的格子位置
        /// </summary>
        public int? 子項獨立編號 { get; set; }
        public int? 長快照 { get; set; }
        public int? 寬快照 { get; set; }
        public int? 高快照 { get; set; }
        public DateTime? 啟用日期 { get; set; }
        public DateTime? 停用日期 { get; set; }
        /// <summary>
        /// 3碼
        /// </summary>
        public int? 商品郵遞區號快照 { get; set; }
        public string? 商品地址快照 { get; set; }
        public bool? Is買方取消 { get; set; }
        public bool? Is賣方取消 { get; set; }
        public int No { get; set; }

        public virtual OrderInfo 訂單 { get; set; } = null!;
    }
}
