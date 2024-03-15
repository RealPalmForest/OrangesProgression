using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace OrangesProgression.Content.Accessories
{
    public class TundraCharm : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;

            Item.defense = 2;
            Item.value = 123;
            Item.rare = ItemRarityID.Cyan;
            Item.accessory = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.DemoniteBar, 10);
            recipe1.AddIngredient(ItemID.SnowBlock, 10);
            recipe1.AddIngredient(ItemID.IceBlock, 10);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe2.AddIngredient(ItemID.SnowBlock, 10);
            recipe2.AddIngredient(ItemID.IceBlock, 10);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Chilled] = true;

            if (player.ZoneSnow)
            {
                player.GetDamage(DamageClass.Summon) += 10 / 100;
                player.GetDamage(DamageClass.Magic) += 10 / 100;
            }
        }
    }
}
