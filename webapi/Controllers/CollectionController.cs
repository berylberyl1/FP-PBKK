namespace webapi.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Query.Reservation.Reservation;
using webapi.Domain.Reservation.Repository;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CollectionController : ControllerBase {
    IReservationRepository reservationRepository;
    IReservationQuery reservationQuery;

    public CollectionController(
        IReservationRepository reservationRepository,
        IReservationQuery reservationQuery
    ){
        this.reservationRepository = reservationRepository;
        this.reservationQuery = reservationQuery;
    }

    [HttpGet]
    public IActionResult Get() {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }

        return Ok(new {
            Collection = reservationQuery.Execute(Int32.Parse(userId))
        });
    }
}
