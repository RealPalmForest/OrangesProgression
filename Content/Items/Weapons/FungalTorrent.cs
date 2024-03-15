using Microsoft.Xna.Framework;
using OrangesProgression.Content.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.Weapons
{
    public class FungalTorrent : ModItem
    {
        public override void SetDefaults()
        {
            // DefaultToStaff handles setting various Item values that magic staff weapons use.
            // Hover over DefaultToStaff in Visual Studio to read the documentation!
            // Shoot a black bolt, also known as the projectile shot from the onyx blaster.
            Item.DefaultToStaff(ModContent.ProjectileType<FungulTorrentProjectile>(), 15, 20, 11);
            Item.width = 38;
            Item.height = 42;
            Item.scale = 0.8f;
            Item.UseSound = SoundID.Item20;



            // A special method that sets the damage, knockback, and bonus critical strike chance.
            // This weapon has a crit of 32% which is added to the players default crit chance of 4%
            Item.SetWeaponValues(45, 4, 32);

            Item.rare = ItemRarityID.Cyan;

            Item.mana = 9;

            Item.useAnimation = 15;
            Item.reuseDelay = 20;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0f, -2f);
        }



        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddTile(TileID.MythrilAnvil)
                .AddIngredient(ItemID.SpellTome)
                .AddIngredient(ItemID.SoulofSight, 6)
                .AddIngredient(ItemID.SoulofFright, 6)
                .AddIngredient(ItemID.SoulofMight, 6)
                .AddIngredient(ItemID.GlowingMushroom, 95)
                .Register();
        }

        public override void ModifyManaCost(Player player, ref float reduce, ref float mult)
        {
            // Weapon uses 20% less mana if used in glowing mushroom biome

            if (player.ZoneGlowshroom)
            {
                mult *= 0.8f;

            }
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Weapon deals 20% less damage

            damage -= damage / 20;



            // Weapon damage is increased by 10% if used in glowing mushroom biome

            if (player.ZoneGlowshroom)
            {
                damage += damage / 10;
            }
        }



        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            
            // Loop these functions 5 times to spawn 5 projectiles.
            for (int i = 0; i < 5; i++)
            {
                position = new Vector2(target.X, player.Center.Y) - new Vector2(Main.rand.NextFloat(301) * player.direction, 600f);
                position.Y -= 100 * i;

                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }


                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
            }

            return false;
        }
    }
}
