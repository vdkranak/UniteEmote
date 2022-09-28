using UniteEmote.Static;

namespace UniteEmote.Sensors
{
    /// <summary>
    /// Configures Sensors to send and receive data from Intel.Unite.Common 
    /// </summary>
public static class SensorConfig
{
    public static void Setup()
    {
        SetupPluginSensorManager();
        SetupCoreUpdates();
        SetupLocalSensorUpdates();
    }

    private static void SetupLocalSensorUpdates()
    {
        MockSensor.UpdateSensorData += PluginConfig.PluginSensorManager.UpdateSensorData;
    }

    private static void SetupCoreUpdates()
    {
        PluginConfig.RuntimeContext.SensorManager.SensorAdded += new MockSensorHandler().ProcessData;
    }

    private static void SetupPluginSensorManager()
    {
        PluginConfig.PluginSensorManager = new PluginSensorManager(PluginConfig.RuntimeContext.SensorManager);
    }
}
}