// See https://aka.ms/new-console-template for more information
Console.WriteLine("Git");
#region HackerRank Recursive Factorial

int factorial(int num)
{
    if (num == 1)
        return num;
    return (factorial(num - 1) * num);
}
Console.WriteLine(factorial(6));
/*
   burada methot her seferinde num-1 methodunu çagırır ta ki factorial(1)'e kadar 
   factorial(1)'i biliyoruz zaten 1
   sonra üste çıkıp factorial(2)yi bulur yani factorial(2)=factorial(1)*2 factorial(1)=1 olduguna göre 2*1=2 yani factorial(2)=2 .. gider 
   kısaca;
         factorial(1)=1
         factorial(2)=factorial(1)*2 
         factorial(3)=factorial(2)*3
         factorial(4)=factorial(3)*4
         factorial(5)=factorial(4)*3
Özyineli methotlar hafızayı müsrifçe kullanırlar dolayısıyla çok maliyetlidirler.
*/
#endregion
#region Recursive Pow
int rPow(int num, int _pow)
{
    if (_pow == 1)
        return num;
    return rPow(num, (_pow - 1)) * num;
}
Console.WriteLine(rPow(5, 2));
#endregion
#region Even numbers of List
/*Console.WriteLine("Please enter numbers with between spaces");
List<int> numbers=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(temp=>int.Parse(temp)).ToList();
numbers.evenNumbers().ForEach(x=>Console.WriteLine(x));*/
#endregion
#region Common Divisor of the Number(i.S.)
/*Console.WriteLine("Please enter numbers with between spaces");
List<int> numbers=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(temp=>int.Parse(temp)).ToList();
numbers.commonDivisor(10).ForEach(x=>Console.WriteLine(x));*/
#endregion
#region List Reverse Operation 
// List<string> myStrList=Console.ReadLine().Trim().Split(' ').ToList().Select(temp=>temp).ToList();
// myStrList.reverseItems().ForEach(x=>Console.Write(x+" "));
#endregion
#region How many words & chars  in the entered sentence
// string sentence="Ananın amı galatasaray  ";
// Console.WriteLine(sentence.hmWordsChars());
#endregion
#region Exception handling to Convert String=>Integer
// string myString=Console.ReadLine();

// try
// {
//    int myInteger=int.Parse(myString);
// }
// catch (System.Exception)
// {
//    Console.WriteLine("Bad String!");
// }
#endregion
#region Let's Review(Day 6)
// List<string> myStrList=new();
// int num=0;
// num=int.Parse(Console.ReadLine());
// for (int i = 0; i < num; i++)
// {
//    myStrList.Add(Console.ReadLine());
// }
// //List<string> myStrList=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(temp=>temp).ToList();
//   myStrList.seperateEvenIndex().ForEach(x=>Console.WriteLine(x));
#endregion
#region More Exception(Day 17)
//myclass içinde methot var.  
#endregion
#region Time Conversion 
// string dtime=Console.ReadLine();
// Console.WriteLine(dtime.timeConversion);
#endregion
#region Collections
//  void PrintArray<E>(E[] input)
// {  

//     foreach(E value in input)
//         Console.WriteLine(value); //! E T DE OLABİLİR HERHANGİ BİR TİPTE DİZİYİ YAZDIRMAK İÇİN BUNU KULLANABİLİRSİN 
// }
#endregion
#region Day 8: Dictionaries and Maps
// Dictionary<string,string> phoneBook=new();
// Console.WriteLine("Kaç veri gireceksin?");
// int count=int.Parse(Console.ReadLine());
// for (int i = 0; i < count; i++)
// {  
//    Console.WriteLine("{0}. veriyi gir.(önce isim sonra tel no)",i+1);
//    var entry = Console.ReadLine().Split(' ');
//    phoneBook.Add(entry[0],entry[1]);
// }
// Console.WriteLine("Sorgula(kaç veri girdisen o kadar sorgu yaparsın)");
// for (int i = 0; i < count; i++)
// {  
//    string vQuery=Console.ReadLine();
//    Console.WriteLine(query(vQuery));
// }
// string query(string query)
// {
//    if(phoneBook.ContainsKey(query))
//    {
//      string num="";
//      phoneBook.TryGetValue(query,out num);
//      num = query+"="+num;
//        return num;
//    }
//    else 
//        return "Not found";
// }
#endregion
#region Ödev 1
// List<int> myList =new();
// List<int> asallar =new();
// List<int> degiller =new();
// int sayi=0;
// for (int i = 0; i < 20 ; i++)
// {
//      sayi=int.Parse(Console.ReadLine());
//     if (sayi>=0)
//     {
//       myList.Add(sayi);
//       sayi=0; 
//     }
//     else 
//     {
//        throw new Exception("Sayimiz pozitif olmalıdır.");
//     }
// }
// asalMi(myList);
// asallar.ForEach(x=>Console.Write(x+" "));
// Console.Write("\n");
// degiller.ForEach(x=>Console.Write(x+ " "));
// void asalMi(List<int> myList)
// {

