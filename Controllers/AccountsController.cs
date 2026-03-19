using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi2026Jmp1.Data;
using WebApi2026Jmp1.DTOs;
using WebApi2026Jmp1.Entities;

namespace WebApi2026Jmp1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    // Referencia al contexto de base de datos inyectado por DI (Dependency Injection).
    private readonly AppDbContext _dbContext;

    // Constructor del controller.
    public AccountsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Endpoint: GET /api/accounts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAll()
    {
        // Lee todas las cuentas de forma asincronica.
        var accounts = await _dbContext.Accounts
            .AsNoTracking()
            .ToListAsync();

        // Devuelve 200 OK con la lista.
        return Ok(accounts);
    }

    // Endpoint: GET /api/accounts/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Account>> GetById(int id)
    {
        // Busca una cuenta por su Id de forma asincronica.
        var account = await _dbContext.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        // Si no existe, responde 404.
        if (account is null)
        {
            return NotFound();
        }

        // Si existe, responde 200 con la cuenta.
        return Ok(account);
    }

    // Endpoint: POST /api/accounts
    [HttpPost]
    public async Task<ActionResult<Account>> Create(CreateAccountDto createDto)
    {
        // Convierte DTO (Data Transfer Object) a Entity.
        var account = new Account
        {
            Name = createDto.Name,
            InitialBalance = createDto.InitialBalance
        };

        // Agrega y persiste en la base de datos.
        await _dbContext.Accounts.AddAsync(account);
        await _dbContext.SaveChangesAsync();

        // Devuelve 201 Created y la ubicacion del recurso nuevo.
        return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
    }

    // Endpoint: DELETE /api/accounts/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Busca la cuenta a eliminar.
        var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);

        // Si no existe, responde 404.
        if (account is null)
        {
            return NotFound();
        }

        // Elimina y confirma cambios.
        _dbContext.Accounts.Remove(account);
        await _dbContext.SaveChangesAsync();

        // Respuesta estandar para borrado exitoso sin body.
        return NoContent();
    }
}
