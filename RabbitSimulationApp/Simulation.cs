namespace RabbitSimulationApp;

public class Simulation
{
    private readonly int _maxAge;
    private readonly int _fertilityAge;
    private readonly AnimalShelter<Rabbit> _shelter;

    public Simulation(int maxAge, int fertilityAge, int initialMale, int initialFemale)
    {
        _maxAge = maxAge;
        _fertilityAge = fertilityAge;
        _shelter = new AnimalShelter<Rabbit>();

        for (var i = 0; i < initialMale; i++)
            _shelter.AddAnimal(new Rabbit(true, _fertilityAge));

        for (var i = 0; i < initialFemale; i++)
            _shelter.AddAnimal(new Rabbit(false, _fertilityAge));
    }

    public async Task RunSimulationAsync(int months)
    {
        for (var month = 1; month <= months; month++)
        {
            Console.WriteLine($"Month {month}: Starting simulation...");
            _shelter.AgeAllAnimals();

            await Task.Run(() =>
            {
                var males = _shelter.GetAll().Count(r => r is { IsMale: true, IsFertile: true });
                var females = _shelter.GetAll().Count(r => r is { IsMale: false, IsFertile: true });

                var newRabbits = males * females;
                for (var i = 0; i < newRabbits; i++)
                {
                    var isMale = new Random().Next(2) == 0;
                    _shelter.AddAnimal(new Rabbit(isMale, _fertilityAge));
                }
            });

            _shelter.RemoveOldAnimals(_maxAge);
            Console.WriteLine($"Month {month}: Population: {_shelter.GetAll().Count}");
        }
    }

    public void DisplayResults()
    {
        var males = _shelter.GetAll().Count(x => x.IsMale);
        var females = _shelter.GetAll().Count(x => !x.IsMale);
        var maxAge = _shelter.GetAll().Max(x => x.Age);

        Console.WriteLine("Simulation Results:");
        Console.WriteLine($"- Male Rabbits: {males}");
        Console.WriteLine($"- Female Rabbits: {females}");
        Console.WriteLine($"- Max Age: {maxAge}");
    }
}