using System;

public class SmartHeater : SmartDevice
{
    private int _temperature;
    public SmartHeater(string name) : base(name)
    {
        _temperature = 70; // Default temperature
    }
    
    public void IncreaseTemp(int increment = 1) // Increases temperature, default = 1
    {
        _temperature += increment;
    }

    public void DecreaseTemp(int decrement = 1) // Decreases temperature, default = 1
    {
        _temperature -= decrement;
    }

    public int GetTemp() // Returns the temperature
    {
        return _temperature;
    }
}