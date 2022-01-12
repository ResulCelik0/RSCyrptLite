using System;
using System.Collections.Generic;
using System.Linq;
namespace Calculate
{
    public class Calculate
    {
        public byte[,] DataPartion(byte[] rawData) // Tek boyutlu dizeyi çift boyutlu dizeye çevirme işlemi
        {
            long partLength = rawData.Length; // rawData uzunluğun asal sayı olması ihitimali düşünülerek parthLength (parça uzunluğu) rawDatanın uzunluğuna eşitlenir
            long partition = 0; // partition (parça sayısı) deşikeninin tanımı 
            List<long> factor = new List<long>(); // çarpanlar listesi
            //---------------------------------------------------------------------------
            for (long i = 1; i < rawData.Length; i++) // rawData uzunluğunda çarpan arama işlemi
            {
                if (rawData.Length % i == 0) // eğer i değeri rawData uzunluğu ile tam bölüyüyorsa rawDatanın çarpanıdır
                {
                    factor.Add(i); //listeye çarpan ekleme
                }
            }
            //---------------------------------------------------------------------------
            //if(factor.Count == 1) // eğer 1 çarpan varsa 
            //{
            //    partition = 1;
            //    goto go;
            //}
            //---------------------------------------------------------------------------
            if (factor.Count == 2) // eğer iki çarpan varsa
            {
                partition = rawData.Length / factor.Max(); // partition (parça sayısı) değişkeni rawDatanın uzunluğu ile en büyük çarpanın bölümüne eşittir 
                partLength = factor.Max(); // parthlength (parça uzunluğu) değişkeni en büyük çarpana eşittir
                goto go; //başlaya git
            }
            //---------------------------------------------------------------------------
            else if (factor.Count % 2 == 0) // eğer 2nin katları kadar çarpan varsa 
            {
                var medyanIndex = factor.Count / 2; // çarpanların ortasını bulmak için meydanIndex değeri çarpan sayısının 2 ye bölümüne eşitlenir. örn:  1 2 3 medyanIndex= 4   5 6 7 8
                partition = rawData.Length / factor[medyanIndex]; //partition (parça sayısı) değişkeni rawData uzunuluğu ile çarpanların ortasındaki değer ile bölümüne eşitlenir. 
                partLength = factor[medyanIndex]; // parthlength (parça uzunluğu) değişkeni çarpanların ortasındaki değere eşitlenir
                goto go; // başlaya git
            }
            //---------------------------------------------------------------------------                                                                                                           Sonradan eklenen değer
            else if (factor.Count % 2 != 0) // eğer 2nin katları kadar çarpan yoksa                                                                                                                             ^
            {                                                                                                                                                                                               //  |          
                var medyanIndex = ((factor.Count + 1) / 2); // çarpanların tam orta değerini bulmak için medyanIndex değeri çarpan sayısının 1 fazlasının 2 ye bölümüne eşitlenir. örn: 1 2  medyanIndex: 3 4 5 6 
                partition = rawData.Length / factor[medyanIndex];//partition (parça sayısı) değişkenii rawData uzunuluğu ile çarpanların ortasındaki değer ile bölümüne eşitlenir. 
                partLength = factor[medyanIndex]; // parthlength(parça uzunluğu) değişkeni çarpanların ortasındaki değere eşitlenir
                goto go;// başlaya git
            }
            //---------------------------------------------------------------------------
            go: // başla
            byte[,] result = new byte[partition, partLength]; //parthlength(parça uzunluğu) ve partition (parça sayısı) ile çift boyutlu result çift boyutlu dizesi oluşturulur.
            long l = 0; //partition (parça sayısını) gezmek için p değişkeni tanımlanır
            long d = 0; //rawData değişkenini gezmek için d değişkeni tanımlanır.
            for (long p = 0; p <= partition -1;) //0. boyutu tanımlamak için partition (parça sayısı) değişkeninden 1 değer çıkarılır ve gezmeye başlanır.
            {           
                for (; l <= partLength -1;) //0. indexi tanımlamak için partLength (parça uzuğunluğu) değişkeninden 1 değer çıkarılır. ve gezmeye başlanır
                {                 
                    result[p, l] = rawData[d]; // result dizesinin partition ve partlength indexleri tanımlamak için sırasıyla döngülerdeki p ve l değerleri kullanılır. result dizesinin p ve l indeksi rawData dizesinin d indeksine eşitlenir.               
                    l++; 
                    d++;
                }
                l = 0;             
                p++;
            }
            //--------------------------------------------------------------------------
            Console.WriteLine("PartLenght: " + partLength);
            Console.WriteLine("Partiton Count: " +partition);
            return result; // çift boyutlu dize fonksiyondan döndürürlür.
        }
    }
}
