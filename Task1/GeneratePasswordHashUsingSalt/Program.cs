// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Hash My Password!");

var passwordText = "thisissomepassword";
var saltText = "thisissomesalttohashthepassword";
byte[] salt = Encoding.ASCII.GetBytes(saltText);
var passwordHash = GeneratePasswordHashUsingSalt(passwordText, salt);

Console.WriteLine($"Here is your hashed password: {passwordHash}");
Console.WriteLine("Press ENTER to exit.");
Console.ReadLine();

string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
{
    var iterate = 10000;
    var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
    byte[] hash = pbkdf2.GetBytes(20);

    byte[] hashBytes = new byte[36];
    Array.Copy(salt, 0, hashBytes, 0, 16);
    Array.Copy(hash, 0, hashBytes, 16, 20);

    var passwordHash = Convert.ToBase64String(hashBytes);

    return passwordHash;
}