//   for (int i = 0; i < myList.Count(); i++)
//   {
//      if (myList[i]%2==0)
//      {
//         asallar.Add(myList[i]);
//      }
//      else
//      {
//         degiller.Add(myList[i]);
//      }
//   } 
// }
#endregion
#region Ödev 2
// List<int> sayilar=new();
// int sayi=0;
// for (int i = 0; i < 10; i++)
//    sayilar.Add(int.Parse(Console.ReadLine()));
// sayilar.Sort();
// sayilar.ForEach(x=>Console.Write("| "+x+" "));
// Console.WriteLine("\nEn küçük 3 sayi:{0},{1},{2} | En büyük 3 Sayi:{3},{4},{5},",
// sayilar[0],sayilar[1],sayilar[2],sayilar[sayilar.Count()-3],
// sayilar[sayilar.Count()-2],sayilar[sayilar.Count()-1]);
// int kucukOrt=(sayilar[0]+sayilar[1]+sayilar[2])/3;
// int buyukOrt=(sayilar[sayilar.Count()-3]+sayilar[sayilar.Count()-2]+sayilar[sayilar.Count()-1])/3;
// Console.WriteLine("En büyüklerin ortalaması {0} | En küçüklerin ortalaması {1}",buyukOrt
// ,kucukOrt);
#endregion
#region Ödev 3 
string sentence = Console.ReadLine()!;
List<char> charList = new();
char[] c = new char[16];
char[] sesliler = new[] { 'a', 'A', 'e', 'E', 'i', 'İ', 'ı', 'I', 'o', 'ö', 'Ö', 'O', 'u', 'ü', 'Ü', 'U' };
sesliMi(sentence);
charList.ForEach(x => Console.Write(x + " "));
foreach (var item in c)
{
    Console.Write(item + " ");
}
void sesliMi(string sentence)
{
    int j = 0;
    for (int i = 0; i < sesliler.Count(); i++)
    {
        if (sentence.Contains(sesliler[i]))
        {
            charList.Add(sesliler[i]);
            c[j] = sesliler[i];
            j++;
        }
    }
}
#endregion
#region  Useful Class
public static class myClass
{


    public static string timeConversion(this string s)
    {
        bool succ = DateTime.TryParse(s, out DateTime result);
        if (succ)
        {
            return result.ToString("HH:mm:ss");
        }
        else
            return "Wrong input!";

    }
    public static int power(int n, int p)
    {

        if (n < 0 || p < 0)
            throw new Exception("n and p should be non-negative");

        return (int)Math.Pow(n, p);
    }

    public static List<int> evenNumbers(this List<int> myList)
    {
        List<int> evenList = new();
        foreach (var item in myList)
        {
            if (item % 2 == 0)
                evenList.Add(item);
        }
        return evenList;
    }
    public static List<string> seperateEvenIndex(this List<string> myList)
    {
        string even = "";
        string odd = "";
        string _string = "";
        List<string> evenList = new();
        foreach (var item in myList)
        {
            _string = item;
            even = "";
            odd = "";
            for (int i = 0; i < item.Count(); i++)
            {
                if (i % 2 == 0) // is even(true)
                {
                    even += _string.Substring(i, 1);
                }
                else
                    odd += _string.Substring(i, 1);
            }
            evenList.Add(even + " " + odd);
        }

        return evenList;
    }
    public static List<int> commonDivisor(this List<int> myList, int num)// şeyi anlamadım ama this int num yazınca hata veriyor acaba bir tane mi kullanabiliryorz?
    {
        List<int> divisors = new();
        foreach (var item in myList)
        {
            if (item % num == 0)
                divisors.Add(item);
        }
        return divisors;
    }
    public static List<string> reverseItems(this List<string> myList)
    {
        List<string> reversedList = new();
        for (int i = 0; i < myList.Count(); i++)
        {
            reversedList.Add(myList[myList.Count() - i - 1]);
        }

        return reversedList;
    }
    public static string hmWordsChars(this string theSentence)
    {
        int words = 0;
        int chars = theSentence.Trim().Count();
        string[] arrWords = theSentence.TrimEnd().Split(' ');
        words = arrWords.Count();
        //    for (int i = 0; i < chars+1; i++)
        //    {   

        //        string c=theSentence.Substring(i,1);//! hazır method kullandın kendi methodunu yaz!
        //        if (c==" " && c!="\0")
        //        {
        //            words++;
        //        }
        //    }
        return words + " words & " + chars + " chars in your sentence.";
    }
}


#endregion
