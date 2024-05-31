using Microsoft.AspNetCore.DataProtection;

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
        public string UnProtect(string valueToDecrypt) => _encryptor.Unprotect(valueToDecrypt);
    }
}
