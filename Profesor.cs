using System.Globalization;

namespace proiect_poo;

public class Profesor:Utilizator

{
    public Profesor(string email ,string nrMatricol,string numePers,string parola):
        base(email,nrMatricol,numePers,parola)
    {}

    public void DeschidereSesiune(List<sesiune> sesiuni)
    {
        Console.WriteLine("Introduceti cod unic pentru sesiune");
        string cod = Console.ReadLine();
        Console.WriteLine("Introduceti numele sesiuni: ");
        string nume = Console.ReadLine();
        sesiuni.Add(new sesiune(cod, nume));
        Console.WriteLine("Sesiunea a fost deschisa cu success");
    }

    public void InchidereSesiune(List<sesiune> sesiuni)
    {
        Console.WriteLine("Introduceti numele sesiuni pe care doriti sa o incheiati");
        string cod = Console.ReadLine();
        var sesiune = sesiuni.Find(s => s.CodUnic == cod);
        if (sesiune != null)
        {
            sesiune.EsteDeschisa = false;
            Console.WriteLine("Sesiunea a fost inchisa");
            
        }
        else
        {
           Console.WriteLine("Sesiunea nu a fost gasita");
        }
        

    }
}
    


