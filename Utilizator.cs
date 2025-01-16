
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;

namespace proiect_poo;

[JsonConverter(typeof(UtilizatorConverter))]
public abstract class Utilizator
{
    public Utilizator() { }
    public Utilizator(string email, string nrMatricol, string numePers, string parola)
    {
        Email = email;
        NrMatricol = nrMatricol;
        SetNumePers(numePers); 
        Parola = parola;
    }

    public string Email { get; set; }
    public string NrMatricol { get; }
    public string NumePers { get; private set; }
    public string Parola { get; }
    
    
    public void SetNumePers(string nume)
    {
        if (!EsteNumeValid(nume))
            throw new ArgumentException("Numele conține caractere invalide.");
        NumePers = nume;
    }

    
    private static bool EsteNumeValid(string nume)
    {
        if (string.IsNullOrWhiteSpace(nume))
            return false;

        string pattern = @"^[a-zA-Z\s]+$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(nume);
    }


    public void SetEmail(string email)
    {
        if (!EsteEmailValid(email))
            throw new ArgumentException("Adresa de email nu este validă.");
        Email = email;
    }


    private static bool EsteEmailValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }
}
