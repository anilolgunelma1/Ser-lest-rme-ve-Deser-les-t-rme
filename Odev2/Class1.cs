using System;
using System.Collections.Generic;
using System.Text;


namespace Odev2
{
    class Tasarım:Dosya
    {  // switch case ile yapılacak işlerin  menusu olusturuldu.
    
        public void Şema()
        {
         
            
                int Deger;

          
            bool a = false;
            bool b = false;
    
            while (a == false) {
                Console.WriteLine("1 Dosyayı aç,oku ve serilestir:");
                Console.WriteLine("2 Deserilestir ve ekrana yazdır:");
                Deger = Convert.ToInt32(Console.ReadLine());
                switch (Deger)
            
            {
               
                case 1://serilestırme işlemleri
                        
                    Dosya dt = new Dosya();
                       
                    dt.Serilestir();
                        b = true;
                        break;
                case 2: //deserileştirme işlemleri 
                        try
                        {
                            if (b == false)
                            { 
                                throw new  Exception("1.işlemi seçip serilesirme yapmadan 2. işlemi seçemezsin");
                            }
                        
                        
                            else
                            {
                                Dosya dt2 = new Dosya();
                               dt2.Deserilestir();
                                a = true;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                            
                            
                            break;
                        
                   
            }
            }




        }

        

    }
}
