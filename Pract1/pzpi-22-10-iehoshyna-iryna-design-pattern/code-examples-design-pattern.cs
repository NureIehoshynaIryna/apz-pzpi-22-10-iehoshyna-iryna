// Абстрактный продукт - сенсор
public interface ISensor
{
    void ReadData();
}

// Сенсор температури
public class TemperatureSensor : ISensor
{
    public void ReadData()
    {
        Console.WriteLine("Зчитування температури...");
    }
}

// Сенсор вологості
public class HumiditySensor : ISensor
{
    public void ReadData()
    {
        Console.WriteLine("Зчитування вологості...");
    }
}

// Сенсор напруги
public class VoltageSensor : ISensor
{
    public void ReadData()
    {
        Console.WriteLine("Зчитування напруги...");
    }
}


// Абстрактна фабрика сенсорів
public interface ISensorFactory
{
    ISensor CreateTemperatureSensor();
    ISensor CreateHumiditySensor();
    ISensor CreateVoltageSensor();
}

// Фабрика сенсорів першого виробника (А)
public class ManufacturerAFactory : ISensorFactory
{
    public ISensor CreateTemperatureSensor()
    {
        return new TemperatureSensor();
    }
    
    public ISensor CreateHumiditySensor()
    {
        return new HumiditySensor();
    }
    
    public ISensor CreateVoltageSensor()
    {
        return new VoltageSensor();
    }
}

// Фабрика сенсорів другого виробника (В)
public class ManufacturerBFactory : ISensorFactory
{
    public ISensor CreateTemperatureSensor()
    {
        return new TemperatureSensor();
    }
    
    public ISensor CreateHumiditySensor()
    {
        return new HumiditySensor();
    }
    
    public ISensor CreateVoltageSensor()
    {
        return new VoltageSensor();
    }
}

// Використання в коді
public class SensorSystem
{
    private readonly ISensor _temperatureSensor;
    private readonly ISensor _humiditySensor;
    private readonly ISensor _voltageSensor;

    public SensorSystem(ISensorFactory factory)
    {
        _temperatureSensor = factory.CreateTemperatureSensor();
        _humiditySensor = factory.CreateHumiditySensor();
        _voltageSensor = factory.CreateVoltageSensor();
    }

    public void ReadAllSensors()
    {
        _temperatureSensor.ReadData();
        _humiditySensor.ReadData();
        _voltageSensor.ReadData();
    }
}

class Program
{
    static void Main()
    {
        ISensorFactory factory;
        
        Console.WriteLine("Оберіть виробника сенсорів: A чи B");
        string userChoice = Console.ReadLine().ToLower();
        
        if (userChoice == "a")
        {
            factory = new ManufacturerAFactory();
        }
        else
        {
            factory = new ManufacturerBFactory();
        }
        
        SensorSystem system = new SensorSystem(factory);
        system.ReadAllSensors();
    }
}