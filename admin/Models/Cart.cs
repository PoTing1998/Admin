using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class Cart
    {
        /// <summary>
        /// 格式：cart-20220630123015-555555
        /// </summary>
        public string 購物車項目id { get; set; } = null!;
        /// <summary>
        /// 格式：sub-20220630123015-555555
        /// </summary>
        public string? 子項id { get; set; }
        public int? 數量 { get; set; }
        public string? 會員id { get; set; }
        public bool? Is刪除 { get; set; }
        public bool? Is結帳 { get; set; }
    }
}
