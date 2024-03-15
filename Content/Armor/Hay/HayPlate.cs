using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Content.OrangesProgression.Armor.Hay
{
    [AutoloadEquip(EquipType.Body)]
    public class HayPlate : ModItem
    {
        public override void SetDefaults()
        {
            Item.defense = 2;
            Item.value = 79;
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Mushroom, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}