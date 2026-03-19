namespace WebApi2026Jmp1.Entities;

public class Account
{
    // Clave primaria (Primary Key) de la tabla Accounts.
    public int Id { get; set; }

    // Nombre de la cuenta (ejemplo: "Cuenta Sueldo").
    public string Name { get; set; } = string.Empty;

    // Saldo inicial de la cuenta (tipo decimal para dinero).
    public decimal InitialBalance { get; set; }
}
