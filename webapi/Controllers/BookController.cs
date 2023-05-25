namespace webapi.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.Model;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase {
    IRepository<Book> repository;

    public BookController(IRepository<Book> repository) {
        this.repository = repository;
    }

    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<Book> Get() {
        return repository.GetAll().ToArray();
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public Book? Get(int id) {
        return repository.GetById(id);
    }
}
