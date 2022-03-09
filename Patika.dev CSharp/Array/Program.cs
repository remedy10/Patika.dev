// See https://aka.ms/new-console-template for more information
#region HackerRank Birthday Cake Candles
/*int candlesCount=int.Parse(Console.ReadLine());
List<int> candles = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();// tek satırda istediğin kadar veri alma 3 2 1 3  
int birthdayCakeCandles(List<int> candles)
    {
        int tallest=0;
        int candlesMax=candles.Max();
        
        for (int i = 0; i < candles.Count; i++)
        {
            if (candlesMax==candles[i])
            {
                tallest++;
            }
        }

        return tallest;
    }
Console.WriteLine(birthdayCakeCandles(candles));*/
#endregion
#region HackerRank Simple Array Sum
/*int arrayCount=int.Parse(Console.ReadLine());
List<int> myArray = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrayTemp => Convert.ToInt32(arrayTemp)).ToList();
int arraySum(List<int> myArray)
{
    int sum=0;
    myArray.ForEach(x=>sum+=x);
  return sum;
}
Console.WriteLine(arraySum(myArray));*/
#endregion
#region HackerRank Day7 Arrays(Reverse)
/*int arrayCount=0;
arrayCount=int.Parse(Console.ReadLine());
List<int> myList=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrayTemp=> int.Parse(arrayTemp)).ToList();
myList.ForEach(item=>Console.Write(item+" "));
myList.Reverse();
myList.ForEach(item=>Console.Write(item+" "));*/
#endregion
#region HackerRank very big sum
/*int arrayCount=int.Parse(Console.ReadLine());
List<long> myList=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrayTemp=> long.Parse(arrayTemp)).ToList();
long veryBigSum(List<long> myList)
{ long sum=0;
    myList.ForEach(item=>sum+=item); // ! kolaya kaçan :myList.Sum();
    return sum;
}
Console.WriteLine(veryBigSum(myList));*/
#endregion 
#region Compare the Triplets(Alice and Bob)
/*Console.WriteLine("Alice'in verilerini gir,");
List<int> aliceList=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(temp=>int.Parse(temp)).ToList();
Console.WriteLine("Bob'un verilerini gir,");
List<int> bobList=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(temp=>int.Parse(temp)).ToList();
List<int> compareArray(List<int> aliceList,List<int> bobList)
{   
    int alicePoint=0;
    int bobPoint=0;
    List<int> resultList=new List<int>();
    for (int i = 0; i < aliceList.Count(); i++)
    {
        if (aliceList[i]>bobList[i])
        {
            alicePoint+=1;
        }
        else if(bobList[i]>aliceList[i])
        {
             bobPoint+=1;
        }
    }
    resultList.Add(alicePoint);
    resultList.Add(bobPoint);
    return resultList;
}
compareArray(aliceList,bobList).ForEach(item=>Console.Write(item+" "));*/
#endregion
#region BubbleSort items and count swaps
/*int arrayCount=int.Parse(Console.ReadLine());
List<int> myList=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrayTemp=> int.Parse(arrayTemp)).ToList();
List<int> bubbleSort(List<int> myList)
{
      return myList;

}
Console.Write("Unsorted List:");
myList.ForEach(x=>Console.Write(x+" "));;
int temp=0;
int countofSwaps=0;
int countofList=myList.Count();
Console.Write("\nSorted List:");
for (int i = 0; i < countofList - 1; i++)
            for (int j = 0; j < countofList - i - 1; j++)
                if (myList[j] > myList[j + 1])
                {
                    countofSwaps++;
                      temp = myList[j];
                    myList[j] = myList[j + 1];
                    myList[j + 1] = temp;
                }
myList.ForEach(x=>Console.Write(x+" "));
Console.WriteLine("\nArray sorted {0} swap.First element is {1} ,last is {2} ",countofSwaps,myList[0],myList[myList.Count()-1]);*/
/* 528 için;
Array is sorted in 68472 swaps.
First Element: 4842  // !verdi 
Last Element: 1994569*/ 

#endregion
#region HackerRank Migratory Birds
Console.WriteLine("Enter array dimension(count);");
int countofList=int.Parse(Console.ReadLine());
List<int> birds=Console.ReadLine().TrimEnd().Split(' ').ToList().Select(temp=>int.Parse(temp)).ToList();

int migratoryBirds(List<int> arr)
    {   
        int index=0;
        int[] typeofBirds=new int[6];
        typeofBirds[0]=0;
         for (int i = 0; i < countofList; i++)
        {
            index=birds[i];
            typeofBirds[index]++;
        }
        int maxType=1;
        int maxFreq=typeofBirds[1];

         for (int i = 2; i < 6; i++)
            {
                if(typeofBirds[i]>maxFreq)
                {
                   maxType=i;
                   maxFreq=typeofBirds[i];
                }
            }
        return maxType;
    }
Console.WriteLine("{0}",migratoryBirds(birds));

#endregion
Console.WriteLine("xxxXXXxxx");