namespace proiect_poo;

public abstract class Utilizator
{
    public Utilizator(string email,string nrMatricol,string numePers,string parola)
    {
        Email=email;
        NrMatricol=nrMatricol;
        NumePers=numePers;
        Parola=parola;
    }
    public string Email {get ;set ;}
    public string NrMatricol {get ;}
    public string NumePers {get; set;}
    private   string Parola {get;}
}
