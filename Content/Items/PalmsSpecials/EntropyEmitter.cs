using Microsoft.Xna.Framework;
using OrangesProgression.Content.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.PalmsSpecials
{
    public class EntropyEmitter : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 26; // Hitbox height of the item.
            Item.scale = 0.95f;
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

            // Use Properties
            Item.useTime = 41; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 41; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.

            // The sound that this item plays when used.
            Item.UseSound = SoundID.NPCHit36;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 100; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.

            // Gun Properties
            Item.shoot = ModContent.ProjectileType<EctoBlasterProjectile>(); // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)
            //Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            /*

            CreateRecipe()
                .AddTile(TileID.Anvils)
                .AddCondition(Condition.InGraveyard)
                .AddIngredient(ModContent.ItemType<SoulOfSpite>(), 14)
                .AddIngredient(ItemID.HellstoneBar, 12)
                .AddIngredient(ItemID.ShadowScale, 10)
                .Register();

            CreateRecipe()
                .AddTile(TileID.Anvils)
                .AddCondition(Condition.InGraveyard)
                .AddIngredient(ModContent.ItemType<SoulOfSpite>(), 14)
                .AddIngredient(ItemID.HellstoneBar, 12)
                .AddIngredient(ItemID.TissueSample, 10)
                .Register();

            */
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-21f, 1f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            float newDamage = damage * Main.rand.NextFloat(0.2f, 2.4f);
            float newKnockback = knockback * Main.rand.NextFloat(0.85f, 2.25f);
            //Vector2 newVelocity = velocity * Main.rand.NextFloat(0.75f, 1.25f);
            

            damage = (int) newDamage;
            if (newKnockback > 0) knockback = newKnockback;
            //velocity = newVelocity;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float projectileAmount = Main.rand.Next(3, 30);

            if (projectileAmount > projectileAmount / 2) 
            {
                float temp = Main.rand.Next(3, (int) projectileAmount);

                if(temp < projectileAmount)
                    projectileAmount = temp;
            }

			float rotation = MathHelper.ToRadians(Main.rand.Next(50));

			position += Vector2.Normalize(velocity) * 45f;

			for (int i = 0; i < projectileAmount; i++)
            {
                int projectileType = Main.rand.Next(1, 1);

                CombatText.NewText(new Rectangle((int)position.X + Main.rand.Next(1, 40) * (int)velocity.X, (int)position.Y + Main.rand.Next(1, 40) * (int)velocity.Y, Main.rand.Next(20, 120), Main.rand.Next(20, 120)), Color.Orange, Main.rand.Next(999));

                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (projectileAmount - 1)) * Main.rand.NextFloat(1f, 1.3f)) * Main.rand.NextFloat(0.2f, 0.9f); // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, projectileType, damage, knockback, player.whoAmI);
			}

			return false; // return false to stop vanilla from calling Projectile.NewProjectile.
		}
    }
}
