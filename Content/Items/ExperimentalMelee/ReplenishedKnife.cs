using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.ExperimentalMelee
{
    public class ReplenishedKnife : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.width = 44;
            Item.damage = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 1;
            Item.autoReuse = true;
            Item.knockBack = 5;
            Item.ChangePlayerDirectionOnShoot = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RustedKnife>(), 1);
            recipe.AddIngredient(ItemID.ArmorPolish, 1);
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
