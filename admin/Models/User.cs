using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class User
    {
        public User()
        {
            Favs = new HashSet<Fav>();
        }

        public string 會員id { get; set; } = null!;
        public string? 會員帳號 { get; set; }
        public string? 會員密碼 { get; set; }
        public string? 頭像檔名 { get; set; }
        public string? 姓名 { get; set; }
        public string? 暱稱 { get; set; }
        public string? Email { get; set; }
        /// <summary>
        /// 3碼
        /// </summary>
        public int? 郵遞區號 { get; set; }
        public string? 地址 { get; set; }
        public string? 電話 { get; set; }
        public DateTime? 註冊時間 { get; set; }
        public string? 帳號權限 { get; set; }
        public DateTime? 資料更新時間 { get; set; }
        public bool? Is啟用 { get; set; }
        public bool? Is刪除 { get; set; }
        public int? 違規次數 { get; set; }
        public string? 備註 { get; set; }

        public virtual ICollection<Fav> Favs { get; set; }
    }
}
