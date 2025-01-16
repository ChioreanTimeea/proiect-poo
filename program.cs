namespace proiect_poo;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

class Program
{
    static List<Utilizator> utilizatori = new List<Utilizator>();
    static List<sesiune> sesiuni = new List<sesiune>();
    static Utilizator utilizatorLogat = null;
    private static string filepath = "date.json";

    static void Main(string[] args)
    {
        while (true)
        {
            if (utilizatorLogat == null)
            {
                AfisareMeniuNeautentificat();
            }
            else
            {
                if (utilizatorLogat is Profesor)
                    AfisareMeniuProfesor((Profesor)utilizatorLogat);
                else if (utilizatorLogat is Student)
                    AfisareMeniuStudent((Student)utilizatorLogat);
            }
        }

    }


    static void AfisareMeniuNeautentificat()
    {
        Console.WriteLine("1. Logare");
        Console.WriteLine("2. Adăugare utilizator");
        Console.WriteLine("3. Iesire");
        string optiune = Console.ReadLine();

        switch (optiune)
        {
            case "1":
                Logare();
                break;
            case "2":
                AdaugareUtilizator();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opțiune invalidă!");
                break;
        }
    }

    static void AfisareMeniuProfesor(Profesor profesor)
    {
        Console.WriteLine("1. Deschidere sesiune");
        Console.WriteLine("2. Închidere sesiune");
        Console.WriteLine("3.Vizualizare lista proiecte studentii");
        Console.WriteLine("4.Notare proiect");
        Console.WriteLine("5.Raspuns la reclamatii");
        Console.WriteLine("6.Modificare Nota proiect");
        Console.WriteLine("7. Iesire ");

        string optiune = Console.ReadLine();

        switch (optiune)
        {
            case "1":
                profesor.DeschidereSesiune(sesiuni);
                break;
            case "2":
                profesor.InchidereSesiune(sesiuni);
                break;
            case "3":
                profesor.VizualizareListaProiecteStudenti(new List<proiect>());
                break;
            case "4":
                Console.WriteLine("Introduceti numele studentului");
                string numestudent = Console.ReadLine();
                Console.WriteLine("Introduceti titlu proiectului");
                string titlu = Console.ReadLine();
                Console.WriteLine("Introduceți nota:");
                int nota = int.Parse(Console.ReadLine());
                profesor.NotareProiect(new List<proiect>(), numestudent, titlu, nota);
                break;
            case "5":
                Console.WriteLine("Introduceți ID reclamație:");
                string reclamatieId = Console.ReadLine();
                Console.WriteLine("Introduceți răspunsul:");
                string raspuns = Console.ReadLine();
                profesor.RaspunsReclamatie(new List<reclamatie>(), reclamatieId, raspuns);
                break;
            case "6":
                Console.WriteLine("Introduceți numele studentului:");
                string studentModifNume = Console.ReadLine();
                Console.WriteLine("Introduceți titlul proiectului:");
                string titluModifProiect = Console.ReadLine();
                Console.WriteLine("Introduceți noua notă:");
                int notaNoua = int.Parse(Console.ReadLine());
                profesor.ModificareNota(new List<proiect>(), studentModifNume, titluModifProiect, notaNoua);
                break;
            case "7":
                utilizatorLogat = null;
                break;
            default:
                Console.WriteLine("Optiunea nu este valabila");
                break;
        }

    }

    static void AfisareMeniuStudent(Student student)
    {
        Console.WriteLine("1.Inscriere la sesiune");
        Console.WriteLine("2.Predare proiect");
        Console.WriteLine("3.Vizualizare nota proiect");
        Console.WriteLine("4.Istoric note proiecte");
        Console.WriteLine("5.Reclamatie nota proiect");
        Console.WriteLine("6.Iesire");

        string optiune = Console.ReadLine();
        switch (optiune)
        {
            case "1":
                student.InscriereLaSesiune(sesiuni);
                break;
            case "2":
                Console.WriteLine("Numele proiectului este:");
                string titlul = Console.ReadLine();
                DateTime data = DateTime.Now;
                student.PredareProiect(titlul, data);
                break;
            case "3":
                Console.WriteLine("Introduceți titlul proiectului:");
                string titluNota = Console.ReadLine();
                student.VizualizareNota(titluNota);
                break;
            case "4":
                student.Istoric();
                break;
            case "5":
                Console.WriteLine("Introduceți titlul proiectului:");
                string titluReclamatie = Console.ReadLine();
                Console.WriteLine("Introduceți detaliile reclamației:");
                string detalii = Console.ReadLine();
                student.ReclamatieNota(titluReclamatie, detalii);
                SalveazaDate(filepath);
                break;

            case "6":
                utilizatorLogat = null;
                break;
            default:
                Console.WriteLine("Optiunea nu este valabila");
                break;
        }
    }

