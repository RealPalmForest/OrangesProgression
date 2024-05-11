using Microsoft.Xna.Framework;
using OrangesProgression.Content.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.Weapons.Ranged
{
    public class HeartstringBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.value = 146;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 6;
            Item.noMelee = true;
        }

        public override void AddRecipes()
        {
            Recipe recipeCorruption = CreateRecipe();
            recipeCorruption.AddIngredient(ItemID.Wood, 75);
            recipeCorruption.AddIngredient(ItemID.DemoniteBar, 8);
            recipeCorruption.AddIngredient(ItemID.LifeCrystal, 3);
            recipeCorruption.AddTile(TileID.WorkBenches);

            Recipe recipeCrimson = CreateRecipe();
            recipeCrimson.AddIngredient(ItemID.Wood, 75);
            recipeCrimson.AddIngredient(ItemID.CrimtaneBar, 8);
            recipeCrimson.AddIngredient(ItemID.LifeCrystal, 3);
            recipeCrimson.AddTile(TileID.WorkBenches);

            recipeCorruption.Register();
            recipeCrimson.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            //target.AddBuff(BuffID.Lovestruck, 480);
            //target.AddBuff(BuffID.OnFire);
        }

        /*
         * TODO: Move this to the custom projectile code, run every tick
         * 
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            int dust = Dust.NewDust(position, 1, 1, DustID.HeartCrystal, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity *= 1.1f;
        }
        */

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if(type == ProjectileID.WoodenArrowFriendly)
            {
                damage += 5;
                type = ModContent.ProjectileType<CupidArrow>();
            }
        }
    }
}