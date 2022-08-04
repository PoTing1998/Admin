using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class Fav
    {
        /// <summary>
        /// 格式：item-20220630123015-555555
        /// </summary>
        public string 商品id { get; set; } = null!;
        public string 會員id { get; set; } = null!;
        public int No { get; set; }

        public virtual Item 商品 { get; set; } = null!;
        public virtual User 會員 { get; set; } = null!;
    }
}
