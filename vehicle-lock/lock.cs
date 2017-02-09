using GTANetworkServer;
using GTANetworkShared;
using System.Collections.Generic;
using System;

public class Lock : Script
{

    [Command("lock")]
    public void lockvehicle(Client sender)
    {
        foreach (NetHandle c in API.getAllVehicles())
        {
            if (API.getPlayersInRadiusOfPosition(2f, API.getEntityPosition(c)).Contains(sender))
            {
                API.consoleOutput("lel");
                API.setVehicleLocked(c, true);

            }

        }
    }

    [Command("unlock")]
    public void unlockvehicle(Client sender)
    {

        foreach (NetHandle c in API.getAllVehicles())
        {
            if (API.getPlayersInRadiusOfPosition(2f, API.getEntityPosition(c)).Contains(sender))
            {
                API.setVehicleLocked(c, false);

            }

        }

    }
}