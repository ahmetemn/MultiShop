using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Interface;

namespace MultiShop.Discount.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
       
        private readonly IDiscountService _discountService;
            public DiscountController(IDiscountService discountService)
            {
                _discountService = discountService;
            }
    
            [HttpGet]
            public async Task<IActionResult> GetAllCoupons(int page = 1, int pageSize = 10)
            {
                var coupons = await _discountService.GetAllCouponsAsync(page, pageSize);
                return Ok(coupons);
            }
    
            [HttpGet("{id}")]
            public async Task<IActionResult> GetCouponById(int id)
            {
                var coupon = await _discountService.GetCouponByIdAsync(id);
                if (coupon == null)
                {
                    return NotFound();
                }
                return Ok(coupon);
            }
    
            [HttpPost]
            public async Task<IActionResult> AddCoupon(CreateCouponDto createCouponDto)
            {
                await _discountService.AddCouponAsync(createCouponDto);
                return StatusCode(201);
            }
    
            [HttpPut]
            public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
            {
                await _discountService.UpdateCouponAsync(updateCouponDto);
                return Ok();
            }
    
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCoupon(int id)
            {
                await _discountService.DeleteCouponAsync(id);
                return Ok();
        }

    }
}
