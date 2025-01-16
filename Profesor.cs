using System.Globalization;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace proiect_poo;

public class Profesor : Utilizator

{ public Profesor () {}

    public Profesor(string email, string nrMatricol, string numePers, string parola) :
        base(email, nrMatricol, numePers, parola)
    {
    }

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

    public void VizualizareListaProiecteStudenti(List<proiect> proiecte)

    {
        if (proiecte.Count == 0)
        {
            Console.WriteLine("Lista cu proiecte este goala");
            return;
        }

        Console.WriteLine("Lista proiectelor studentilor: ");
        foreach (var proiect in proiecte)
        {
            Console.WriteLine(
                $"Student : {proiect.Nume},Titlu: {proiect.Titlu},Descriere:{proiect.Descriere},a fost notat cu nota {proiect.Nota}");
        }
    }

    public void NotareProiect(List<proiect> proiecte, string NumeStudent, string TitluProiect, float Nota)
    {
        var proiect = proiecte.Find(p => p.Nume == NumeStudent  &&  p.Titlu == TitluProiect);
        if (proiect != null)
        {
            proiect.Nota = Nota;
            Console.WriteLine(
                $"Proiectul: {proiect.Titlu} al studentului {proiect.Nume}este notat cu nota {proiect.Nota}");
        }
        else
        {
            Console.WriteLine("Proiectul nu a fost gasit");
            return;

        }
    }

    public void RaspunsReclamatie(List<reclamatie> reclamatii, string reclamatieId, string raspuns)
    {
        var reclamatie = reclamatii.Find(r => r.Id == reclamatieId);
        if (reclamatie == null)
        {
            Console.WriteLine("Reclamatia nu a fost gasita");
            return;
        }
        else
        {
            reclamatie.Raspuns = raspuns;
            reclamatie.Rezolvat = true;
            Console.WriteLine($"Raspunsul la reclamatie a fost inregistrat");
            

        }
    }

    public void ModificareNota(List<proiect>proiecte,string NumeStudent,string TitluProiect,int NotaNoua)
    {
        var proiect = proiecte.Find(p => p.Nume == NumeStudent && p.Titlu == TitluProiect);
        if (proiect == null)
        {
            Console.WriteLine("Proiectul nu a fost gasit");
            return;
        }
        else
        {
            proiect.Nota = NotaNoua;
            Console.WriteLine ($"Proiectul: {proiect.Titlu} al studentului {proiect.Nume} ,nota a fost modificata cu nota {proiect.Nota}");
        }

    }
    
}
    
    


