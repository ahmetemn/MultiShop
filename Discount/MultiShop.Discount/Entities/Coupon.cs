using MultiShop.Discount.Entities.Abstract;

namespace MultiShop.Discount.Entities
{
    public class Coupon:Base
    {

        public string Code { get; set; }

        public int Rate { get; set; }

        public  bool IsActive { get; set; }

        public DateTime ValidDate { get; set; }
    }
}
