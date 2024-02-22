using System.Text;
using XSystem.Security.Cryptography;

namespace Notes.CryptoService
{
    public static class StringHasher
    {
        public static string Hash(string inputString)
        {
            var mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            // ASCII e property na Encoding clasata koe vrakja instanca od ASCIIEncoding klasa koja pak nasleduva od Encoding i zatoa preku nea mozeme da ja povikame GetBytes metodata(metoda definirana vo Encoding)
            byte[] passwordBytes = Encoding.ASCII.GetBytes(inputString);
            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            return Encoding.ASCII.GetString(hashedBytes);   

        }
    }
}
