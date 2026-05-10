using ClassLibrary1;
using System.Collections.Generic;

public interface IRepository<T> where T : IEntity
{
    void Add(T item);

    List<T> GetAll();

    T GetById(int id);

    void Update(int id, T item);

    void Delete(int id);
}