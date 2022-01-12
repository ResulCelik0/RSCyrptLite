using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EncodeDecode
{
    public class EncodeDecode
    {

        public byte[] Encode(byte[] data, byte[] key, byte[] iv, bool isText) //byte dizesi döndüren encode fonksiyonu
        {
            var calculate = new Calculate.Calculate(); //Calculate sınıfı calculate değişkenine atanarak çağırlır.
            var partedData = calculate.DataPartion(data); //data byte dizini calculate sınıfının çift boyutlu byte dizisi döndüren DataPartiton fonkisyonuna girdi olarak verilir ve sonuç partedData değişkenine atanır.
            Reverse2DimArray(partedData);// çift boyutlu partedData dizisinin her boyutunun simetriği alınır.
            byte[] result = new byte[partedData.Length]; // partedData uzunluğuna sahip result sonuç tek boyutlu byte dizisi tanımlanır.
            Buffer.BlockCopy(partedData, 0, result, 0, partedData.Length); //result byte dizisine parteData dizisi tek boyutlu olacak şekilde kopalanır
            if (isText == true)
            { //eğer metin ise Consola AES şifreleme öncesi yazdırılır
                Console.WriteLine("Pre AES: " + Encoding.UTF8.GetString(result));
            }
            return Encrypt(result, key, iv); //AES şifreleme uygulanır ve değer döndürülür.
        }
        //----------------------------------------------------------------------------------------
        public byte[] Decode(byte[] cyptedData, byte[] key, byte[] iv) //byte dizesi döndüren decode fonksiyonu
        {
            var cleanData = TrimTailingZeros(Decrypt(cyptedData, key, iv)); //AES şifresi çözülür ve çözülmeden sonraki eklenen fazlalık 0 değerleri silinir ve cleanData değişkenine tanımlarnır.
            var calculate = new Calculate.Calculate();//Calculate sınıfı calculate değişkenine atanarak çağırlır.
            var partedData = calculate.DataPartion(cleanData);//cleanData byte dizini calculate sınıfının çift boyutlu byte dizisi döndüren DataPartiton fonkisyonuna girdi olarak verilir ve sonuç partedData değişkenine atanır.
            var partCount = partedData.GetLength(0);//partCount(parça sayısı) değişkeni patedData çift boyutlu dizesinin 0. boyutunun uznluğuna tanımlanır.
            var partLength = partedData.GetLength(1);//partLength(parça uzunluğu) değişkeni patedData çift boyutlu dizesinin 1. boyutunun uznluğuna tanımlanır.
            Console.WriteLine("PartCount: " + partCount);//parCount (parça sayısı) deşikeni Consola yazdırılır.
            Console.WriteLine("PartLength: " + partLength);//partLength(parça uzunluğu) değişkeni konsola yazdırılır.
            Reverse2DimArray(partedData);//çift boyutlu partedData dizisinin her boyutunun simetriği alınır.
            byte[] result = new byte[partedData.Length];// partedData uzunluğuna sahip result sonuç tek boyutlu byte dizisi tanımlanır.
            Buffer.BlockCopy(partedData, 0, result, 0, partedData.Length); //result byte dizisine parteData dizisi tek boyutlu olacak şekilde kopalanır
            return result; // result sonuç değişleni döndürülür.
        }
        //----------------------------------------------------------------------------------------
        private static byte[] TrimTailingZeros(byte[] arr) //Fazlalık sıfırları silen fonksiyon
        {
            if (arr == null || arr.Length == 0)
                return arr;
            return arr.Reverse().SkipWhile(x => x == 0).Reverse().ToArray();
        }
        //---------------------------------------------------------------------------
        private static void Reverse2DimArray(byte[,] theArray) //Çift boyutlu dizelerin simetriğini alan fonkisyon
        {
            for (int rowIndex = 0; rowIndex <= (theArray.GetUpperBound(0)); rowIndex++) //theArray çift boyutlu dizesinin 1. boyutlarının simetriği alınır
            {
                for (int colIndex = 0; colIndex <= (theArray.GetUpperBound(1) / 2); colIndex++)
                {
                    byte tempHolder = theArray[rowIndex, colIndex];
                    theArray[rowIndex, colIndex] =
                    theArray[rowIndex, theArray.GetUpperBound(1) - colIndex];
                    theArray[rowIndex, theArray.GetUpperBound(1) - colIndex] = tempHolder;
                }

            }
            for (int colIndex = 0; colIndex <= (theArray.GetUpperBound(1)); colIndex++) //theArray çift boyutlu dizesinin 0.boyutlarının simetriği alınır
            {
                for (int rowIndex = 0; rowIndex <= (theArray.GetUpperBound(0) / 2); rowIndex++)
                {
                    byte tempHolder = theArray[rowIndex, colIndex];
                    theArray[rowIndex, colIndex] =
                    theArray[theArray.GetUpperBound(0) - rowIndex, colIndex];
                    theArray[theArray.GetUpperBound(0) - rowIndex, colIndex] = tempHolder;
                }

            }
        }
        //-----------------------------AES ŞİFRELEME------------------------------------------------------------------------------------------------------------------------------
        public byte[] Encrypt(byte[] data, byte[] key, byte[] iv) 
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;
                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, encryptor);
                }
            }
        }
        public byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;

                aes.Key = key;
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, decryptor);
                }
            }
        }

        private byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();

                return ms.ToArray();
            }
        }
    }
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------


}

