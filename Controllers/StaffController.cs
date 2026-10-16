using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspSakilaBackEnd.Data.Entities; // または AspSakilaBackEnd.Models
using AspSakilaBackEnd.Models.Responses;

namespace AspSakilaBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly SakilaDbContext _context;

        public StaffController(SakilaDbContext context) => _context = context;

        // GET: api/staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffResponse>>> GetStaffs()
        {
            return await _context.Staffs
                .Include(s => s.Address)
                .Select(s => new StaffResponse
                {
                    StaffId = s.StaffId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    AddressId = s.AddressId,
                    Address = s.Address != null ? s.Address.Address1 : null,
                    Email = s.Email,
                    StoreId = s.StoreId,
                    // bool? の null 対策（null の場合は false 扱い）
                    Active = s.Active ?? false,
                    Username = s.Username,
                    LastUpdate = s.LastUpdate,
                    HasPicture = s.Picture != null && s.Picture.Length > 0
                })
                .ToListAsync();
        }

        // GET: api/staff/1
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffResponse>> GetStaff(byte id)
        {
            var staff = await _context.Staffs
                .Include(s => s.Address)
                .Where(s => s.StaffId == id)
                .Select(s => new StaffResponse
                {
                    StaffId = s.StaffId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    AddressId = s.AddressId,
                    Address = s.Address != null ? s.Address.Address1 : null,
                    Email = s.Email,
                    StoreId = s.StoreId,
                    Active = s.Active ?? false,
                    Username = s.Username,
                    LastUpdate = s.LastUpdate,
                    HasPicture = s.Picture != null && s.Picture.Length > 0
                })
                .FirstOrDefaultAsync();

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }
    }
}