using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    //PEGAR TODAS AS PIZZAS 
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    //PEGAR PIZZA CONFORME O ID
    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = PizzaService.GetById(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    // //PEGAR PIZZA CONFORME O NOME
    // [HttpGet("{name}")]
    // public ActionResult<Pizza> GetByName(string name)
    // {
    //     var pizza = PizzaService.GetByName(name);

    //     if (pizza == null)
    //         return NotFound();

    //     return pizza;
    // }

    //INSERIR PIZZA
    //post -c "{"name":"Portuguesa", "isGlutenFree":false}"
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    //ATUALIZAR PIZZA, NUNCA TROCAR O "id": ?, pois ira dar bad request...
    //put 5 -c  "{"id": 5, "name":"Hawaiian", "isGlutenFree":false}"
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = PizzaService.GetById(id);
        if (existingPizza is null)
            return NotFound();

        PizzaService.Update(pizza);

        return NoContent();
    }
    //DELETAR PIZZA CONFORME ID
    //delete id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.GetById(id);

        if (pizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }
}