namespace webapi.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Command.AddBookToCart;
using webapi.Application.Command.Checkout;
using webapi.Application.Command.RemoveBookFromCart;
using webapi.Application.Query.Payment.BookInCart;
using webapi.Application.Query.Payment.Cart;
using webapi.Domain.Account.Repository;
using webapi.Domain.Catalogue.Repository;
using webapi.Domain.Payment.Repository;
using webapi.Domain.Reservation.Repository;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CartController : ControllerBase {
    IUserRepository userRepository;
    IBookRepository bookRepository;
    ICartRepository cartRepository;
    IReservationRepository reservationRepository;
    ICartQuery cartQuery;
    IBookInCartQuery bookInCartQuery;

    public CartController(
        IUserRepository userRepository,
        IBookRepository bookRepository,
        ICartRepository cartRepository,
        IReservationRepository reservationRepository,
        ICartQuery cartQuery,
        IBookInCartQuery bookInCartQuery
    ){
        this.userRepository = userRepository;
        this.bookRepository = bookRepository;
        this.cartRepository = cartRepository;
        this.reservationRepository = reservationRepository;
        this.cartQuery = cartQuery;
        this.bookInCartQuery = bookInCartQuery;
    }

    [HttpGet]
    public IActionResult Get() {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }

        return Ok(new {
            Cart = cartQuery.Execute(Int32.Parse(userId))
        });
    }

    [HttpGet("{bookId}")]
    public IActionResult Get(int bookId) {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }

        return Ok(new {
            Book = bookInCartQuery.Execute(Int32.Parse(userId), bookId)
        });
    }

    [HttpPost("Add/{bookId}")]
    public IActionResult AddBookToCart(int bookId) {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }

        new AddBookToCartCommand(bookRepository, cartRepository).Execute(new AddBookToCartRequest() {
            UserId = Int32.Parse(userId),
            BookId = bookId
        });

        return Ok();
    }

    [HttpPost("Remove/{bookId}")]
    public IActionResult RemoveBookFromCart(int bookId) {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }

        new RemoveBookFromCartCommand(bookRepository, cartRepository).Execute(new RemoveBookFromCartRequest() {
            UserId = Int32.Parse(userId),
            BookId = bookId
        });

        return Ok();
    }

    [HttpPost("Checkout")]
    public IActionResult Checkout() {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }

        CheckoutCommand checkoutCommand = new CheckoutCommand(cartRepository, reservationRepository);
        checkoutCommand.Execute(new CheckoutRequest() {
            UserId = Int32.Parse(userId)
        });

        return Ok();
    }
}
