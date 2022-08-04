using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class Sub
    {
        /// <summary>
        /// 格式：sub-20220630123015-555555
        /// </summary>
        public string 子項id { get; set; } = null!;
        /// <summary>
        /// 格式：item-20220630123015-555555
        /// </summary>
        public string? 商品id { get; set; }
        public string? 子項名稱 { get; set; }
        /// <summary>
        /// 一個網址
        /// </summary>
        public string? 子項主圖 { get; set; }
        public string? 子項簡述 { get; set; }
        public int? 子項數量 { get; set; }
        public int? 子項單價 { get; set; }
        public int? 長 { get; set; }
        public int? 寬 { get; set; }
        public int? 高 { get; set; }
        public DateTime? 創建時間 { get; set; }
        public bool? Is啟用 { get; set; }
        public bool? Is刪除 { get; set; }

        public virtual Item? 商品 { get; set; }
    }
}
