
using System.Text.Json.Serialization;

namespace proiect_poo; 


public class Student : Utilizator
{
    public List<proiect> Proiecte { get; set; } = new List<proiect>();
    public List<reclamatie> Reclamatii { get; set; } = new List<reclamatie>();
    
   public Student () {}
    public Student(string email, string nrMatricol, string numePers, string parola) :
        base(email, nrMatricol, numePers, parola)
    {
    }

    public void InscriereLaSesiune(List<sesiune> sesiuni)
    {
        Console.WriteLine("Introduceti codul sesiuni pentru a va conecta :");
        string cod = Console.ReadLine();
        var Sesiune = sesiuni.Find(s => s.CodUnic == cod);
        if (Sesiune != null && Sesiune.EsteDeschisa)
        {
            Sesiune.Participanti.Add(this);
            Console.WriteLine("V-ati inscris cu succes la sesiune");

        }
        else
        {
            Console.WriteLine("Nu v-ati putut inscrie la sesiune codul este gresit");
        }
    }

    public void PredareProiect(string Titlu,DateTime datapredare)
    {
       
        var proiect = Proiecte.Find(p => p.Titlu == Titlu);
        if (proiect != null)
        {
            if (datapredare <= proiect.DataIncheiere)
            {
                Console.WriteLine($"$Proiectul:{proiect.Titlu}a fost predat cu succes");
            }
            else
            {

                Console.WriteLine("Proiectul nu mai poate fii predat ");
            }
        }
        else
        {
            Console.WriteLine("Studentul nu este inscris la aceasta sesiune");
        }

    }

    public void VizualizareNota(string TitluProiect)
    {
        var proiect = Proiecte.Find(p => p.Titlu == TitluProiect);
        if (proiect != null)
        {
            if (proiect.Nota != null)
            {
                Console.WriteLine($"Proiectul a fost notat cu nota {proiect.Nota}");
            }
            else
            {
                Console.WriteLine("Proiectul nu a fost inca notat");
            }
        }
        else
        {
            Console.WriteLine("Studentul nu are acest proeict in lista");
        }
    }

    public void Istoric()

    {
        Console.WriteLine($"Istoric note pentru studentul {NumePers}");
        foreach (var proiect in Proiecte)
        {
            float nota = proiect.Nota;
            Console.WriteLine($"{proiect.Titlu}:{nota}");
        }
    }

    public void ReclamatieNota(string titluproiect,string mesajreclamatie)
    {
        var proiect = Proiecte.Find(p => p.Titlu == titluproiect);
        if (proiect != null)
        {
            if (proiect.Nota != null)
            {
                Reclamatii.Add(new reclamatie(  titluproiect ,mesajreclamatie));
                Console.WriteLine($"Reclamatie inregistrata cu succes pentru proeictul {titluproiect}");
            }
            else
            {
                Console.WriteLine("Nu puteti reclama un proiect care nu are nota");

            }
        }
        else
        {
            Console.WriteLine("Proiectul nu a fost gasit");
        }
    }
    
}
