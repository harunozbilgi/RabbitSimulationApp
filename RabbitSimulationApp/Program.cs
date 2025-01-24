using Microsoft.Extensions.Configuration;
using RabbitSimulationApp;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var maxAge = configuration.GetValue<int>("MaxAge");
var fertilityAge = configuration.GetValue<int>("FertilityAge");
var initialMale = configuration.GetValue<int>("InitialMaleRabbits");
var initialFemale = configuration.GetValue<int>("InitialFemaleRabbits");

Console.WriteLine("Enter the number of months to simulate:");
int months = int.Parse(Console.ReadLine() ?? "0");

var simulation = new Simulation(maxAge, fertilityAge, initialMale, initialFemale);
await simulation.RunSimulationAsync(months);
simulation.DisplayResults();