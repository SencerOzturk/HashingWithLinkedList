using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _6.hafta_2_
{
    internal class Program
    {


        static Block[] hashLinked = new Block[100]; // Nesnelerin tutuldugu bır hash tablosu tanımlandı.

        static void Main(string[] args)
        {
            // Ana program fonksiyonu
        }

        static void HashAddLinked(int data)
        {
            int indis = hashfunc(data); // Hash fonksiyonu ile indeks hesapla

            // Eğer bu indeks boş değilse, bağlantılı listenin icini gez ve o elemanı tasıyan blok var mı dıye kontrol et.
            if (hashLinked[indis] != null)
            {
                Block t1 = hashLinked[indis]; //o indis yerini baglı linked list olusturmak adına nesne olusturduk.
                while (t1 != null) //ilk baglı lıste elemanı elbet null olamaz ama t1=t1.next ıle bır sonrakıler null mu dıye kontrol etmek adına var.
                {
                    if (t1.data == data) // Eğer veri zaten varsa, ekleme işlemi yapılmaz.O blokta zaten ılgılı data varsa eklemeye gerek yok.
                        return;
                    t1 = t1.next; //Eger baglı lıstedekı ılk elemanda yoksa data degerı bır sonrakıne bak.
                }
            }

            // Yeni bir blok oluşturuluyor ve veri ekleniyor

            Block tmp = new Block(); //yenı nesne olusturuldu o bloga ve ılgılı data atandı.
            tmp.data = data;

            // Yeni blok, mevcut blokların başına ekleniyor (2.elemanı gosteren ilk eleman olur.)
            tmp.next = hashLinked[indis];
            if (hashLinked[indis] != null) //Teoride gereksız gıbı gozukebılır ama yazılımda gereklı bır kod blogu baglantı kuruyoruz cunku.
            { 
                hashLinked[indis].prev = tmp; // Eski baş blok (yani artık 2.olan blok), yeni bloğun 'prev' özelliğine bağlanıyor yanı arkayı da gosterıyor artık.
            }
            hashLinked[indis] = tmp; // hasLinked[indis] pointeri artık tmp blogunu gosterıyor artık lıstenın ılk elemanı tmp
        }

        static bool SearchLinked(int data)
        {
            int indis = hashfunc(data); // Hash fonksiyonu ile indeks hesapla
            Block t1 = hashLinked[indis];

            // Bağlantılı listede arama yapılır
            while (t1 != null)
            {
                if (t1.data == data) // Eğer veri bulunursa, true döndürülür
                    return true;
                t1 = t1.next;
            }

            return false; // Eğer veri bulunmazsa, false döndürülür
        }

        // Basit bir hash fonksiyonu
        static int hashfunc(int data)
        {
            return data % hashLinked.Length; // Modüler aritmetik ile indeks hesaplama
        }





        
    }

    public class Block
    {
        public Block next; // Bir sonraki blok
        public Block prev; // Bir önceki blok
        public int data; // Veri
    }

    //burdan binary tree'ye gecıs yapacaksın.

}
