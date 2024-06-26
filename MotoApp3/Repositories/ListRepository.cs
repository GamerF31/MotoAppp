namespace MotoApp3.Repositories
{
    using MotoApp3.Entities;

    public class ListRepository<T, Tkey>
        where T : class, IEntity, new()
    {
        private List<T> _items = new();

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
            //return _items.Single(item => item.Id == id);
        }
        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }
        public void Save()
        {

        }

    }
}
