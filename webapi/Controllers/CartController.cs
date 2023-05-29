namespace webapi.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Command.AddBookToCart;
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

    public CartController(
        IUserRepository userRepository,
        IBookRepository bookRepository,
        ICartRepository cartRepository
    ){
        this.userRepository = userRepository;
        this.bookRepository = bookRepository;
        this.cartRepository = cartRepository;
    }

    [HttpGet]
    public IActionResult Get() {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }

        Cart? cart = cartRepository.GetByUserId(Int32.Parse(userId));

        return Ok(new {
            Cart = cart
        });
    }

    [HttpPost("Add")]
    public IActionResult AddBookToCart([FromBody] AddBookToCartRequest request) {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }

        new AddBookToCartCommand(bookRepository, cartRepository).Execute(request);

        return Ok();
    }
}
