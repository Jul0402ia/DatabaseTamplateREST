using DatabaseTemplateREST.Models;

namespace DatabaseTemplateREST.Repositories
{
    public class ItemRepository
    {
        private readonly TemplateDbContext _context;

        public ItemRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public Item? GetById(int id)
        {
            return _context.Items.FirstOrDefault(
                item => item.Id == id);
        }

        public Item Add(Item item)
        {
            _context.Items.Add(item);

            _context.SaveChanges();

            return item;
        }

        public Item? Delete(int id)
        {
            Item? item = GetById(id);

            if (item == null)
            {
                return null;
            }

            _context.Items.Remove(item);

            _context.SaveChanges();

            return item;
        }

        public Item? Update(int id, Item itemData)
        {
            Item? existingItem = GetById(id);

            if (existingItem == null)
            {
                return null;
            }

            existingItem.Name = itemData.Name;
            existingItem.Category = itemData.Category;
            existingItem.NumberValue = itemData.NumberValue;

            _context.SaveChanges();

            return existingItem;
        }
    }
}