using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Content.OrangesProgression.Armor.Mushroom
{
	[AutoloadEquip(EquipType.Head)]
	public class MushroomCap : ModItem
	{
		public override void SetDefaults()
		{
			Item.defense = 2;
			Item.value = 56;
			Item.rare = ItemRarityID.Orange;
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