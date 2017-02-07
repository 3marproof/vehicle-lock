using GTANetworkServer;
using GTANetworkShared;
using System.Collections.Generic;
using System;

public class Lock:Script
{

    List<Vehicle> locked;

    public Lock()
    {

        API.onPlayerEnterVehicle += OnPlayerEnterVehicle;
        API.onPlayerExitVehicle += OnPlayerExitVehicleHandler;

    }

    [Command("lock")]
    public void lockvehicle(Client sender)
    {
        if(API.isPlayerInAnyVehicle(sender))
        {

            if(API.getPlayerVehicleSeat(sender)==-1)
            {

                API.sendNotificationToPlayer(sender, "You have locked your vehicle");
                locked.Add(sender.vehicle);

            }

        }


    }

    [Command("unlock")]
    public void unlockvehicle(Client sender)
    {

        if(API.isPlayerInAnyVehicle(sender))
        {

            if(API.getPlayerVehicleSeat(sender)==-1 && locked.Contains(sender.vehicle))
            {

                API.sendNotificationToPlayer(sender, "You have unlocked your vehicle");
                locked.Remove(sender.vehicle);

            }

        }

    }

    private void OnPlayerExitVehicleHandler(Client player, NetHandle vehicle)
    {
        int seat=API.getPlayerVehicleSeat(player);
        foreach(Vehicle c in locked)
        {

            if(vehicle==c)
            {

                API.setPlayerIntoVehicle(player, c, seat);

            }

        }

    }

    private void OnPlayerEnterVehicle(Client player, NetHandle vehicle)
    {

        foreach(Vehicle c in locked)
        {

            if(vehicle==c)
            {

                API.warpPlayerOutOfVehicle(player,vehicle);

            }

        }

    }

}