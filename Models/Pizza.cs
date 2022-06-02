namespace ContosoPizza.Models;

//INFORMAÇÕES SOBRE O MODELO DE PIZZA
public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public bool IsGlutenFree { get; set; }
}