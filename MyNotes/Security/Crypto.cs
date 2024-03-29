using System.Security.Cryptography;
using System.Text;

namespace MyNotes.Security;

public class Crypto{

  private readonly byte[] _key;

  public Crypto(string key)
    => _key = Encoding.ASCII.GetBytes(key);

  public static string Encrypt(string simpletext, byte[] key, byte[] iv){
    byte[] cipheredtext;
    
    using (Aes aes = Aes.Create()){

      ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
      
      using (MemoryStream memoryStream = new MemoryStream()){
        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        {
          using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
          {
            streamWriter.Write(simpletext);
          }
 
          cipheredtext = memoryStream.ToArray();
        }
      }
    }
    return cipheredtext.ToString();
  }

  public static string Decrypt(byte[] cipheredtext, byte[] key, byte[] iv){
    string simpletext = String.Empty;
    using (Aes aes = Aes.Create())
    {
      ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
      using (MemoryStream memoryStream = new MemoryStream(cipheredtext))
      {
        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        {
          using (StreamReader streamReader = new StreamReader(cryptoStream))
          {
            simpletext = streamReader.ReadToEnd();
          }
        }
      }
    }
    return simpletext;
  }
}
