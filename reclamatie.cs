namespace proiect_poo;

public class reclamatie
{
    public string Id { get; set; }
    
    public string StudentNume { get; set; }
    public string Raspuns { get; set; }
    public bool Rezolvat { get; set; }
    public string Mesaj { get; set; }

    public reclamatie(string id, string mesaj)
    {
        Id = id;
        Mesaj = mesaj;
    }
    
    
}