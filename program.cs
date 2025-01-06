namespace program-poo;

class program
{
    static List<utilizator> utilizatori = new List<utilizator>();
    static List<sesiune> sesiuni = new List<sesiune>();
    static utilizator utilizatorLogat = null;
    
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
            Console.WriteLine("3. Ieșire");
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
