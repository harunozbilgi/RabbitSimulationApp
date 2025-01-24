namespace RabbitSimulationApp;

public class Rabbit(bool isMale, int fertilityAge)
{
    public bool IsMale { get; } = isMale;
    public int Age { get; set; } = 0;
    public bool IsFertile => Age >= fertilityAge;
}