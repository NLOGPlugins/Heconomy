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
using MiNET.Plugins.Attributes;
using MiNET.Utils;

using System.IO;
using Newtonsoft.Json.Linq;

namespace HeconomyAPI.Command
{

    public class Top
    {

        private HeconomyAPI Plugin;

        public Top(HeconomyAPI plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "top", Description = "Shows money ranks in server.", Permission = "heconomyapi.command.rank")]
        public void Execute(Player sender)
        {
            int rank = 1;

            string message = string.Empty;

            foreach(string path in Plugin.GetUsers())
            {
                JObject data = JObject.Parse(File.ReadAllText(path));

                message += ChatColors.Green + rank + ": " + Path.GetFileName(path).Replace(".json", "") + ", " + data["Money"] + Plugin.GetMoneySymbol() + "\n";

                ++rank;
            }

            sender.SendMessage(ChatColors.Green + (rank - 1) + " of players money ranking.");
            sender.SendMessage(message);
        }

        [Command(Name = "rank", Description = "Shows money ranks in server.", Permission = "heconomyapi.command.rank")]
        public void Execute(Player sender, string player)
        {

        }
    }
}