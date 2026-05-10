using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;

    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private List<T> _items;

        public Repository()
        {
            _items = new List<T>();
        }

        public Repository(List<T> items)
        {
            _items = items;
        }

        // CREATE
        public void Add(T newItem)
        {
            if (newItem == null)
                throw new ArgumentNullException("item");

            foreach (T item in _items)
            {
                if (item.Id == newItem.Id)
                {
                    throw new Exception("Item with this ID already exists.");
                }
            }

            _items.Add(newItem);
        }

        // READ ALL
        public List<T> GetAll()
        {
            return new List<T>(_items);
        }

        // READ BY ID
        public T GetById(int id)
        {
            foreach (T item in _items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return default;
        }

        // UPDATE
        public void Update(int id, T updatedItem)
        {
            if (updatedItem == null)
                throw new ArgumentNullException("updatedItem");

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Id == id)
                {
                    _items[i] = updatedItem;
                    return;
                }
            }

            throw new Exception("Item not found.");
        }

        // DELETE
        public void Delete(int id)
        {
            T itemToDelete = GetById(id);

            if (itemToDelete == null)
            {
                throw new Exception("Item not found.");
            }

            _items.Remove(itemToDelete);
        }
    }
}
