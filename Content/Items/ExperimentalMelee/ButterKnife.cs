using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.ExperimentalMelee
{
    public class ButterKnife : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.damage = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 1;
            Item.autoReuse = true;
            Item.knockBack = 0;
            Item.ChangePlayerDirectionOnShoot = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RustedKnife>(), 1);
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<RustedKnife>(), 1);
            recipe2.AddIngredient(ItemID.TungstenBar, 10);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
    }
}
