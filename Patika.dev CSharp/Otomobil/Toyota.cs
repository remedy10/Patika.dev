namespace Otomobil
{

    // ! olayı genişletmek istersen burada araç ekleme kısmı yapıp nesneyi 
    // ! oluştururken enumları seçip ona göre marka model ekleyebilirsin
    public class Toyota : IOtomobil
    {
        public Marka MarkaBilgisi()
        {
            return Marka.Toyota;
        }

        public Model ModelBilgisi()
        {
            return Model.Corolla;
        }

        public Renk RenkBilgisi()
        {
            return Renk.Mavi;
        }

        public Yakit yakitTipi()
        {
            return Yakit.Dizel;
        }
        
    }
}