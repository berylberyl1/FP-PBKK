namespace webapi.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Command.AddBookToCart;
using webapi.Application.Query.Payment.Cart;
using webapi.Domain.Account.Repository;
using webapi.Domain.Catalogue.Repository;
using webapi.Domain.Payment.Model.Cart;
using webapi.Domain.Payment.Repository;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CartController : ControllerBase {
    IUserRepository userRepository;
    IBookRepository bookRepository;
    ICartRepository cartRepository;
    ICartQuery cartQuery;

    public CartController(
        IUserRepository userRepository,
        IBookRepository bookRepository,
        ICartRepository cartRepository,
        ICartQuery cartQuery
    ){
        this.userRepository = userRepository;
        this.bookRepository = bookRepository;
        this.cartRepository = cartRepository;
        this.cartQuery = cartQuery;
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
}
