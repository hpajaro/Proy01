// See https://aka.ms/new-console-template for more information
//TipoDatos();
//InvertirPalabra();
using System.Collections;
using Newtonsoft.Json;
//Boxing();
//Arreglos();
//LoadJson();
//Contar();
NoRepetidos();
void NoRepetidos()
{
    string[] palabras = { "Hola", "Casa", "Hola", "Perro", "Casa", "Hola", "Casa", "Hola", "Gato", "Perro" };
    var noRepetidos = palabras.ToHashSet().ToList();
    foreach (var item in noRepetidos)
        Console.WriteLine($"{item} ");

}
void Contar()
{

    string[] palabras = { "Hola", "Casa", "Hola", "Perro", "Casa", "Hola", "Casa", "Hola", "Gato", "Perro" };
    Dictionary<string, int> dic = new Dictionary<string, int>();
    foreach (var palabra in palabras)
    {
        if (dic.Keys.Contains(palabra))
            dic[palabra] += 1;
        else
            dic.Add(palabra, 1);
    }
    Console.WriteLine($"Palabra        Conteo ");
    Console.WriteLine($"========      =======");
    foreach (var item in dic)
    {
        Console.WriteLine($"{item.Key} \t\t {item.Value} ");
    }
}
void LoadJson()
{
    using (StreamReader r = new StreamReader("customers.json"))
    {
        string json = r.ReadToEnd();
        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
        //var resp1 = customers.Find(it => it.country == "Spain");
        var resp2 = customers.FindAll(it => it.city == "London");
        // var resp3 = customers.FindAll(it => it.companyName.StartsWith("P"));
        //Console.WriteLine($"Tipo de resp es: {resp.GetType()}");

        // MostrarEmpresa(resp);
        ListarEmpresas(resp2);
        // MostrarEmpresa(resp1);
    }
}
void MostrarEmpresa(Customer emp)
{
    Console.WriteLine($"Empresa    : {emp.companyName} ");
    Console.WriteLine($"Contacto   : {emp.contactName} ");
    Console.WriteLine($"Direccion  : {emp.address} ");
    Console.WriteLine($"Ciudad     : {emp.city} ");
    Console.WriteLine($"Pais       : {emp.country} ");
    Console.WriteLine("-----------------------------------");
}
void ListarEmpresas(List<Customer> datos)
{

    foreach (var item in datos)
    {
        Console.WriteLine($"Empresa    : {item.companyName} ");
        Console.WriteLine($"Contacto   : {item.contactName} ");
        Console.WriteLine($"Direccion  : {item.address} ");
        Console.WriteLine($"Ciudad     : {item.city} ");
        Console.WriteLine($"Pais       : {item.country} ");
        Console.WriteLine("-----------------------------------");
    }
}
void Boxing()
{
    ArrayList Salarios = new ArrayList();
    Salarios.Add(1500);
    Salarios.Add(2500);
    Salarios.Add(1800);

    /*var sal0 = Convert.ToInt32(Salarios[0]?.ToString());
    var sal1 = Convert.ToInt32(Salarios[1]?.ToString());
    var sal2 = Convert.ToInt32(Salarios[2]?.ToString());

    int total = sal0 + sal1 + sal2;*/
    //#nullable disable
    int total = (int)Salarios[0] + (int)Salarios[1] + (int)Salarios[2];

    Console.WriteLine($"Total={total} ");
}


void Arreglos()
{
    ushort size = 10;
    var vocales = new char[] { 'a', 'e', 'i', 'o', 'u' };
    var consonantes = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
    var digitos = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    var alfabeto = vocales.Union(consonantes).ToArray();
    Dictionary<string, char[]> dic = new Dictionary<string, char[]>();
    dic.Add("vocales", vocales);
    dic.Add("consonantes", consonantes);
    dic.Add("alfabeto", alfabeto);


    var xvocales = dic["vocales"];

    string res = "";
    for (ushort i = 0; i < size; i++)
    {
        bool letra = new Random().Next(0, 100) <= 50 ? true : false;// Tirar una moneda 
        if (letra)
        {
            int k = new Random().Next(0, alfabeto.Length - 1);
            bool lower = new Random().Next(0, 100) <= 50 ? true : false;
            res += lower ? alfabeto[k] : alfabeto[k].ToString().ToUpper();
        }
        else
        {
            int n = new Random().Next(0, 9);
            res += digitos[n].ToString();
        }

    }
    Console.WriteLine(" El String Aleatorio es {0}", res);
    ArrayList caracteres = new ArrayList();
    //caracteres.Add(size);
    caracteres.Add(vocales);
    caracteres.Add(consonantes);
    caracteres.Add(alfabeto);
    caracteres.Add(digitos);
    // var valor = (char[])caracteres[0];
    foreach (var item in (char[])caracteres[0])
    {
        Console.WriteLine($"Valor {item} ");
    }






}

void InvertirPalabra()
{
    Console.WriteLine($"Ingrese La palabra a Invertir ");
    string? palabra = Console.ReadLine();
    if (palabra is not null)
    {

        string palabraInvertida = "";
        for (ushort i = (ushort)(palabra.Length - 1); i >= 0; i--)
        {
            palabraInvertida += palabra[i];
            if (i == 0) break;
        }
        string res = palabraInvertida.ToUpper() == palabra.ToUpper() ? "Es Palindroma" : "No es Palindroma";
        Console.WriteLine($"Palabra Invertida es= {palabraInvertida}");
        Console.WriteLine($"Palabra {res}");

    }
}


void TipoDatos()
{
    ushort minUshort = ushort.MinValue;
    ushort maxUshort = ushort.MaxValue;
    short minShort = short.MinValue;
    short maxShort = short.MaxValue;
    ulong minUlong = ulong.MinValue;
    ulong maxUlong = ulong.MaxValue;
    Console.WriteLine($"Rango  de ushort:{minUshort} a {maxUshort}");
    Console.WriteLine($"Rango  de short:{minShort} a {maxShort}");
    Console.WriteLine($"Rango  de ulong:{minUlong} a {maxUlong}");
}
void Saludo(string nombre)
{
    string apellido = "Pajaro";
    Console.WriteLine($"Saludo desde metodo soy {nombre} {apellido} ");
}
public class Customer
{

    public string id { get; set; }
    public string companyName { get; set; }
    public string contactName { get; set; }
    public string contactTitle { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string postalCode { get; set; }
    public string country { get; set; }
    public string phone { get; set; }
    public string fax { get; set; }

}