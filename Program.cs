using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Text;
Console.WriteLine("cryption için 1'i decryption için 2'yi tuşlayınız");
string s = Console.ReadLine();
int rakam = Convert.ToInt32(s);
Console.WriteLine("anahtar kelimeyi giriniz :");
string anahtarkelime = Console.ReadLine();//.ToUpper(System.Globalization.CultureInfo.InvariantCulture);


#if DEBUG

//hiyftxis a ts dut t mele//
#endif
#if DEBUG
if (string.IsNullOrWhiteSpace(anahtarkelime))
    anahtarkelime = "elma";
#endif

List<int> degerler = new List<int>();
foreach (char c in anahtarkelime)
{
    int ascideger = c;
    
    degerler.Add(ascideger);  
}
Dictionary<int,int> siralanmis = new Dictionary<int,int>();
List<int> gecici = new List<int>(degerler);
gecici.Sort();
int buyukluk = 0;
int elemansayisi = degerler.Count();
foreach (var sayi in gecici)
{
    if(!siralanmis.ContainsKey(sayi))
    {
        siralanmis.Add(sayi, buyukluk);
        buyukluk++;
    }
}
for (int i = 0; i < degerler.Count; i++)
{
    int sayi = degerler[i];
    degerler[i] = siralanmis[sayi];
}
if (rakam==1)
{
    Console.WriteLine("Metni girin:");
    string metin = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(metin))
    {
        metin = "this is my default text";
    }
    
    int satirsayisi = (int)Math.Ceiling((double)metin.Length / elemansayisi);
    char[,] izgara = new char[satirsayisi, elemansayisi];
    int index = 0;
    for (int satir = 0; satir < satirsayisi; satir++)
    {
        for (int sutun = 0; sutun < elemansayisi; sutun++)
        {
            if (index < metin.Length)
            {
                izgara[satir, sutun] = metin[index];
                index++;
            }
            else
            {
                izgara[satir, sutun] = ' ';
            }
        }
    }


    StringBuilder sifrelimetin = new StringBuilder();
    foreach (int sayi in degerler)
    {
        for (int satir = 0; satir < satirsayisi; satir++)
        {
            sifrelimetin.Append(izgara[satir, sayi]);
        }
    }

    sifrelimetin.ToString();
    Console.WriteLine("Şifrelenmiş metin:" + sifrelimetin);


}
if (rakam == 2)
{
    Console.WriteLine("şifrelenmiş metni giriniz:");
    string sifreli = Console.ReadLine();
    int psatirsayisi = (int)Math.Ceiling((double)sifreli.Length / elemansayisi);
    char[,] pizgara = new char[psatirsayisi, elemansayisi];
    int pindex = 0;
    foreach (int sayi in degerler)
    {
        for (int satir = 0; satir < psatirsayisi; satir++)
        {
            if (pindex < sifreli.Length)
            {
                pizgara[satir, sayi] = sifreli[pindex];
                pindex++;
            }
        }
    }

    StringBuilder cozumetin = new StringBuilder();
    for (int satir = 0; satir < psatirsayisi; satir++)
    {
        for (int sutun = 0; sutun < elemansayisi; sutun++)
        {
            cozumetin.Append(pizgara[satir, sutun]);
        }
    }
    cozumetin.ToString();
    Console.WriteLine(cozumetin);
}
