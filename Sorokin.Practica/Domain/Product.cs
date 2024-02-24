namespace Sorokin.Practica.Domain;

public class Product : Entity
{
    public string Name { get; set; }    
    public double FacePrice { get; set; }
    public double RealPrice { get; set; }
    public string Provider { get; set; }
    public double Rating { get; set; }
    public int VoteAmount { get; set; }
    public int Sale { get; set; }
    public string PhotoPath { get; set; }
}
