using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.ExperimentalMelee
{
    public class DirtSword : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Melee;
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = -10;
            Item.value = 1000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextFloat() < 0.05f) //5%
            {
                Item.stack = 0;
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Dirt, 0f, 0f, 0, default, .9f);
            Main.dust[dust].velocity *= 0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}