    static void Logare()
    {
        Console.WriteLine("Introduceti email-ul: ");
        string email = Console.ReadLine();
        Console.WriteLine("Introduceti parola:");
        string parola = Console.ReadLine();
        var utilizator = utilizatori.Find(u => u.Email == email && u.Parola == parola);
        if (utilizator != null)
        {
            utilizatorLogat = utilizator;
            Console.WriteLine($"Bine ati venit {utilizator.NumePers}!");

        }
        else
        {
            Console.WriteLine("Datele nu sunt corecte");
        }
    }

    static void AdaugareUtilizator()
    {
        Console.WriteLine("Tip utilizator (1-profesor,2-student)");
        string tip = Console.ReadLine();
        Console.WriteLine("Introduceti numarul matricol: ");
        string numarmatricol = Console.ReadLine();
        Console.WriteLine("Introduceti numele persoanei: ");
        string numepersoana = Console.ReadLine();
        Console.WriteLine("Introduceti email-ul: ");
        string email = Console.ReadLine();
        Console.WriteLine("Introduceți parola:");
        string parola = Console.ReadLine();
        if (tip == "1")
        {
            IncarcaDate(filepath);
            utilizatori.Add(new Profesor(email, numarmatricol, numepersoana, parola));
            Console.WriteLine("Profesor adaugat cu succes");
            SalveazaDate(filepath);

        }
        else if (tip == "2")
        {
            IncarcaDate(filepath);
            utilizatori.Add(new Student(email, numarmatricol, numepersoana, parola));
            Console.WriteLine("Student adaugat cu succes");
            SalveazaDate(filepath);
        }
        else
        {
            Console.WriteLine("Tip invalid");

        }
    }

    public static void IncarcaDate(string filePath)
    {


        if (!File.Exists(filePath))
        {
            Console.WriteLine("Fișierul specificat nu există. Se va porni cu date noi.");
            utilizatori = new List<Utilizator>();
            sesiuni = new List<sesiune>();
            return;
        }

        try
        {
            string json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("Fișierul JSON este gol. Se va porni cu date noi.");
                utilizatori = new List<Utilizator>();
                sesiuni = new List<sesiune>();
                return;
            }

            var options = new JsonSerializerOptions
            {
                Converters = { new UtilizatorConverter() },
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            var date = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json, options);
            if (date == null)
            {
                Console.WriteLine("Structura fișierului JSON nu este validă. Se va porni cu date noi.");
                utilizatori = new List<Utilizator>();
                sesiuni = new List<sesiune>();
                if (date.ContainsKey("Utilizatori"))
                {
                    utilizatori =
                        JsonSerializer.Deserialize<List<Utilizator>>(date["Utilizatori"].GetRawText(), options) ??
                        new List<Utilizator>();
                }
                else
                {
                    utilizatori = new List<Utilizator>();
                    Console.WriteLine("Cheia 'Utilizatori' nu a fost găsită în fișier.");
                }

                if (date.ContainsKey("Sesiuni"))
                {
                    sesiuni = JsonSerializer.Deserialize<List<sesiune>>(date["Sesiuni"].GetRawText(), options) ??
                              new List<sesiune>();
                }
                else
                {
                    sesiuni = new List<sesiune>();
                    Console.WriteLine("Cheia 'Sesiuni' nu a fost găsită în fișier.");
                }
            }

            Console.WriteLine("Datele au fost încărcate cu succes.");
        }

        catch (JsonException ex)
        {

            Console.WriteLine($"Eroare la procesarea fișierului JSON: {ex.Message}");
            utilizatori = new List<Utilizator>();
            sesiuni = new List<sesiune>();
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Eroare la încărcarea datelor: {ex.Message}");
            utilizatori = new List<Utilizator>();
            sesiuni = new List<sesiune>();
        }


    }

    public static void SalveazaDate(string filePath)
    {
        try
        {
            var date = new
            {
                Utilizatori = utilizatori,
                Sesiuni = sesiuni
            };

            string json = JsonSerializer.Serialize(date, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);

            Console.WriteLine("Datele au fost salvate cu succes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la salvarea datelor: {ex.Message}");
        }
    }
}

         
     
    
    



            



