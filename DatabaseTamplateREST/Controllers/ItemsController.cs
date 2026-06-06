using DatabaseTemplateREST.Models;
using DatabaseTemplateREST.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTemplateREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository _repository;

        public ItemsController(ItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetById(int id)
        {
            Item? item = _repository.GetById(id);

            if (item == null)
            {
                return NotFound("Objekt med dette id findes ikke.");
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> Add(Item item)
        {
            Item createdItem = _repository.Add(item);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdItem.Id },
                createdItem);
        }

        [HttpPut("{id}")]
        public ActionResult<Item> Update(int id, Item itemData)
        {
            Item? updatedItem =
                _repository.Update(id, itemData);

            if (updatedItem == null)
            {
                return NotFound("Objekt med dette id findes ikke.");
            }

            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public ActionResult<Item> Delete(int id)
        {
            Item? deletedItem =
                _repository.Delete(id);

            if (deletedItem == null)
            {
                return NotFound("Objekt med dette id findes ikke.");
            }

            return Ok(deletedItem);
        }
    }
}