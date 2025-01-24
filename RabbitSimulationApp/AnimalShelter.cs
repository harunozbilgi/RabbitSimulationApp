namespace RabbitSimulationApp;

public class AnimalShelter<T> where T : Rabbit
{
    private readonly List<T> _animals = [];

    public void AddAnimal(T animal) => _animals.Add(animal);

    public List<T> GetAll() => _animals;

    public void AgeAllAnimals() => _animals.ForEach(a => a.Age++);

    public void RemoveOldAnimals(int maxAge) => _animals.RemoveAll(x => x.Age > maxAge);
}