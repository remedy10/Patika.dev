TelefonDefteri.kisi kisiler = new TelefonDefteri.kisi();
List<TelefonDefteri.kisi> kisilers = new List<TelefonDefteri.kisi>();
InitList();
anaMenu();
void kisiArama()
{
    Console.Clear();
    Console.WriteLine("-----------*Kişi Arama Menüsü*-----------------");
    Console.WriteLine("Kişinin adını veya numarasını giriniz.");
    string input = Console.ReadLine();
    bool findState = false;
    foreach (var item in kisilers)
    {
        if (input == item.KisiAdSoy || input == item.TelNo) // ! burada aradıgınız kelimeden bir harf bile eksik yazarsan bulma                                                        // ! onunlada uğraşmadım 
        {
            Console.WriteLine("Kişi bulundu!Bilgileri aşağıdadır;");
            kisiler = item;
            Console.WriteLine("Adi={0},Tel={1}", kisiler.KisiAdSoy, kisiler.TelNo);
            findState = true;
            break;
        }
    }
    if (findState == false)
    {
        Console.WriteLine("Kullanıcı bulunamadı.");
    }
    else if (findState == true)
    {
        Console.WriteLine("Kullanıcı ile ne yapmak istersin?(1=Güncelle | 2= Sil )");
        int menuInput = int.Parse(Console.ReadLine());
        if (menuInput == 1)
        {
            Console.WriteLine("kişi düzenle(breakpoint)");
            kisiDuzenle();
        }
        else if (menuInput == 2)
        {
            Console.WriteLine("kişi sil(breakpoint)");
            kisilers.Remove(kisiler);
            Console.WriteLine("Silme işlemi başarılı");
        }

    }
    Console.ReadKey();
}

void kisiDuzenle()
{
    Console.Clear();
    Console.WriteLine("-----------*Kişi Düzenleme Menüsü*-----------------");
    Console.WriteLine("Seçili kişinin adı={0} | Tel.={1}", kisiler.KisiAdSoy, kisiler.TelNo);
    string yeniAd = "";
    string yeniTel = "";
    Console.WriteLine("Yeni bir ad giriniz..");
    yeniAd = Console.ReadLine();
    Console.WriteLine("Yeni bir telefon giriniz..");
    yeniTel = Console.ReadLine();
    Console.WriteLine("{0} | {1} | ==> {2} | {3} | olarak değişecektir, onaylıyor musun?(Y:1/N:2)", kisiler.KisiAdSoy, kisiler.TelNo, yeniAd, yeniTel);
    int input = int.Parse(Console.ReadLine());
    if (input == 1)
    {
        kisilers.Remove(kisiler);
        kisiler.KisiAdSoy = yeniAd;
        kisiler.TelNo = yeniTel;
        kisilers.Add(kisiler);
        Console.WriteLine("Başarılı");
    }
    else
    {
        kisiDuzenle();
    }

}
// ! Bugun çok yoruldum A-Z Z-A Listeleme yapmadın,kullanıcı varsa kullanıcı var(numara için) onu yapablirsin 
// ! gerçi normal rehberde ekliyor ama olsun onu eklersen çoklu bulmayı da yapman lazım  
// ! bir de sanki program böyle çok karışık oldu gibi istersen düzenle(olurda düzenlemezsen 02/03/2022)
void kisiEkle()
{
    Console.Clear();
    Console.WriteLine("-----------*Kişi Ekleme Menüsü*-----------------");
    Console.WriteLine("Kişiyi hangi adla kaydetmek istiyorsunuz?");
    string kisiAdi = Console.ReadLine();
    Console.WriteLine("{0} için telefon numarası giriniz.", kisiAdi);
    string kisiTel = Console.ReadLine();
    kisiler.KisiAdSoy = kisiAdi;
    kisiler.TelNo = kisiTel;
    kisilers.Add(kisiler);
    Console.WriteLine("{0}-{1} Eklendi.Ana menü için 1 tuşla", kisiAdi, kisiTel);
    int input = int.Parse(Console.ReadLine().Trim());
    while (input != 1)
    {
        Console.WriteLine("Ana menüye dönmek için 1 tuşlayın..");
        input = int.Parse(Console.ReadLine());
    }
    anaMenu();

}
void anaMenu()
{
    Console.Clear();
    Console.WriteLine("-----------Telefon Defterim---------");
    Console.WriteLine("Kişi Ekle 1 | Kişi Arama 2 | Tüm Rehber 3 | Çıkış 5  ");
    Console.WriteLine("-----------*Lütfen yukarıdaki kısayollara göre hareket ediniz..*-----------------");
    Console.WriteLine("Yapmak istediğiniz işlemi giriniz..");
    int durum = int.Parse(Console.ReadLine());
    while (durum != 5)
    {
        switch (durum)
        {
            case 1:
                kisiEkle();
                break;
            case 2:
                kisiArama();
                durum = default;
                break;

            case 3:
                tumRehber();
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                anaMenu();
                break;
        }

    }
}

void tumRehber()
{
    Console.WriteLine("-----------Tüm Rehber ---------");
    Console.WriteLine("Listedeki tüm kişileri görüntülüyorsunuz.");
    kisilers.ForEach(x => Console.WriteLine("| Adi=" + x.KisiAdSoy + " |  Numarasi=" + x.TelNo + " |"));
    Console.WriteLine("Ana menüye dönmek için 1 tuşlayın..");
    int input;
    input = int.Parse(Console.ReadLine());
    while (input != 1)
    {
        Console.WriteLine("Ana menüye dönmek için 1 tuşlayın..");
        input = int.Parse(Console.ReadLine());
    }
    anaMenu();
}

void InitList()
{
    TelefonDefteri.kisi kisiler1 = new TelefonDefteri.kisi();
    TelefonDefteri.kisi kisiler2 = new TelefonDefteri.kisi();
    TelefonDefteri.kisi kisiler3 = new TelefonDefteri.kisi();
    TelefonDefteri.kisi kisiler4 = new TelefonDefteri.kisi();
    TelefonDefteri.kisi kisiler5 = new TelefonDefteri.kisi();
    kisiler1.KisiAdSoy = "Şerif Güler";
    kisiler1.TelNo = "05333333333";
    kisiler2.KisiAdSoy = "Ebru Gültekin";
    kisiler2.TelNo = "05333343333";
    kisiler3.KisiAdSoy = "Sinem Kobalt";
    kisiler3.TelNo = "05833333333";
    kisiler4.KisiAdSoy = "Efe Aydal";
    kisiler4.TelNo = "05333333383";
    kisiler5.KisiAdSoy = "Tansu Çilli";
    kisiler5.TelNo = "05733373333";
    kisilers.Add(kisiler1);
    kisilers.Add(kisiler2);
    kisilers.Add(kisiler3);
    kisilers.Add(kisiler4);
    kisilers.Add(kisiler5);
}