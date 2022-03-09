namespace Otomobil
{
    public class Bentley : IOtomobil
    {
        public Marka MarkaBilgisi()
        {
            return Marka.Bentley;
        }

        public Model ModelBilgisi()
        {
            return Model.Continental;
        }

        public Renk RenkBilgisi()
        {
            return Renk.Siyah;
        }

        public Yakit yakitTipi()
        {
            return Yakit.Benzin;
        }
    }
}