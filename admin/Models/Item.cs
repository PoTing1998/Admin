using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class Item
    {
        public Item()
        {
            Favs = new HashSet<Fav>();
            Subs = new HashSet<Sub>();
        }

        /// <summary>
        /// 格式：item-20220630123015-555555
        /// </summary>
        public string 商品id { get; set; } = null!;
        public string? 商品名稱 { get; set; }
        /// <summary>
        /// 多網址，以,分隔
        /// </summary>
        public string? 商品主圖 { get; set; }
        /// <summary>
        /// 首block內
        /// </summary>
        public string? 商品簡述 { get; set; }
        /// <summary>
        /// 下方block內
        /// </summary>
        public string? 商品詳述 { get; set; }
        /// <summary>
        /// 3碼
        /// </summary>
        public int? 商品郵遞區號 { get; set; }
        public string? 商品地址 { get; set; }
        /// <summary>
        /// （暫定）以,分層
        /// </summary>
        public string? 商品分類 { get; set; }
        /// <summary>
        /// （暫定）以,分層
        /// </summary>
        public string? 商品條件 { get; set; }
        /// <summary>
        /// 以 天 為單位，1/7/15/30/90/180/360
        /// </summary>
        public string? 租賃時間下限 { get; set; }
        /// <summary>
        /// （暫定）json，table
        /// </summary>
        public string? 商品參數 { get; set; }
        /// <summary>
        /// （暫定）會員帳號
        /// </summary>
        public string? 賣方id { get; set; }
        public int? 瀏覽次數 { get; set; }
        public string? 聯絡姓名 { get; set; }
        public string? 聯絡email { get; set; }
        public string? 聯絡電話 { get; set; }
        public string? 聯絡line { get; set; }
        /// <summary>
        /// 網址
        /// </summary>
        public string? 聯絡網址 { get; set; }
        public DateTime? 創建時間 { get; set; }
        public DateTime? 修改時間 { get; set; }
        public bool? Is啟用 { get; set; }
        public bool? Is刪除 { get; set; }

        public virtual ICollection<Fav> Favs { get; set; }
        public virtual ICollection<Sub> Subs { get; set; }
    }
}
