using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.Weapons.Melee
{
	public class StemSword : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.OrangesProgression.hjson file.

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 44;

			Item.damage = 13;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 33;
			Item.useAnimation = 33;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = 150;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Mushroom, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6f, 6f);
        }
    }
}