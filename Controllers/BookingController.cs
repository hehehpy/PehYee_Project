using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PehYee_Project.Data;
using PehYee_Project.Models;

namespace PehYee_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ADBC _context;

        public BookingController(ADBC context)
        {
            _context = context;
        }

        [Authorize(Roles = UserRoles.Admin)]

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Bookings);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            var booking = _context.Bookings.FirstOrDefault(e => e.BookingID == id);
            if (booking == null)
                return Problem(detail: "Booking with ID" + id + " is not found. ", statusCode: 404);
            return Ok(booking);
        }

        [HttpPost]
        public IActionResult Post(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return CreatedAtAction("GetAll", new { id = booking.BookingID }, booking);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Booking booking)
        {
            var entity = _context.Bookings.FirstOrDefault(e => e.BookingID == id);
            if (entity == null)
                return NotFound($"Booking with ID {id} not found.");

            entity.FacilityDescription = booking.FacilityDescription;
            entity.BookingDateFrom = booking.BookingDateFrom;
            entity.BookingDateTo = booking.BookingDateTo;
            entity.BookedBy = booking.BookedBy;
            entity.BookingStatus = booking.BookingStatus;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingID == id);
            if (booking == null) return NotFound();

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
