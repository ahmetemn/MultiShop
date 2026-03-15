using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Interface;

namespace MultiShop.Discount.Services.Concrate
{
    public class DiscountService : IDiscountService
    {


        private readonly DapperContext _context;    

        public DiscountService(DapperContext context)
        {
            _context = context;
        }
        public async Task AddCouponAsync(CreateCouponDto createCouponDto)
        {
            string query =  "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("Code", createCouponDto.Code);
            parameters.Add("Rate", createCouponDto.Rate);
            parameters.Add("IsActive", createCouponDto.IsActive);
            parameters.Add("ValidDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<ResultCouponDto>> GetAllCouponsAsync(int page, int pageSize)
        {
            string query = "SELECT Id, Code, Rate, IsActive, ValidDate FROM Coupons ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            var parameters = new DynamicParameters();
            parameters.Add("Offset", (page - 1) * pageSize);
        
            parameters.Add("PageSize", pageSize);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ResultCouponDto>(query, new
                {
                    Offset = (page - 1) * pageSize,
                    PageSize = pageSize
                });
            }

        }

        public async Task<GetByIdCouponDto> GetCouponByIdAsync(int id)
        {
            string query = "SELECT Id, Code, Rate, IsActive, ValidDate FROM Coupons WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, new { Id = id });
      
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", updateCouponDto.Id);
            parameters.Add("Code", updateCouponDto.Code);
            parameters.Add("Rate", updateCouponDto.Rate);
            parameters.Add("IsActive", updateCouponDto.IsActive);

            using (var connection = _context.CreateConnection())
            {

                await connection.ExecuteAsync(query, new
                {
                    updateCouponDto.Id,
                    updateCouponDto.Code,
                    updateCouponDto.Rate,
                    updateCouponDto.IsActive,
                    updateCouponDto.ValidDate  
                });

            }
        }
    }
}
