using Microsoft.Xna.Framework;
using OrangesProgression.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.Weapons
{
	public class MushroomWhip : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.OrangesProgression.hjson file.

        public override void SetDefaults()
        {
            Item.shootSpeed = 0.9f;

            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<MushroomWhipProjectile>(), 20, 2, 4);
            Item.rare = ItemRarityID.Orange;
            Item.channel = true;
            Item.damage = 17;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Mushroom, 27);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}