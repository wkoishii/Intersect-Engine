using System;
using Intersect.Client.Core;
using Intersect.Client.Framework.Audio;
using Intersect.Client.Framework.Content;
using Intersect.Client.Framework.Graphics;
using Intersect.Client.Framework.Input;
using Intersect.Client.Framework.Maps;
using Intersect.Client.Framework.Plugins.Interfaces;
using Intersect.Client.General;
using Intersect.Client.Maps;
using Intersect.Client.Plugins.Audio;
using Intersect.Client.Plugins.Helpers;
using Intersect.Client.Plugins.Interfaces;
using Intersect.Factories;
using Intersect.Plugins;
using Intersect.Plugins.Contexts;
using Intersect.Plugins.Interfaces;

using DiscordRPC;

namespace Intersect.Client.Plugins.Discord
{
    public DiscordRpcClient client;
    void Initialize() 
    {
        /*
        Create a Discord client
        */
        client = new DiscordRpcClient("1099093530342850621");

        //Subscribe to events
        client.OnReady += (sender, e) =>
        {
            Console.WriteLine("Received Ready from user {0}", e.User.Username);
        };
		
        client.OnPresenceUpdate += (sender, e) =>
        {
            Console.WriteLine("Received Update! {0}", e.Presence);
        };
	
        //Connect to the RPC
        client.Initialize();

        //Set the rich presence
        //Call this as many times as you want and anywhere in your code.
        client.SetPresence(new RichPresence()
        {
            Details = "Connected to Server",
            State = "Ah yes",
            Assets = new Assets()
            {
                LargeImageKey = "placeholder",
                LargeImageText = "Ah yes",
                SmallImageKey = "placeholder"
            }
        });	
    }
    
}
