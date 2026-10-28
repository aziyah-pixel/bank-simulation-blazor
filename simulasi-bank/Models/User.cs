namespace simulasi_bank.Models;

public enum UserRole
{
    Teller,
    Nasabah
}

public class User
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string NamaLengkap { get; set; } = string.Empty;
    public UserRole Role { get; set; }

    // Properti khusus untuk Nasabah:
    public string NomorRekening { get; set; } = string.Empty;
    public decimal Saldo { get; set; } = 0;
}