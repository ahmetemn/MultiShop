using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Context
{
    public class SeedData
    {
        private readonly DapperContext _context;

        public SeedData(DapperContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            using var connection = _context.CreateConnection();

            // Tablo boşsa ekle
            var count = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Coupons");
            if (count > 0) return;

            string query = @"INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) 
                             VALUES (@Code, @Rate, @IsActive, @ValidDate)";

            var coupons = new List<object>
            {
                new { Code = "HOSGELDIN10",    Rate = 10, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(3) },
                new { Code = "YAZ20",          Rate = 20, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(2) },
                new { Code = "ILKALISVERIS15", Rate = 15, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(1) },
                new { Code = "SUPER25",        Rate = 25, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(4) },
                new { Code = "MEGA30",         Rate = 30, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(2) },
                new { Code = "FLASH5",         Rate = 5,  IsActive = true,  ValidDate = DateTime.UtcNow.AddDays(7)  },
                new { Code = "VIP50",          Rate = 50, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(6) },
                new { Code = "HEDIYE40",       Rate = 40, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(5) },
                new { Code = "INDIRIM18",      Rate = 18, IsActive = false, ValidDate = DateTime.UtcNow.AddMonths(1) },
                new { Code = "OZEL22",         Rate = 22, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(3) },
                new { Code = "BIRAHAT8",       Rate = 8,  IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(2) },
                new { Code = "SONBAHAR11",     Rate = 11, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(2) },
                new { Code = "KIS45",          Rate = 45, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(3) },
                new { Code = "BAHAR12",        Rate = 12, IsActive = true,  ValidDate = DateTime.UtcNow.AddDays(45) },
                new { Code = "YILBASI60",      Rate = 60, IsActive = false, ValidDate = DateTime.UtcNow.AddDays(15) },
                new { Code = "ANNELER20",      Rate = 20, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(1) },
                new { Code = "SEVGILILER35",   Rate = 35, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(5) },
                new { Code = "OGRENCI10",      Rate = 10, IsActive = true,  ValidDate = DateTime.UtcNow.AddMonths(4) },
                new { Code = "KURUMSAL55",     Rate = 55, IsActive = false, ValidDate = DateTime.UtcNow.AddMonths(6) },
                new { Code = "HAFTALIK7",      Rate = 7,  IsActive = true,  ValidDate = DateTime.UtcNow.AddDays(7)  },
            };

            await connection.ExecuteAsync(query, coupons); // ✅ hepsini tek seferde ekler
        }
    }
}