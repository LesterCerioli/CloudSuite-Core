using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class JwtToken : Entity, IAggregateRoot
    {
        public string? EncryptedToken { get; private set; }
        public string? PublicKey { get; private set; }
        public string? PrivateKey { get; private set; }

        public JwtToken(string encryptedToken, string publicKey, string privateKey)
        {
            EncryptedToken = encryptedToken;
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public string EncryptToken(string token)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Import the public key
                rsa.FromXmlString(PublicKey);

                // Convert the token to bytes
                byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(token);

                // Encrypt the token
                byte[] encryptedBytes = rsa.Encrypt(bytesToEncrypt, false);

                // Convert the encrypted bytes to a base64 string
                string encryptedToken = Convert.ToBase64String(encryptedBytes);

                // Set the encrypted token in the entity
                EncryptedToken = encryptedToken;

                return encryptedToken;
            }

        }

        public string DecryptToken()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Import the private key
                rsa.FromXmlString(PrivateKey);

                // Convert the base64 encrypted token to bytes
                byte[] encryptedBytes = Convert.FromBase64String(EncryptedToken);

                // Decrypt the token
                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false);

                // Convert the decrypted bytes to a UTF-8 string
                string decryptedToken = Encoding.UTF8.GetString(decryptedBytes);

                return decryptedToken;
            }
        }
    }
}
