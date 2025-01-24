Rabbit Simulation Project

Overview

The Rabbit Simulation project is a dynamic application built with .NET Core. It simulates the lifecycle of a rabbit colony, tracking population growth, aging, and fertility over multiple cycles. The project is designed to be generic, allowing for future expansions to include other animal types.

Features

Configurable simulation parameters via appsettings.json.

Tracks male and female rabbit populations, including their fertility and aging.

Supports multi-threaded simulation for efficient computation.

Outputs detailed results, including population counts and maximum rabbit age.

Easily extendable for additional animal types.

Technologies Used

.NET Core 9.0

Microsoft.Extensions.Configuration for configuration management

Task-based asynchronous programming for multi-threading

Configuration

The simulation's parameters are managed through the appsettings.json file, located in the root directory. Below is an example configuration:

{
  "MaxAge": 60,
  "FertilityAge": 6,
  "InitialMaleRabbits": 1,
  "InitialFemaleRabbits": 1
}

Parameters

MaxAge: The maximum age a rabbit can reach (in months).

FertilityAge: The minimum age at which rabbits become fertile.

InitialMaleRabbits: The number of male rabbits at the start of the simulation.

InitialFemaleRabbits: The number of female rabbits at the start of the simulation.

How to Run

Clone the repository to your local machine.

git clone <repository_url>

Navigate to the project directory.

cd RabbitSimulationApp

Build the project.

dotnet build

Run the application.

dotnet run

Enter the number of months for the simulation when prompted.

Simulation Flow

The program initializes with the parameters defined in appsettings.json.

Rabbits age with each cycle.

Fertile male and female rabbits reproduce, adding new rabbits to the colony.

Rabbits exceeding the MaxAge are removed from the population.

At the end of the simulation, the program outputs:

Total male and female rabbits.

Maximum age reached by any rabbit.

Example Output

Enter the number of months to simulate:
12
Month 1: Starting simulation...
Month 1: Population: 2
...
Month 12: Population: 120
Simulation Results:
- Male Rabbits: 60
- Female Rabbits: 60
- Max Age: 12

Extending the Project

To add support for additional animal types:

Create a new class inheriting the Rabbit structure.

Adjust the simulation logic in Simulation.cs to handle the new animal type.

Update appsettings.json to include parameters for the new animal type.

License

This project is licensed under the MIT License. See the LICENSE file for details.

Acknowledgments

Special thanks to the .NET Core community for their contributions to modern application development frameworks.

