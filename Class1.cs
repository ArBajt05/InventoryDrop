using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace InventoryDroppingPlugin
{
    public class Class1 : RocketPlugin<Configuration>
    {
        public static Class1 Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("InventoryDroppingPlugin has been loaded");
            Logger.Log("InventoryDroppingPlugin created by ArBajt");
        }

        protected override void Unload()
        {
            Logger.Log("InventoryDroppingPlugin has been unloaded");
            Logger.Log("InventoryDroppingPlugin created by ArBajt");
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            {"Drop_message","{0} undresses"}
        };
    }
}
