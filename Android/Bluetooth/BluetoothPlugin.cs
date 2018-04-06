using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


namespace AndroidBluetoothPlugin
{
    /// <summary>
    /// This class manages Bluetooth communication between unity and the current android device
    /// All you need to do is create a single instance of this class and start calling functions within the class
    /// </summary>
    public class BluetoothPlugin
    {
        //Bluetooth handler class
        private AndroidJavaObject _BluetoothHandler;

        //String ref to our package name for for class lookup
        private const string PACKAGE_NAME = "com.sidewinderstudios.bluetoothplugin";

        //Constructor
        public BluetoothPlugin()
        {
            //Init our BluetootHandler Java class
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) 
            {
                //use 'using' in conjunction with classes that are created within a function call and inherit from IDisposable to ensure they get destroyed properly
                using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    _BluetoothHandler = new AndroidJavaObject(PACKAGE_NAME + ".BluetoothHandler", currentActivity);
                }
            }
        }

        //Attempts to enable Bluetooth on the current device
        public bool EnableBluetooth()
        {
            return _BluetoothHandler.Call<bool>("EnableBluetooth");
        }

        //returns true/false if Bluetooth is currently enabled on the device
        public bool IsBluetoothEnabled()
        {
            return _BluetoothHandler.Call<bool>("IsBluetoothEnabled");
        }

        //returns true/false if the current device supports Bluetooth
        public bool DeviceSupportsBluetooth()
        {
            return _BluetoothHandler.Call<bool>("DeviceSupportsBluetooth");
        }

        /// <summary>
        /// Searches for nearby devices and returns a list of device ids
        /// </summary>
        /// <returns></returns>
        public List<string> SearchForDevices()
        {
            List<string> Devices = new List<string>();
            return Devices;
        }
    }
}


