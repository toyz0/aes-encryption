using Encryption;

internal class Program
{
    /// <summary>
    /// Example of usage
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        string plaintext = "My Plaintext";
        string encryptedText = AES.Encrypt(plaintext);
        string decryptedText = AES.Decrypt(encryptedText);

        Console.WriteLine("Plaintext: {0}", plaintext);
        Console.WriteLine("Encrypted text: {0}", encryptedText);
        Console.WriteLine("Decrypted text: {0}", decryptedText);

        Console.ReadKey();
    }
}