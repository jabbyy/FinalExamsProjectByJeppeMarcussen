namespace Svendeprøve_projekt_BodyFitBlazor.Codes
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class AESEncryption
    {
        private readonly byte[] key;

        public AESEncryption(byte[] encryptionKey)
        {
            key = encryptionKey ?? throw new ArgumentNullException(nameof(encryptionKey));
        }

        public string showException { get; set; }
        public string showException2 { get; set; }
        public string originalPlainText { get; set; }
        public string encryptedText1 { get; set; }
        public string decryptedText1 { get; set; }

        public string EncryptString(string plainText)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.GenerateIV(); // Generate a random IV for each encryption
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    byte[] encrypted;
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                            csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                            csEncrypt.FlushFinalBlock(); // Ensure all data is written
                        }

                        encrypted = msEncrypt.ToArray();
                    }

                    // Combine IV and encrypted data
                    byte[] result = new byte[aesAlg.IV.Length + encrypted.Length];
                    Array.Copy(aesAlg.IV, 0, result, 0, aesAlg.IV.Length);
                    Array.Copy(encrypted, 0, result, aesAlg.IV.Length, encrypted.Length);

                    Console.WriteLine($"Encryption successful. IV: {Convert.ToBase64String(aesAlg.IV)} Encrypted Data: {Convert.ToBase64String(encrypted)}");

                    return Convert.ToBase64String(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Encryption error: {ex.Message}");
                showException = ex.Message;
                return null;
            }
        }

        public string DecryptString(string encryptedText)
        {
            try
            {
                byte[] encryptedData = Convert.FromBase64String(encryptedText);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;

                    byte[] iv = new byte[aesAlg.BlockSize / 8];
                    byte[] cipherText = new byte[encryptedData.Length - iv.Length];

                    Array.Copy(encryptedData, iv, iv.Length);
                    Array.Copy(encryptedData, iv.Length, cipherText, 0, cipherText.Length);

                    aesAlg.IV = iv;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                string plaintext = srDecrypt.ReadToEnd();
                                Console.WriteLine($"Decryption successful. IV: {Convert.ToBase64String(iv)} Plaintext: {plaintext}");
                                return plaintext;
                            }
                        }
                    }
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Decryption error (cryptographic): {ex.Message}");
                showException = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Decryption error: {ex.Message}");
                showException2 = ex.Message;
                return null;
            }
        }


        public byte[] EncryptNumber(int number, byte[] key, byte[] iv)
        {
            byte[] numberBytes = BitConverter.GetBytes(number);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encrypted;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(numberBytes, 0, numberBytes.Length);
                    }

                    encrypted = msEncrypt.ToArray();
                }

                return encrypted;
            }
        }




        public int DecryptNumber(byte[] encryptedNumber, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] decrypted;

                using (MemoryStream msDecrypt = new MemoryStream(encryptedNumber))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream msPlain = new MemoryStream())
                        {
                            csDecrypt.CopyTo(msPlain);
                            decrypted = msPlain.ToArray();
                        }
                    }
                }

                return BitConverter.ToInt32(decrypted, 0);
            }
        }

        public void TestEncryptionDecryption()
        {
            // Ensure the key is exactly 32 bytes long
            var encryptionKey = Encoding.UTF8.GetBytes("YourSecureKeyOf32Characters!1234");
            var aesService = new AESEncryption(encryptionKey);

            string plainText = "Test string for encryption";
            string encryptedText = aesService.EncryptString(plainText);
            string decryptedText = aesService.DecryptString(encryptedText);

            originalPlainText = $"Original: {plainText}";
            encryptedText1 = $"Encrypted: {encryptedText}";
            decryptedText1 = $"Decrypted: {decryptedText}";

            if (plainText == decryptedText)
            {
                Console.WriteLine("Encryption and decryption successful and match.");
            }
            else
            {
                Console.WriteLine("Mismatch between original and decrypted text.");
            }
        }

    }
    
}
