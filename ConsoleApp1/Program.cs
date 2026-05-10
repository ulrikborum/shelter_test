

// 1. Create repository
using ClassLibrary1;

IRepository<Shelter> repo = new Repository<Shelter>();

// 2. Create filter
ShelterFilter filter = new ShelterFilter();

// 3. Create service (inject repository)
ShelterService service = new ShelterService(repo);

// 4. Add some shelters using service
service.CreateShelter(1, "Central Shelter", "Geo1", "Copenhagen", 100);
service.CreateShelter(2, "North Shelter", "Geo2", "Aarhus", 50);
service.CreateShelter(3, "City Shelter", "Geo3", "Copenhagen", 200);

// 5. Get all shelters from repository via service
List<Shelter> allShelters = service.GetAllShelters();

// 6. Use FILTER: by place
Console.WriteLine("Shelters in Copenhagen:");

List<Shelter> copenhagenShelters =
    filter.FilterByPlace(allShelters, "Copenhagen");

foreach (Shelter shelter in copenhagenShelters)
{
    Console.WriteLine(shelter.Name);
}


