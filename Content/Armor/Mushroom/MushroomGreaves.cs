using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Armor.Mushroom
{
    [AutoloadEquip(EquipType.Legs)]
    public class MushroomGreaves : ModItem
    {
        public override void SetDefaults()
        {
            Item.defense = 1;
            Item.value = 60;
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Mushroom, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
