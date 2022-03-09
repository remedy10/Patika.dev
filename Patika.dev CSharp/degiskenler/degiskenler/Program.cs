// See https://aka.ms/new-console-template for more information
/* DateTime dt = DateTime.Now;

object o1 = "x";
object o2 = 'y';
object o3 = 4;
object o4 = 4.3;

string str1 = string.Empty;
str1 = "serif guler";
string ad = "serif";
string soyad = "guler";
string tamIsim = ad + " " + soyad;


int integer1 = 5;
int integer2 = 3;
int integer3 = integer1 * integer2;





string str20 = "20";
int int20 = 20;
string yeniDeger = str20 + int20.ToString();
Console.WriteLine(yeniDeger);

int int21 = int20 + Convert.ToInt32(str20);
Console.WriteLine(int21);

int int22 = int20 + int.Parse(str20);


string datetime = DateTime.Now.ToString("dd.MM.yyyy");
Console.WriteLine(datetime);

string datetime2 = DateTime.Now.ToString("dd/MM/yyyy");
Console.WriteLine(datetime2);

string hour = DateTime.Now.ToString("HH:mm");
Console.WriteLine(hour);
 */
int n = Convert.ToInt32(Console.ReadLine()!.Trim()!);
var binary = 0;
var sayac = 0;
var max = 0;
while (n > 0)
{
    binary = n % 2;
    n /= 2;
    if (binary == 1)
    {
        sayac++;
        max = Math.Max(max, sayac);
    }
    else if (binary == 0)
    {
        sayac = 0;
    }
}
Console.WriteLine(max);
Console.WriteLine("Git");
Console.WriteLine("Değişiklikler oluyor lan.");