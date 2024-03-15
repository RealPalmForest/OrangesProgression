using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.ExperimentalMelee
{
    public class RustedKnife : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.width = 46;
            Item.damage = 3;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 1;
            Item.autoReuse = true;
            Item.knockBack = 4;
            Item.ChangePlayerDirectionOnShoot = true;
        }

        public override void ModifyHitNPC(Player player, Terraria.NPC target, ref Terraria.NPC.HitModifiers modifiers)
        {
            int rand = Main.rand.Next(0, 6);
            switch (rand)
            {
                case 0:
                    target.AddBuff(BuffID.Poisoned, 180);
                    break;
                case 1:
                    target.AddBuff(BuffID.Slow, 180);
                    break;
                case 2:
                    target.AddBuff(148, 120);
                    break;
                default: 
                    break;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddIngredient(ItemID.CopperBar, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
