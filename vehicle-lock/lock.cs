using GTANetworkServer;
using GTANetworkShared;
using System.Collections.Generic;
using System;

public class Lock:Script
{

    List<Vehicle> Vehicles;

    public Lock()
    {


    }

    [Command("lock")]
    public void lockvehicle(Client sender)
    {
        foreach (NetHandle c in API.getAllVehicles())
        {
            if (API.getEntityData(sender, "VEHICLES").Contains(c) && API.getPlayersInRadiusOfPosition(2f, API.getEntityPosition(c)).Contains(sender))
            {
                API.setVehicleLocked(c, true);

            }

        }
    }

    [Command("unlock")]
    public void unlockvehicle(Client sender)
    {

        foreach (NetHandle c in API.getAllVehicles())
        {
            if (API.getEntityData(sender, "VEHICLES").Contains(c) && API.getPlayersInRadiusOfPosition(2f, API.getEntityPosition(c)).Contains(sender))
            {
                API.setVehicleLocked(c, false);

            }

        }

    }

}