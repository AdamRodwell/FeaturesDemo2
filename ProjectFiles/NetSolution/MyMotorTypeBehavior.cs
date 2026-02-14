#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.HMIProject;
using FTOptix.WebUI;
using FTOptix.NetLogic;
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
using FTOptix.MQTTClient;
using FTOptix.MQTTBroker;
using FTOptix.UI;
using FTOptix.Core;
#endregion

[CustomBehavior]
public class MyMotorTypeBehavior : BaseNetBehavior
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined behavior is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined behavior is stopped
    }

    [ExportMethod]
    public void StartMotor()
    {
        Node.Status = true;
    }

    [ExportMethod]
    public void StopMotor()
    {
        Node.Status = false;
    }

#region Auto-generated code, do not edit!
    protected new MyMotorType Node => (MyMotorType)base.Node;
#endregion
}
