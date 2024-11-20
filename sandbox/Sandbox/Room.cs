using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

public class Room
{
    private string _name;
    private List<SmartDevice> _devices;
    private List<SmartLight> _lights;
    private List<SmartHeater> _heaters;
    private List<SmartTV> _tvs;

    public Room(string name, int ligthCount, int heaterCount, int tvCount)
    {
        _name = name;
        _devices = new List<SmartDevice>();
        _lights = new List<SmartLight>();
        _heaters = new List<SmartHeater>();
        _tvs = new List<SmartTV>();
        
        for (int count=1; count<=ligthCount; count++)
            {
                SmartLight smartLight = new SmartLight($"Light #{count}");
                _lights.Add(smartLight);
                _devices.Add(smartLight);
            }
        for (int count=1; count<=heaterCount; count++)
            {
                SmartHeater smartHeater = new SmartHeater($"Heater #{count}");
                _heaters.Add(smartHeater);
                _devices.Add(smartHeater);
            }
        for (int count=1; count<=tvCount; count++)
            {
                SmartTV smartTV = new SmartTV($"TV #{count}");
                _tvs.Add(smartTV);
                _devices.Add(smartTV);
            }
    }
    // Room commands
    public void TurnOnLights() // Turn all lights On
    {
        foreach (SmartLight light in _lights)
        {
            light.StartDevice();
        }
    }
    public void TurnOffLights() // Turn all lights Off
    {
        foreach (SmartLight light in _lights)
        {
            light.StopDevice();
        }
    }
    public void TurnOnDevices() // Turn all devices On
    {
        foreach (SmartDevice device in _devices)
        {
            device.StartDevice();
        }
    }
    public void TurnOffDevices() // Turn all devices Off
    {
        foreach (SmartDevice device in _devices)
        {
            device.StopDevice();
        }
    }
    public string ReportDevices() // Report all device items in the room and their status
    {
        string _ = $"{_name}:\n";
        foreach(SmartDevice device in _devices)
        {
            bool powerStatus = device.GetPowerStatus();
            string status;
            if (powerStatus)
            {
                status="ON";
            }
            else
            {
                status="OFF";
            }
            string name = device.GetName();
            _ += $"{name}: Power is {status}, running for {device.GetRunningTime().Seconds} seconds.\n";
        }
        _ += $"-----------------------";
        return _;
    }
    public string ReportOnItems() // Report all devices that are power ON
    {
        string _ = $"All devices that are powered ON in {_name}:\n";
        foreach(SmartDevice device in _devices)
        {
            if (device.GetPowerStatus())
            {
                string status="ON";
                string name = device.GetName();
                _ += $"{name}: Power is {status}\n";
            }
        }
        return _;
    }
    public string ReportLongestItem() // Report item that have beem on the longest
    {
        string report;
        SmartDevice device = null;
        TimeSpan runningTime = new TimeSpan(0);
        foreach(SmartDevice d in _devices)
        {
            if(d.GetRunningTime() > runningTime)
            {
                device = d;
                runningTime = d.GetRunningTime();
            }
        }
        if(device == null)
        {
            report = $"No device ran in this {_name}";
        }
        else{
            report = $"{_name}:\n{device.GetName()} has been ON the longest for {runningTime.Seconds} seconds\n------------------------------";
        }
        return report;
    }
    
    // Getters
    public List<SmartDevice> GetSmartDevices()
    {
        return _devices;
    }
    public List<SmartLight> GetLights()
    {
        return _lights;
    }
    public List<SmartHeater> GetHeaters()
    {
        return _heaters;
    }
    public List<SmartTV> GetTvs()
    {
        return _tvs;
    }
    public string GetName()
    {
        return _name;
    }
}