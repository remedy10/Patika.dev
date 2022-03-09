namespace todoApp
{
    public class cards
    {
        // ! Aklıma şey geldi şimdi 1 tane board var.şimdi boards sınıfı oluşturup  buna bağlayıp 
        // ! takım sınıfına da boards tipinde parametre verip takım özelimde board board içinde todo,doing,done
        // ! card listesi yapılablir
        List<card> todoCards= new List<card>();
        List<card> doingCards= new List<card>();
        List<card> doneCards= new List<card>();
        
        public List<card> TodoCards { get => todoCards; set => todoCards = value; }
        public List<card> DoingCards { get => doingCards; set => doingCards = value; }
        public List<card> DoneCards { get => doneCards; set => doneCards = value; }
        
    }
}