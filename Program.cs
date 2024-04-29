namespace Ornekler
{
    internal class Program
    {
        static List<string> isler = new List<string>();

        static void TxtKaydet()
        {
            using StreamWriter writer = new StreamWriter("isler.txt");
            foreach (var item in isler)
            {
                writer.WriteLine(item);
            }
        }

        static void IsEkle()
        {
            Console.Clear();
            Console.WriteLine("Eklemek istediğiz iş: ");
            string inputIs = Console.ReadLine();
            isler.Add(inputIs);
            Console.WriteLine("İş başarıyla eklendi!");
            TxtKaydet();
            MenuyeDon();
        }

        static void VerileriYukle()
        {
            using StreamReader reader = new StreamReader("isler.txt");

            string satir;
            while ((satir = reader.ReadLine()) != null)
            {
                isler.Add(satir);
            }
        }

        static void MenuyeDon()
        {
            Console.WriteLine("\nMenüye dönmek için bir tuşa basınız.");
            Console.ReadKey(true);
            MenuGoster();
        }

        static void IsleriListele()
        {
            Console.Clear();
            Console.WriteLine("TÜM İŞLER");
            Console.WriteLine("");

            if (isler.Count == 0)
            {
                Console.WriteLine("Listelenecek iş bulunamadı.");
            }

            for (int i = 0; i < isler.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {isler[i]}");
            }

            MenuyeDon();
        }

        static void IsleriSil()
        {
            isler.Clear();
            Console.Clear();
            Console.WriteLine("Tüm işler silindi!");
            TxtKaydet();
            MenuyeDon();
        }

        static void MenuGoster(bool ilkAcilisMi = false)
        {

            if (ilkAcilisMi)
            {
                Console.WriteLine("Hoş Geldiniz");
            }

            Console.WriteLine("Yapılacak İşlemi Seçin");
            Console.WriteLine("1 - İşleri Listele");
            Console.WriteLine("2 - Yeni İş Ekle");
            Console.WriteLine("3 - İş Listesini temizle");
            Console.WriteLine("4 - Çıkış");

            Console.Write("Seçiminiz: ");
            char inputSecim = Console.ReadKey().KeyChar;

            switch (inputSecim)
            {
                case '1':
                    IsleriListele();
                    break;
                case '2':
                    IsEkle();
                    break;
                case '3':
                    IsleriSil();
                    break;
                case '4':

                    break;
                default:
                    Console.WriteLine("\nHatalı Seçim Yaptınız!");
                    MenuyeDon();
                    break;
            }
        }

        static void Main(string[] args)
        {
            VerileriYukle();
            MenuGoster(true);
        }
    }
}
