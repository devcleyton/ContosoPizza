using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Portuguesa", Price = 15.99, IsGlutenFree = true },
            new Pizza { Id = 2, Name = "Vegetariana", Price = 19.99, IsGlutenFree = true },
            new Pizza { Id = 3, Name = "Calabresa", Price = 12.99, IsGlutenFree = true },
            new Pizza { Id = 4, Name = "4 Queijos", Price = 18.99, IsGlutenFree = true },
            new Pizza { Id = 5, Name = "Lombinho", Price = 14.99, IsGlutenFree = true },
            new Pizza { Id = 6, Name = "Frango Catupiry", Price = 23.99, IsGlutenFree = true },
            new Pizza { Id = 7, Name = "A moda", Price = 27.99, IsGlutenFree = true }
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}