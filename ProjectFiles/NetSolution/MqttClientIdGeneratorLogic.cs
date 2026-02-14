#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.WebUI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Alarm;
using FTOptix.Recipe;
using FTOptix.DataLogger;
using FTOptix.EventLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.Report;
using FTOptix.OPCUAServer;
using FTOptix.System;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.Core;
using FTOptix.MQTTClient;
using System.Linq;
using FTOptix.MQTTBroker;
using System.Threading;
#endregion

public class MqttClientIdGeneratorLogic : BaseNetLogic
{
    public override void Start()
    {
        var updateTask = new LongRunningTask(UpdateClientIds, LogicObject);
        updateTask.Start();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    private void UpdateClientIds()
    {
        ChangeClientId("MQTT/Mosquitto_MQTTClient");
        ChangeClientId("MQTT/Optix_MQTTClient");
    }

    private void ChangeClientId(string mqttClientPath)
    {
        var mqttClient = Project.Current.Get<MQTTClient>(mqttClientPath);
        if (mqttClient.ClientId == "FTOptix-1")
        {
            mqttClient.ClientId = $"OptixUser-{Guid.NewGuid().ToString().Split("-")[0]}";
            mqttClient.Stop();
            Thread.Sleep(1000);
            mqttClient.Start();
            Log.Info("ClientIdGeneratorLogic", $"ClientId was set to {mqttClient.ClientId}");
        }
    }

}
