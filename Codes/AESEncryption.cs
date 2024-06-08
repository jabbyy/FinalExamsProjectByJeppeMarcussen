namespace Svendeprøve_projekt_BodyFitBlazor.Codes
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class AESEncryption
    {
        private byte[] key;

        public AESEncryption(byte[] encryptionKey)
        {
            key = encryptionKey;
        }

        public string EncryptString(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.GenerateIV(); // Generate a random IV for each encryption

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encrypted;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                        csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                    }

                    encrypted = msEncrypt.ToArray();
                }

                // Combine IV and encrypted data
                byte[] result = new byte[aesAlg.IV.Length + encrypted.Length];
                Array.Copy(aesAlg.IV, 0, result, 0, aesAlg.IV.Length);
                Array.Copy(encrypted, 0, result, aesAlg.IV.Length, encrypted.Length);

                return Convert.ToBase64String(result);
            }
        }

        public string DecryptString(string encryptedText)
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

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                string plaintext = null;

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

                return plaintext;
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

    }

}
