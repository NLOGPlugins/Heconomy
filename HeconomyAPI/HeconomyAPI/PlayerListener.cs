﻿
/*
    ooooo   ooooo                     .o8        .ooooo.   
    `888'   `888'                    "888       888' `Y88. 
     888     888   .ooooo.  oooo d8b  888oooo.  888    888 
     888ooooo888  d88' `88b `888""8P  d88' `88b  `Vbood888 
     888     888  888ooo888  888      888   888       888' 
     888     888  888    .o  888      888   888     .88P'  
    o888o   o888o `Y8bod8P' d888b     `Y8bod8P'   .oP'     

    Directed by Herb9.
*/

using MiNET;

using System;

namespace HeconomyAPI
{

    public class PlayerListener
    {

        private HeconomyAPI Plugin;

        public PlayerListener(HeconomyAPI plugin)
        {
            Plugin = plugin;
        }

        public void CallEvent(object sender, PlayerEventArgs eventArgs)
        {
            Player player = eventArgs.Player;

            if (!Plugin.IsRegisteredPlayer(player.Username))
            {
                Plugin.RegisterPlayer(player);

                Console.WriteLine(HeconomyAPI.Prefix + " Could not find " + player.Username + "'s data, registering " + player.Username + "'s data...");
            }
        }
    }
}