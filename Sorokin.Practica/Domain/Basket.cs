namespace Sorokin.Practica.Domain;

public class Basket
{
    public User User { get; set; }
    public int UserId { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
}
