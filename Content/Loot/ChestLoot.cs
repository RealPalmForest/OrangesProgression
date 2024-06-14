using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using OrangesProgression.Content.Items.Weapons.Melee.Yoyos;

namespace OrangesProgression.Content.Items
{
    public class ChestLoot : ModSystem
    {
        public override void PostWorldGen()
        {
            // Loop through all chests in the world
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];

                if (chest == null)
                    continue;

                // If it's a container (chest)
                if (Main.tile[chest.x, chest.y].TileType == TileID.Containers)
                {
                    // If this is a sky chest
                    if (Main.tile[chest.x, chest.y].TileFrameX == 13 * 36)
                    {
                        if(Main.rand.NextBool(4))
                        {
                            // Replace primary item with yoyo
                            chest.item[0].SetDefaults(ModContent.ItemType<ShootingStarYoyo>());
                        }

                        /*
                        // Go through each chest slot
                        for (int slot = 0; slot < 40; slot++)
                        {
                            // Get first empty slot
                            if (chest.item[slot].type == ItemID.None)
                            {
                                chest.item[0].SetDefaults(ModContent.ItemType<ShootingStarYoyo>());
                                break;
                            }
                        }
                        */
                    }
                }
            }
        }

        private bool ChestContainsItemId(Chest chest, int id)
        {
            if(chest != null)
            {
                for (int slot = 0; slot < 40; slot++)
                {
                    if (chest.item[slot].type == id)
                        return true;
                }
            }

            return false;
        }
    }
}