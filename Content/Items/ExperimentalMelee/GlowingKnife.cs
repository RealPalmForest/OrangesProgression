using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using OrangesProgression.Content.Projectiles.ExperimentalMeleeProjectiles;

namespace OrangesProgression.Content.Items.ExperimentalMelee
{
    public class GlowingKnife : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.width = 50;
            Item.damage = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 2;
            Item.autoReuse = true;
            Item.knockBack = 5;
            Item.shoot = ModContent.ProjectileType<GlowingKnifeBeam>();
            Item.ChangePlayerDirectionOnShoot = true;
            Item.shootSpeed = 15f;
            Item.UseSound = SoundID.Item15;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ReplenishedKnife>(), 1);
            recipe.AddIngredient(ItemID.Glowstick, 10);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<ReplenishedKnife>(), 1);
            recipe2.AddIngredient(ItemID.Glowstick, 10);
            recipe2.AddIngredient(ItemID.PlatinumBar, 10);
            recipe2.AddTile(TileID.DemonAltar);
            recipe2.Register();
        }
    }
}
