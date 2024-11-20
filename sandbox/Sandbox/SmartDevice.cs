using System;
using System.Diagnostics;

public abstract class SmartDevice
{
    private string _name;
    private bool _isOn;
    private TimeSpan _runningTime;
    private Stopwatch _timeCounter;

    public SmartDevice(string name)
    {
        _name = name;
        _runningTime = new TimeSpan();
        _isOn = false;
        _timeCounter = new Stopwatch();
    }
    public string GetName() // Returns the name
    {
        return _name;
    }
    public bool GetPowerStatus() // Returns if it is turned on or off
    {
        return _isOn;
    }
    public TimeSpan GetRunningTime() // Returns the running time
    {
        if (_isOn)
        {
            _runningTime += _timeCounter.Elapsed; 
        }
        return _runningTime;
    }
    public void StartDevice() // Sets the device to PowerStatus On and starts the running time
    {
        _isOn = true;
        _timeCounter.Start();
    }
    public void StopDevice() // Sets the device to PowerStatus Off and ends the running time
    {
        _isOn = false;
        _runningTime += _timeCounter.Elapsed;
        _timeCounter.Stop();
    }
}
