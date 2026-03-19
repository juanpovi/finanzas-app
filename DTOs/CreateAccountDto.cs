namespace WebApi2026Jmp1.DTOs;

public class CreateAccountDto
{
    // Nombre de la cuenta enviado por el cliente.
    public string Name { get; set; } = string.Empty;

    // Saldo inicial enviado por el cliente.
    public decimal InitialBalance { get; set; }
}
