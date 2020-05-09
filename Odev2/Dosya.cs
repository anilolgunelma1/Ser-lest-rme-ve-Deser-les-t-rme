using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Odev2
{
    [Serializable]
    class Dosya
    {
        public int ToplamSozcuk;
        public int ToplamCumle;
        public string EnCokSozcuk;
        public int EnFazlaSozcukAdeti = 0;

        [NonSerialized] string Satir;
        [NonSerialized] public int Sayi;
        [NonSerialized] public int Yeni;
       

        public void DosyaÇekme()
        {

            try
            { //Dosya okutularak cumle adeti,en çok tekrarlayan kelime  ve adeti,sozcuk adeti bulundu.
                string DosyaYolu = @"C:\Users\ADmin\Desktop\Odev2\Odev2\text.txt";
                FileStream stream = new FileStream(DosyaYolu, FileMode.Open, FileAccess.Read);
                StreamReader str = new StreamReader(stream);
                Satir = str.ReadLine();
                // Aynı kelimelerden buyuk ve kucuk sekılde vardı en çok kelime ve adetini bulmak için tum metin kucuk harfe çevrildi.
                Satir = Satir.ToLower();
                // çesitli splitlerle metin ayrıldı.
                string[] Cumle = Satir.Split(".");
                string[] Sozcuk = Satir.Split(" ");
                string[] Cumle2 = Satir.Split("!");



                // en çok tekrarlanan kelime ve adeti bulundu.
                for (int i = 0; i < Sozcuk.Length; i++)
                {
                    Sayi = 0;
                    for (int j = 0; j < Sozcuk.Length; j++)
                    {

                        if (Sozcuk[i].ToString() == Sozcuk[j].ToString())
                        {
                            Sayi++;
                        }


                    }
                    Yeni = Sayi;
                    if (Yeni > EnFazlaSozcukAdeti)
                    {
                        EnFazlaSozcukAdeti = Yeni;
                        EnCokSozcuk = Sozcuk[i].ToString();
                    }

                }

                
               
                ToplamSozcuk = Sozcuk.Length;
             
                int Cumlenokta = Cumle.Length;
                int Cumleunlem = Cumle2.Length;
                //3 tane . kısaltmalarda kulanıldıgı için 3 adet nokta çıkarıldı cümle adetinden.
                ToplamCumle = (Cumlenokta-3)+Cumleunlem-1;
                
               // Console.WriteLine("Toplam Sozcuk Adedi:" + ToplamSozcuk);
               // Console.WriteLine("Toplam Cumle Adedi:" + ToplamCumle);
                // Console.WriteLine("En Çok Tekrar Eden Kelime ve Adedi:"+" "+EnÇokSozcuk+" "+EnFazlaSozcukAdeti);

            }
            catch (FileNotFoundException et)
            {
                Console.WriteLine(et.Message);
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("Dosya Yolu Yanlış.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Bu Dosyayı Oluşturma İzniniz Yok.");
            }
            catch (NotSupportedException rt)
            {
                Console.WriteLine(rt.Message); 
            }






        }

        // Cümle adeti,sozcuk adeti ,en çok tekrar eden kelime ve adeti serilestirilerek yeni olusturulan dosyaya yazdırıldı.
        public void Serilestir()
        {
            Dosya dt = new Dosya();
            dt.DosyaÇekme();

            try
            {
                string DosyaYolu2 = @"C:\Users\ADmin\Desktop\Odev2\Odev2\yeni.txt";
              Stream stream2 = new FileStream(DosyaYolu2, FileMode.Create,
         FileAccess.Write, FileShare.None);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream2,dt);
                stream2.Close();
            }
            catch (FileNotFoundException et)
            {
                Console.WriteLine(et.Message);
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("Dosya Yolu Yanlış.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Bu Dosyayı Oluşturma İzniniz Yok.");
            }
            catch (NotSupportedException rt)
            {
                Console.WriteLine(rt.Message);
            }







        }
        // Cümle adeti,sozcuk adeti ,en çok tekrar eden kelime ve adeti  Deserilestirilerek ekrana yazdırıldı.
        public void Deserilestir()
        {
            Dosya dosya2 = new Dosya();
            BinaryFormatter formatter2 = new BinaryFormatter();
            
            try
            {

                string DosyaYolu2 = @"C:\Users\ADmin\Desktop\Odev2\Odev2\yeni.txt";
               FileStream stream3 = new FileStream(DosyaYolu2, FileMode.Open,
        FileAccess.Read, FileShare.None);

                dosya2 = (Dosya)formatter2.Deserialize(stream3);


                Console.WriteLine("Metindeki Toplam Sozcuk Adeti :"+dosya2.ToplamSozcuk);
                Console.WriteLine("Metindeki Toplam Cumle Adeti :"+dosya2.ToplamCumle);
                Console.WriteLine("Metinde En Fazla Geçen Sozcugun Adeti :"+dosya2.EnFazlaSozcukAdeti);
                Console.WriteLine("Metinde En Fazla Geçen Sözcük :" +dosya2.EnCokSozcuk);
               

            }
            catch (FileNotFoundException et)
            {
                Console.WriteLine(et.Message);
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("Dosya Yolu Yanlış.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Bu Dosyayı Oluşturma İzniniz Yok.");
            }
            catch (NotSupportedException rt)
            {
                Console.WriteLine(rt.Message);
            }

        }








    }
}
