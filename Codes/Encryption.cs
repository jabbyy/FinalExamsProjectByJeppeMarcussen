using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;

namespace Svendeprøve_projekt_BodyFitBlazor.Codes
{
    public class Encryption
    {
        private readonly IDataProtector _encryptor;

        public Encryption(IDataProtectionProvider protector)
        {
            _encryptor = protector.CreateProtector("H5-projekt-2023.codes.EncryptionTest.JeppeMarcussen");
        }
        public string Protect(string valueToEncrypt) => _encryptor.Protect(valueToEncrypt);
        public string UnProtect(string valueToDecrypt)
        {
            try
            {
                if (string.IsNullOrEmpty(valueToDecrypt))
                {
                    // Handle empty or null input
                    return string.Empty;
                }

                return _encryptor.Unprotect(valueToDecrypt);
            }
            catch (CryptographicException ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"CryptographicException: {ex.Message}");
                // You can also throw a custom exception or return a default value
                throw new Exception("Error decrypting data. Please check the input.");
            }
            catch (FormatException ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"FormatException: {ex.Message}");
                // You can throw a custom exception or return a default value
                throw new Exception("Error decrypting data due to invalid input length.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
    }
}
