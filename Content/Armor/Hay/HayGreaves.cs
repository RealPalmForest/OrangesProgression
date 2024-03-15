using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Armor.Hay
{
    [AutoloadEquip(EquipType.Legs)]
    public class HayGreaves : ModItem
    {
        public override void SetDefaults()
        {
            Item.defense = 1;
            Item.value = 79;
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Hay, 150);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
