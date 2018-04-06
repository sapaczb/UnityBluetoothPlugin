package com.sidewinderstudios.bluetoothplugin;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.content.Intent;

/**
 * Created by Brendon Sapacz on 12/25/2017.
 * Main class for handling bluetooth requests
 */

public class BluetoothHandler
{
    //reference to bluetooth adapter
    private BluetoothAdapter _BTAdapter;

    //reference to current activity
    private Activity _CurrentActivity;

    //code for requesting to enable bluetooth
    public static final int REQUEST_ENABLE_BT = 1;

    //constructor
    public BluetoothHandler(Activity CurrentActivity)
    {
        //cache main activity
        _CurrentActivity = CurrentActivity;

        //try and get bluetooth adapter
        _BTAdapter = BluetoothAdapter.getDefaultAdapter();
    }

    /* Used to enable bluetooth on the current device
    * Returns true if bluetooth was initialized by the user or bluetooth is already enabled
    * Returns false if the device does not support bluetooth, or the user denied bluetooth activation
    * bluetooth*/
    public boolean EnableBluetooth()
    {
        //get adapter
        BluetoothAdapter BTAdapter = BluetoothAdapter.getDefaultAdapter();

        //device doesn't support bluetooth
        if(!DeviceSupportsBluetooth())
        {
            return false;
        }

        //is the device already enabled?
        if(IsBluetoothEnabled())
        {
            return true;
        }

        Intent enableBTAdapter = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
        _CurrentActivity.startActivityForResult(enableBTAdapter, REQUEST_ENABLE_BT);

        return true;
    }

    //checks if the bluetooth adapter is currently enabled
    public boolean IsBluetoothEnabled()
    {
        return _BTAdapter.isEnabled();
    }

    //returns true/false if device supports bluetooth
    public boolean DeviceSupportsBluetooth()
    {
        return (_BTAdapter != null);
    }
}
