using System;

public class SmartTV : SmartDevice
{
    private int _channel;
    public SmartTV(string name) : base(name)
    {
        _channel = 1; // Default Channel = 1
    }

    public void ChangeChan(int channel) // Changes the channel
    {
        _channel = channel;
    }

    public int GetChannel() // Returns the channel
    {
        return _channel;
    }
}