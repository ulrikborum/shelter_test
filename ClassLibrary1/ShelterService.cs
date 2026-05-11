using ClassLibrary1;
using System;
using System.Collections.Generic;

public class ShelterService
{
    private IRepository<Shelter> _repository;
    private ShelterFilter _filter;

    public ShelterService(IRepository<Shelter> repository)
    {
        _repository = repository;
  
    }


    // CREATE (business logic wrapper)
    public void CreateShelter(int id, string name, string geolocation, string place, int maxCapacity)
    {
        ValidateShelterData(id, name, place, maxCapacity);

        Shelter existing = _repository.GetById(id);

        if (existing != null)
        {
            throw new Exception("Shelter with this ID already exists.");
        }

        Shelter shelter = new Shelter(id, name, geolocation, place, maxCapacity);
        _repository.Add(shelter);
    }

    // READ ALL
    public List<Shelter> GetAllShelters()
    {
        return _repository.GetAll();
    }

    // READ BY ID
    public Shelter GetShelterById(int id)
    {
        return _repository.GetById(id);
    }

    // UPDATE
    public void UpdateShelter(int id, string name, string geolocation, string place, int maxCapacity)
    {
        ValidateShelterData(id, name, place, maxCapacity);

        Shelter existing = _repository.GetById(id);

        if (existing == null)
        {
            throw new Exception("Shelter not found.");
        }

        Shelter updated = new Shelter(id, name, geolocation, place, maxCapacity);
        _repository.Update(id, updated);
    }

    // DELETE
    public void DeleteShelter(int id)
    {
        Shelter existing = _repository.GetById(id);

        if (existing == null)
        {
            throw new Exception("Shelter not found.");
        }

        _repository.Delete(id);
    }

    // BUSINESS VALIDATION (service-level rules)
    private void ValidateShelterData(int id, string name, string place, int maxCapacity)
    {
        if (id <= 0)
            throw new ArgumentException("Id must be greater than 0.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (string.IsNullOrWhiteSpace(place))
            throw new ArgumentException("Place cannot be empty.");

        if (maxCapacity < 0)
            throw new ArgumentException("MaxCapacity cannot be negative.");
    }

    // Filters
    // Inside ShelterService
    public List<Shelter> GetByPlace(string place)
    {
        List<Shelter> all = _repository.GetAll();
        return _filter.FilterByPlace(all, place);
    }

}