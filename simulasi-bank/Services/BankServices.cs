using simulasi_bank.Models;

namespace simulasi_bank.Services;

public class BankService
{
    // Daftar user yang ada di sistem (disimpan sementara di memori)
    private readonly List<User> _users = new()
    {
        // Akun bawaan untuk Teller:
        new User
        {
            Username = "teller1",
            Password = "123",
            NamaLengkap = "Siti (Teller)",
            Role = UserRole.Teller
        },
        // Akun contoh untuk Nasabah:
        new User
        {
            Username = "budi",
            Password = "123",
            NamaLengkap = "Budi Santoso",
            Role = UserRole.Nasabah,
            NomorRekening = "1001234567",
            Saldo = 500000 // Saldo awal Rp 500.000
        }
    };

    // Menyimpan data user yang sedang login saat ini
    public User? CurrentUser { get; private set; }

    // Fungsi untuk mengecek login
    public User? Login(string username, string password)
    {
        var user = _users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && 
            u.Password == password);

        if (user != null)
        {
            CurrentUser = user;
        }

        return user;
    }

    // Fungsi untuk logout
    public void Logout()
    {
        CurrentUser = null;
    }

    // Fungsi agar Teller bisa membuat akun nasabah baru (akan kita pakai nanti di halaman Teller)
    public bool CreateNasabah(User newNasabah)
    {
        // Pastikan username belum dipakai
        if (_users.Any(u => u.Username.Equals(newNasabah.Username, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        newNasabah.Role = UserRole.Nasabah;
        _users.Add(newNasabah);
        return true;
    }

    // Fungsi untuk melihat semua daftar nasabah (khusus Teller)
    public List<User> GetAllNasabah()
    {
        return _users.Where(u => u.Role == UserRole.Nasabah).ToList();
    }
}