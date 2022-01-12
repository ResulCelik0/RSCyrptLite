using System;
using System.Linq;
using System.Text;
using System.IO;
using Calculate;
using EncodeDecode;
namespace RSCyrptLite
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var iv = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        start:
            Bannner();
            Console.WriteLine("What you wanna do ?");
            Console.WriteLine("1: Encypt");
            Console.WriteLine("2: Decyrpt");
            Console.WriteLine("Select Option:");
            var opt1 = Console.ReadLine();
            Console.Clear();
            Bannner();
            Console.WriteLine("Are you processing the file or the text?");
            Console.WriteLine("1: File");
            Console.WriteLine("2: Text");
            Console.WriteLine("Select Option");
            var opt2 = Console.ReadLine();
            Console.Clear();
            if (Convert.ToInt32(opt1) == 1)
            {
                if (Convert.ToInt32(opt2) == 1)
                {
                    byte[] key = Aes();
                re:
                    Console.WriteLine("File: ");
                    var filePath = Console.ReadLine();
                    var pathLocal = AppDomain.CurrentDomain.BaseDirectory;
                    if (File.Exists(pathLocal + filePath))
                    {
                        var file = File.ReadAllBytes(pathLocal + filePath);
                        FileEncyrption(iv, key, pathLocal, file);
                    }
                    else if (File.Exists(filePath))
                    {
                        var file = File.ReadAllBytes(filePath);
                        FileEncyrption(iv, key, pathLocal, file);
                    }
                    else
                    {
                        Console.WriteLine("File Not Found");
                        goto re;
                    }

                }
                else if (Convert.ToInt32(opt2) == 2)
                {

                    byte[] key = Aes();
                re:
                    Console.WriteLine("Text to be encrypted, enter:");
                    var data = Encoding.UTF8.GetBytes(Console.ReadLine());
                    if (data is null)
                    {
                        goto re;
                    }
                    Console.Clear();
                    Bannner();
                    var c = new EncodeDecode.EncodeDecode().Encode(data, key, iv,true);
                    var str = BitConverter.ToString(c).Replace("-", "");
                    Console.WriteLine("Encrypted Text");
                    Console.WriteLine(str);
                    Console.ReadLine();
                    goto start;

                }
                else
                {
                    Console.WriteLine("Eror wrong choices");
                    Console.ReadLine();
                    goto start;
                }
            }
            else if (Convert.ToInt32(opt1) == 2)
            {
                if (Convert.ToInt32(opt2) == 1)
                {
                    byte[] key = Aes();
                re:
                    Console.WriteLine("File: ");
                    var filePath = Console.ReadLine();
                    var pathLocal = AppDomain.CurrentDomain.BaseDirectory;
                    if (File.Exists(pathLocal + filePath))
                    {
                        var file = File.ReadAllBytes(pathLocal + filePath);
                        FileDecyrption(iv, key, pathLocal, file);
                        goto start;
                    }
                    else if (File.Exists(filePath))
                    {
                        var file = File.ReadAllBytes(filePath);
                        FileDecyrption(iv, key, pathLocal, file);
                        goto start;
                    }
                    else
                    {
                        Console.WriteLine("File Not Found");
                        goto re;
                    }

                }
                else if (Convert.ToInt32(opt2) == 2)
                {

                    byte[] key = Aes();
                re:
                    Console.WriteLine("enter the text to be decrypted");
                    var decyptedText = Console.ReadLine();
                    if (decyptedText is null)
                    {
                        goto re;

                    }
                    var d = new EncodeDecode.EncodeDecode().Decode(StringHexToByteArray(decyptedText), key, iv);
                    Console.Clear();
                    Bannner();
                    var str2 = BitConverter.ToString(d).Replace("-", ""); ;
                    Console.WriteLine("Decrypted text");
                    Console.WriteLine(Encoding.UTF8.GetString(StringHexToByteArray(str2)));
                    Console.ReadLine();
                    goto start;
                }
                else
                {
                    Console.WriteLine("Eror wrong choices");
                    Console.ReadLine();
                    goto start;
                }
            }
            else
            {
                Console.WriteLine("Eror wrong choices");
                Console.ReadLine();
                goto start;
            }



        }

        private static void FileDecyrption(byte[] iv, byte[] key, string pathLocal, byte[] file)
        {
            if (iv is null)
            {
                throw new ArgumentNullException(nameof(iv));
            }

            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(pathLocal))
            {
                throw new ArgumentException($"'{nameof(pathLocal)}' null veya boş olamaz.", nameof(pathLocal));
            }

            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            Console.WriteLine("Output File Name: ");
            var fileName = Console.ReadLine();
            var fileDecrypt = new EncodeDecode.EncodeDecode().Decode(file, key, iv);
            File.WriteAllBytes(pathLocal + fileName, fileDecrypt);
            Console.WriteLine("Decryption Successful");
            Console.ReadLine();

        }

        private static void FileEncyrption(byte[] iv, byte[] key, string pathLocal, byte[] file)
        {
            if (iv is null)
            {
                throw new ArgumentNullException(nameof(iv));
            }

            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(pathLocal))
            {
                throw new ArgumentException($"'{nameof(pathLocal)}' null veya boş olamaz.", nameof(pathLocal));
            }

            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            Console.WriteLine("Output File Name: ");
            var fileName = Console.ReadLine();
            var fileEncyrpt = new EncodeDecode.EncodeDecode().Encode(file, key, iv, false);
            File.WriteAllBytes(pathLocal + fileName, fileEncyrpt);
            Console.WriteLine("Encryption Successful");
            Console.ReadLine();


        }

        private static byte[] Aes()
        {
        re:
            Bannner();
            Console.WriteLine("Please enter your 16 Digit AES password(if not, create)");
            var key = Encoding.UTF8.GetBytes(Console.ReadLine());
            Console.Clear();
            if (key.Length == 16) { return key; }
            else { goto re; }

        }

        private static void Bannner()
        {
            Console.WriteLine(@"|-------------------------------------------------------------------------------|");
            Console.WriteLine(@"|  ____    ____     ____                          _     _       _   _           |");
            Console.WriteLine(@"| |  _ \  / ___|   / ___|  _   _   _ __   _ __   | |_  | |     (_) | |_    ___  |");
            Console.WriteLine(@"| | |_) | \___ \  | |     | | | | | '__| | '_ \  | __| | |     | | | __|  / _ \ |");
            Console.WriteLine(@"| |  _ <   ___) | | |___  | |_| | | |    | |_) | | |_  | |___  | | | |_  |  __/ |");
            Console.WriteLine(@"| |_| \_\ |____/   \____|  \__, | |_|    | .__/   \__| |_____| |_|  \__|  \___| |");
            Console.WriteLine(@"|                          |___/         |_|                                    |");
            Console.WriteLine(@"|-------------------------------------------------------------------------------|");
            Console.WriteLine(@"|                               Author:Resul ÇELİK                              |");
            Console.WriteLine(@"|                              Version:0.1 BetaBuild                            |");
            Console.WriteLine(@"|-------------------------------------------------------------------------------|");
            Console.WriteLine();
            Console.WriteLine();
        }
        public static byte[] StringHexToByteArray(string hex)
        {

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
