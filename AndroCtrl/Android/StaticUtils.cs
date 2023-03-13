using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AndroCtrl.Connection;

using AndroCtrl.Protocols.AndroidDebugBridge;
using AndroCtrl.Protocols.AndroidDebugBridge.DeviceCommands;

namespace AndroCtrl.Android
{
    public partial class AndroidDevice
    {
        public static AndroidDevice CreateNewDevice(DeviceData device)
        {
            AndroidDevice dev = new(device);
            if (SerializeDeviceAddress(device.Serial) is DnsEndPoint ep)
            {
                dev.EndPoint = ep;
                dev.ConnectionType = ConnectionTypes.Wifi;
            }

            if (!IsDeviceUsable(device.State))
            {
                return dev;
            }

            GatherDeviceInfo(device, dev);

            dev.Shell = Adb.Client.StartShell(device);

            return dev;
        }

        public static bool IsDeviceUsable(DeviceState state)
        {
            if (state
                is DeviceState.Offline
                or DeviceState.NoPermissions
                or DeviceState.Unauthorized
                or DeviceState.Authorizing
                or DeviceState.Unknown)
            {
                return false;
            }
            return true;
        }

        public static void GatherDeviceInfo(DeviceData device, AndroidDevice dev)
        {
            var props = Adb.Client.GetProperties(device);

            props.TryGetValue("ro.product.device", out string dName);
            props.TryGetValue("ro.product.model", out string model);
            props.TryGetValue("ro.product.manufacturer", out string manufacturer);
            props.TryGetValue("ro.build.version.sdk", out string api);
            props.TryGetValue("ro.build.fingerprint", out string fingerprint);

            dev.DeviceName = dName;
            dev.Model = model;
            dev.Manufacturer = manufacturer;
            dev.API = api;
            dev.Fingerprint = fingerprint;

            dev.HasInfo = dName != string.Empty && model != string.Empty;
        }

        public static DnsEndPoint SerializeDeviceAddress(string serial)
        {
            string[] rawEndpoint = serial.Split(":");
            if (rawEndpoint.Length == 2 && IPAddress.TryParse(rawEndpoint[0], out IPAddress? ip) && int.TryParse(rawEndpoint[1], out int port))
            {
                return new(ip.ToString(), port);
            }
            return null;
        }

        public static string TrimSerial(string serial)
        {
            string[] rawEndpoint = serial.Split(":");
            if (rawEndpoint.Length == 2 && IPAddress.TryParse(rawEndpoint[0], out IPAddress? ip) && int.TryParse(rawEndpoint[1], out int port))
            {
                return ip.ToString();
            }
            return serial;
        }
    }
}
