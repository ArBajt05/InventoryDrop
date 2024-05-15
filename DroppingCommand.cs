using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace InventoryDroppingPlugin
{
    public class DroppingCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Player;
            }
        }

        public string Name
        {
            get
            {
                return "drop";
            }
        }

        public string Help
        {
            get
            {
                return "/drop to drop everything on the ground";
            }
        }

        public string Syntax
        {
            get
            {
                return "";
            }
        }

        public List<string> Aliases
        {
            get
            {
                return new List<string>();
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>()
                {
                    "eq.drop"
                };
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (player == null)
            {
                return;
            }

            if (player != null)
            {
                player.Player.clothing.askWearBackpack(0, 0, new byte[0], true);
                player.Player.clothing.askWearVest(0, 0, new byte[0], true);
                player.Player.clothing.askWearShirt(0, 0, new byte[0], true);
                player.Player.clothing.askWearPants(0, 0, new byte[0], true);
                player.Player.clothing.askWearGlasses(0, 0, new byte[0], true);
                player.Player.clothing.askWearHat(0, 0, new byte[0], true);
                player.Player.clothing.askWearMask(0, 0, new byte[0], true);

                // "page" down here is one big container of slots in every clothing
                /* 0-1 Primary,
                 * 1-2 Secondry,
                 * 2-3 Hands
                 */

                for (byte page = 0; page < 8; page++)
                {
                    var count = player.Inventory.getItemCount(page);

                    for (byte index = 0; index < count; index++)
                    {
                        player.Inventory.ReceiveDropItem(page, player.Inventory.getItem(page, index).x, player.Inventory.getItem(page, index).y);
                        index--;
                        count--;
                    }
                }

                if (Class1.Instance.Configuration.Instance.ShouldShowDropMessage)
                {
                    ChatManager.serverSendMessage(Class1.Instance.Translate("Drop_message", player.CharacterName), Color.white, null, player.SteamPlayer(), EChatMode.LOCAL, Class1.Instance.Configuration.Instance.DropMessageIcon, true);
                }
            }
        }
    }
}
