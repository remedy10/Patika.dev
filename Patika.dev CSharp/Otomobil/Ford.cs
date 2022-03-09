namespace Otomobil
{
    public class Ford : IOtomobil
    {
        public Marka MarkaBilgisi()
        {
            return Marka.Ford;
        }

        public Model ModelBilgisi()
        {
            return Model.Focus;
        }

        public Renk RenkBilgisi()
        {
            return Renk.Kirmizi;
        }

        public Yakit yakitTipi()
        {
            return Yakit.Benzin;
        }
    }
}