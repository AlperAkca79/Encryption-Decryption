namespace Encryption_Decryption {
    public static class Program {
        public static void Main(string[] args) {
            // Encryption - Decryption Methods
            Encryption encryption = new Encryption();
            Decryption decryption = new Decryption();

            bool showAgain = true;
            while (showAgain)
            {
                Console.WriteLine("What do you want? Encryption-Decryption (e/d)");
                char userOption = Convert.ToChar(Console.ReadLine());

                switch (userOption) {
                    case 'e':
                        encryption.StartEncrypt();
                        break;
                    case 'd':
                        decryption.StartDecrypt();
                        break;
                    default:
                        Console.WriteLine("Please enter valid value! Press any key to try again.");
                        break;
                }
            }
            Console.ReadKey();     
        }
    }
}