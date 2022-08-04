using System;
using System.Collections.Generic;

namespace admin.Models
{
    public partial class OrderInfo
    {
        public OrderInfo()
        {
            OrderOrderings = new HashSet<OrderOrdering>();
        }

        public string 訂單id { get; set; } = null!;
        public int? 付款金額 { get; set; }
        public DateTime? 創建時間 { get; set; }
        public string? 下單id { get; set; }
        public string? 訂單留言 { get; set; }
        public string? 付款方式 { get; set; }
        public string? 折扣代碼 { get; set; }
        public int? 折扣數據 { get; set; }
        /// <summary>
        /// payment-20220630123015-666666
        /// </summary>
        public string? 付款id { get; set; }

        public virtual ICollection<OrderOrdering> OrderOrderings { get; set; }
    }
}
