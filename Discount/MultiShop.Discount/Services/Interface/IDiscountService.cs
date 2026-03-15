using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Services.Interface
{
    public interface IDiscountService
    {
            Task<IEnumerable<ResultCouponDto>> GetAllCouponsAsync(int page , int pageSize);
            Task<GetByIdCouponDto> GetCouponByIdAsync(int id);
            Task AddCouponAsync(CreateCouponDto createCoupon);
            Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
            Task DeleteCouponAsync(int id);
    }
}
