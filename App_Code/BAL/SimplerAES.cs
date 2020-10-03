using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SimplerAES
/// </summary>
public class SimplerAES
{
	public SimplerAES()
	{
        
	}

    public string Decrypt(string EncryptedText)
    {
        string dummyData = EncryptedText.Trim().Replace(" ", "+");
        if (dummyData.Length % 4 > 0)
            dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');
        byte[] encryptedTextBytes = Convert.FromBase64String(dummyData); 

        //byte[] encryptedTextBytes = Convert.FromBase64String(EncryptedText);

        MemoryStream ms = new MemoryStream();
        SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
        byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzmdalyglrj");
        byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbhczfeultgbskdmaunivmfuo");
        CryptoStream cs = new CryptoStream(ms, rijn.CreateDecryptor(key, rgbIV), CryptoStreamMode.Write);
        cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
        cs.Close();
        return Encoding.UTF8.GetString(ms.ToArray());

    }

    public string Encrypt(string ClearText)
    {
        byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);
        SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
        MemoryStream ms = new MemoryStream();
        byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzmdalyglrj");
        byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbhczfeultgbskdmaunivmfuo");
        CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV),CryptoStreamMode.Write);
        cs.Write(clearTextBytes, 0, clearTextBytes.Length);
        cs.Close();
        return Convert.ToBase64String(ms.ToArray());
    }

}