namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.Model;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase {
    IRepository<Book> repository;

    public BookController(IRepository<Book> repository) {
        this.repository = repository;
    }

    [HttpGet]
    public IEnumerable<Book> Get() {
        return repository.GetAll().ToArray();
    }

    [HttpGet("{id}")]
    public Book? Get(int id) {
        return repository.GetById(id);
    }
}
