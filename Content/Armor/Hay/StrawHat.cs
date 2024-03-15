using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Armor.Hay
{
	[AutoloadEquip(EquipType.Head)]
	public class StrawHat : ModItem
	{
		public override void SetDefaults()
		{
			Item.defense = 1;
			Item.value = 50;
			Item.rare = ItemRarityID.White;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Hay, 100);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}