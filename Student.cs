namespace proiect_poo;

public class Student : Utilizator
{
    public List<proiect> Proiecte { get; set; } = new List<proiect>();

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
}