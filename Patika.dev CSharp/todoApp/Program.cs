// See https://aka.ms/new-console-template for more information
todoApp.card card = new todoApp.card();
todoApp.cards cards = new todoApp.cards();
List<todoApp.card> allCards = new List<todoApp.card>();
initCards();
mainMenu();
void mainMenu()
{
    Console.WriteLine("----------------Welcome todoApp----------------! ");
    Console.WriteLine("| List Cards (1) | Edit Cards (2) | Board List |");
    Console.WriteLine("Enter number of menu;");
    int menuInput = int.Parse(Console.ReadLine()!);
    switch (menuInput)
    {
        case 1:
            listCards();
            break;
        case 2:
            editCards();
            break;
        case 3:
            boardList();
            break;
    }

}

void boardList()
{

    listCards();
    Console.WriteLine("first select your board to move | TODO(1),DOING(2),DONE(3) |");

    int selectBoard = 0;
    selectBoard = int.Parse(Console.ReadLine()!);
    if (selectBoard == 1)
    {
        Console.WriteLine("TODO BOARD");
        Console.WriteLine("Enter a title;");
        string inputTitle = Console.ReadLine()!;
        card = cards.TodoCards.Find(x => x.CardTitle.Contains(inputTitle))!;
        //yine gereksiz kod kalabası
        Console.WriteLine("your card:" + card.CardTitle + " where to move? | DOING(2),DONE(3) | ");
        selectBoard = int.Parse(Console.ReadLine()!);
        if (selectBoard == 2)
        {
            cards.TodoCards.Remove(card);
            cards.DoingCards.Add(card);
            Console.WriteLine("Transfer Success!");
            selectBoard = 0;


        }
        else if (selectBoard == 3)
        {
            cards.TodoCards.Remove(card);
            cards.DoneCards.Add(card);
            Console.WriteLine("Transfer Success!");
            selectBoard = 0;
        }
        else
            boardList();
    }
    else if (selectBoard == 2)
    {
        Console.WriteLine("DOING  BOARD");
        Console.WriteLine("Enter a title;");
        string inputTitle = Console.ReadLine()!;
        card = cards.DoingCards.Find(x => x.CardTitle.Contains(inputTitle))!;
        //yine gereksiz kod kalabası
        Console.WriteLine("your card:" + card.CardTitle + " where to move? | DONE(3) | ");
        selectBoard = int.Parse(Console.ReadLine()!);
        if (selectBoard == 3)
        {
            cards.DoingCards.Remove(card);
            cards.DoneCards.Add(card);
            Console.WriteLine("Transfer Success!");
            selectBoard = 0;

        }
        else
            boardList();

    }
    else if (selectBoard == 3)
    {
        Console.WriteLine("DONE BOARD");
        Console.WriteLine("Enter a title;");
        string inputTitle = Console.ReadLine()!;
        card = cards.TodoCards.Find(x => x.CardTitle.Contains(inputTitle))!;
        //yine gereksiz kod kalabası
        Console.WriteLine("your card:" + card.CardTitle + " done cards can only be moved to the trash Y(1)/N(2) ");
        selectBoard = int.Parse(Console.ReadLine()!);
        if (selectBoard == 1)
        {
            cards.DoneCards.Remove(card);
            selectBoard = 0;
        }
        else
            boardList();
    }
    Console.ReadKey();
    mainMenu();
}

void editCards()
{
    //Ekle 1,Sil 2 Güncelle 3;
    int editInput = int.Parse(Console.ReadLine()!);
    switch (editInput)
    {
        case 1:
            insertCard();
            break;
        case 2:
            deleteCard();
            break;
        case 3:
            updateCard();
            break;
    }

}

void insertCard()
{
    string? insertTitle, insertContent, insertOwner;
    int insertSize = 0;
    Console.WriteLine("----------------Insert Card----------------! ");
    Console.Write("Enter title:");
    insertTitle = Console.ReadLine();
    Console.Write("\nEnter content:");
    insertContent = Console.ReadLine();
    Console.Write("\nEnter owner:");
    insertOwner = Console.ReadLine();
    Console.Write("\nEnter size ==> XS(1),S(2),M(3),L(4),XL(5):");
    insertSize = int.Parse(Console.ReadLine()!);
    todoApp.sizeEnums selectedEnum = todoApp.sizeEnums.xs;//default
    switch (insertSize)
    {
        case 1:
            selectedEnum = todoApp.sizeEnums.xs;
            break;
        case 2:
            selectedEnum = todoApp.sizeEnums.s;
            break;
        case 3:
            selectedEnum = todoApp.sizeEnums.m;
            break;
        case 4:
            selectedEnum = todoApp.sizeEnums.l;
            break;
        case 5:
            selectedEnum = todoApp.sizeEnums.xl;
            break;
            //default: koyabilirsin
    }
    Console.WriteLine("Eklemek istediniz veri {0} | {1} | {2} | {3} | Y(1)/N(2) ", insertTitle, insertContent, insertOwner, insertSize);
    int insertInput = int.Parse(Console.ReadLine()!);
    if (insertInput == 1)
    {
        // insertcard sınıfı kullanabilirsin 
        card.CardTitle = insertTitle;
        card.CardContent = insertContent;
        card.CardOwner = insertOwner;
        card.CardSize = selectedEnum;
        cards.TodoCards.Add(card);
    }
    else if (insertInput == 2)
    {
        insertCard();
    }
    mainMenu();
}

