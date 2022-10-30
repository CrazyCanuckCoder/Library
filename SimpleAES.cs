using System;
using System.Security.Cryptography;
using System.IO;

namespace Library
{
    /// <summary>
    /// Use this class to encrypt and decrypt text strings.
    /// </summary>
    /// 
    /// <remarks>
    /// Original code written by Mark Brittingham in a post on Stack Overflow.
    /// http://stackoverflow.com/questions/165808/simple-2-way-encryption-for-c-sharp/212707#212707
    /// 
    /// Modified by user cristoph on Stack Overflow to include a salt value.
    /// http://stackoverflow.com/questions/2449263/aes-two-way-encryption-with-salting?rq=1
    /// </remarks>
    /// 
    public class SimpleAES
    {
        // Change these keys
        private readonly byte[] _key = { 123, 10, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 223, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 56, 209 };
        private readonly byte[] _vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 106, 112, 79, 72, 114, 156 };
        private const int Salt = 8;

        private readonly ICryptoTransform _encryptorTransform;
        private readonly ICryptoTransform _decryptorTransform;
        private readonly System.Text.UTF8Encoding _utfEncoder;

        public SimpleAES()
        {
            //This is our encryption method
            RijndaelManaged rm = new RijndaelManaged();

            //Create an encryptor and a decryptor using our encryption method, key, and vector.
            _encryptorTransform = rm.CreateEncryptor(_key, _vector);
            _decryptorTransform = rm.CreateDecryptor(_key, _vector);

            //Used to translate bytes to text and vice versa
            _utfEncoder = new System.Text.UTF8Encoding();
        }

        /// -------------- Two Utility Methods (not used but may be useful) -----------
        /// Generates an encryption key.
        static public byte[] GenerateEncryptionKey()
        {
            //Generate a Key.
            RijndaelManaged rm = new RijndaelManaged();
            rm.GenerateKey();
            return rm.Key;
        }

        /// Generates a unique encryption vector
        static public byte[] GenerateEncryptionVector()
        {
            //Generate a Vector
            RijndaelManaged rm = new RijndaelManaged();
            rm.GenerateIV();
            return rm.IV;
        }


        /// ----------- The commonly used methods ------------------------------   
        /// Encrypt some text and return a string suitable for passing in a URL.
        public string EncryptString(string TextValue)
        {
            return (TextValue != "") ? Convert.ToBase64String(Encrypt(TextValue)) : "";
        }

        /// Encrypt some text and return an encrypted byte array.
        private byte[] Encrypt(string TextValue)
        {
            //Translates our text value into a byte array.
            Byte[] pepper = _utfEncoder.GetBytes(TextValue);
            // add salt
            Byte[] salt = new byte[Salt];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(salt);
            Byte[] bytes = new byte[2 * Salt + pepper.Length];
            System.Buffer.BlockCopy(salt, 0, bytes, 0, Salt);
            System.Buffer.BlockCopy(pepper, 0, bytes, Salt, pepper.Length);
            crypto.GetNonZeroBytes(salt);
            System.Buffer.BlockCopy(salt, 0, bytes, Salt + pepper.Length, Salt);

            //Used to stream the data in and out of the CryptoStream.
            MemoryStream memoryStream = new MemoryStream();

            /*
             * We will have to write the unencrypted bytes to the stream,
             * then read the encrypted result back from the stream.
             */
            #region Write the decrypted value to the encryption stream
            CryptoStream cs = new CryptoStream(memoryStream, _encryptorTransform, CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.FlushFinalBlock();
            #endregion

            #region Read encrypted value back out of the stream
            memoryStream.Position = 0;
            byte[] encrypted = new byte[memoryStream.Length];
            memoryStream.Read(encrypted, 0, encrypted.Length);
            #endregion

            //Clean up.
            cs.Close();
            memoryStream.Close();

            return encrypted;
        }

        /// The other side: Decryption methods
        public string DecryptString(string EncryptedString)
        {
            return (EncryptedString != "") ? Decrypt(Convert.FromBase64String(EncryptedString)) : "";
        }

        /// Decryption when working with byte arrays.    
        private string Decrypt(byte[] EncryptedValue)
        {
            #region Write the encrypted value to the decryption stream
            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream decryptStream = new CryptoStream(encryptedStream, _decryptorTransform, CryptoStreamMode.Write);
            decryptStream.Write(EncryptedValue, 0, EncryptedValue.Length);
            decryptStream.FlushFinalBlock();
            #endregion

            #region Read the decrypted value from the stream.
            encryptedStream.Position = 0;
            Byte[] decryptedBytes = new Byte[encryptedStream.Length];
            encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
            encryptedStream.Close();
            #endregion
            // remove salt
            int len = decryptedBytes.Length - 2 * Salt;
            Byte[] pepper = new Byte[len];
            System.Buffer.BlockCopy(decryptedBytes, Salt, pepper, 0, len);
            return _utfEncoder.GetString(pepper);
        }
    }
}