void deleteCard()
{
    //aslında bununların çogunu kod kalabalığına neden  olmadan yapabilirdim ama jeton köşeli moruk 
    cards.TodoCards.ForEach(x => allCards.Add(x));
    cards.DoingCards.ForEach(x => allCards.Add(x));
    cards.DoneCards.ForEach(x => allCards.Add(x));
    Console.Clear();
    Console.WriteLine("----------------Delete card menu---------------- ");
    Console.WriteLine("Title of all cards:");
    allCards.ForEach(x => Console.Write("| " + x.CardTitle + " "));
    Console.WriteLine("Enter a title;");
    string deleteInput = Console.ReadLine()!;
    card = allCards.Find(x => x.CardTitle.Contains(deleteInput))!;//gereksiz gibi geldi bana 
    if (card != null)
    {
        Console.WriteLine(card.CardTitle + "," + card.CardContent);
        Console.WriteLine("Are u' sure delete selected card in list?(Y(1)/N(2))");//bok gibi ingilizce
        int deleteChoice = int.Parse(Console.ReadLine()!);
        if (deleteChoice == 1)
        {
            cards.TodoCards.Remove(card);
            cards.DoingCards.Remove(card);
            cards.DoneCards.Remove(card);
        }
        else if (deleteChoice == 2)
            deleteCard();

    }
    else
        Console.WriteLine("Card not found!");

    Console.ReadKey();
    mainMenu();
}

void updateCard()
{
    string updateTitle = Console.ReadLine()!;
    cards.TodoCards.ForEach(x => allCards.Add(x));
    cards.DoingCards.ForEach(x => allCards.Add(x));
    cards.DoneCards.ForEach(x => allCards.Add(x));
    allCards.ForEach(x => Console.Write("| " + x.CardTitle + " "));
    card = allCards.Find(x => x.CardTitle.Contains(updateTitle))!;
    Console.WriteLine("Selected card title={0} | update? Y(1)/N(2)", card.CardTitle);
    int updateChoice = int.Parse(Console.ReadLine()!);
    if (updateChoice == 1)
    {
        cards.TodoCards.Remove(card);
        cards.DoingCards.Remove(card);
        cards.DoneCards.Remove(card);
        insertCard();
    }
    else if (updateChoice == 2)
    {
        updateCard();
    }


}

void listCards()
{
    Console.Clear();
    Console.WriteLine("----------------List card menu---------------- ");
    #region Foreach TODO
    Console.WriteLine("-----Todo-------");
    if (cards.TodoCards.Count() == 0)
    {
        Console.WriteLine("Empty;");
        Console.WriteLine("-------------------------------- ");
    }
    foreach (var item in cards.TodoCards)
    {
        Console.WriteLine("Title: {0}", item.CardTitle);
        Console.WriteLine("Content: {0}", item.CardContent);
        Console.WriteLine("Owner Team: {0}", item.CardOwner);
        Console.WriteLine("Size: {0}", item.CardSize.ToString());
        Console.WriteLine("-------------------------------- ");

    }
    #endregion
    #region  Foreach DOING
    Console.WriteLine("-----Doing-------");
    if (cards.DoingCards.Count() == 0)
    {
        Console.WriteLine("Empty;");
        Console.WriteLine("-------------------------------- ");
    }
    foreach (var item in cards.DoingCards)
    {
        Console.WriteLine("Title: {0}", item.CardTitle);
        Console.WriteLine("Content: {0}", item.CardContent);
        Console.WriteLine("Owner Team: {0}", item.CardOwner);
        Console.WriteLine("Size: {0}", item.CardSize.ToString());
        Console.WriteLine("-------------------------------- ");

    }
    #endregion
    #region  Foreach DONE
    Console.WriteLine("-----Done-------");
    if (cards.DoneCards.Count() == 0)
    {
        Console.WriteLine("Empty;");
        Console.WriteLine("-------------------------------- ");
    }
    foreach (var item in cards.DoneCards)
    {
        Console.WriteLine("Title: {0}", item.CardTitle);
        Console.WriteLine("Content: {0}", item.CardContent);
        Console.WriteLine("Owner Team: {0}", item.CardOwner);
        Console.WriteLine("Size: {0}", item.CardSize.ToString());
        Console.WriteLine("-------------------------------- ");
        if (cards.TodoCards.Count == 0)
        {
            Console.WriteLine("Empty;");
            Console.WriteLine("-------------------------------- ");
        }
    }
    #endregion 
}
void initCards()
{
    todoApp.card card1 = new todoApp.card();
    card1.CardTitle = "Write a method";
    card1.CardContent = "Write a methot.it return a string blablablablablablabla.";
    card1.CardSize = todoApp.sizeEnums.l;
    card1.CardOwner = "Softawere Team";
    cards.DoneCards.Add(card1);
    todoApp.card card2 = new todoApp.card();
    card2.CardTitle = "Write microservice";
    card2.CardContent = "Write a tiny little service aka microservice";
    card2.CardSize = todoApp.sizeEnums.l;
    card2.CardOwner = "Team Little Guys";
    cards.DoneCards.Add(card2);
    todoApp.card card3 = new todoApp.card();
    card3.CardTitle = "Coffee Machine";
    card3.CardContent = "want a budget for a coffee machine from chef";
    card3.CardSize = todoApp.sizeEnums.l;
    card3.CardOwner = "Team Little Guys";
    cards.TodoCards.Add(card3);
}