using Microsoft.Xna.Framework;
using OrangesProgression.Content.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.Weapons.Ranged
{
	public class HaystackNeedler : ModItem
	{
		public override void SetDefaults() {
			// Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

			// Common Properties
			Item.width = 54; // Hitbox width of the item.
			Item.height = 28; // Hitbox height of the item.
			Item.scale = 0.75f;
			Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.

			// Use Properties
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.useAnimation = 14;
			Item.useTime = 7;
            Item.reuseDelay = 14;
            Item.consumeAmmoOnLastShotOnly = true;

            Item.UseSound = SoundID.Item39;

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
			Item.damage = 9; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 3f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.


			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 15f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Bullet;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Hay, 135)
				.AddIngredient(ItemID.IronBar, 6)
				.AddTile(TileID.WorkBenches)
				//.AddCondition(Condition.InGraveyard)
				.Register();

            CreateRecipe()
                .AddIngredient(ItemID.Hay, 135)
                .AddIngredient(ItemID.LeadBar, 6)
                .AddTile(TileID.WorkBenches)
                //.AddCondition(Condition.InGraveyard)
                .Register();
        }

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset() {
			return new Vector2(-16f, 0.5f);
		}

		
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			float misdirectionMultiplier = Main.rand.NextFloat() + 0.75f;


			if (Main.rand.NextBool(8))
				velocity.X *= 0.6f;
			else if (Main.rand.NextBool(4))
			{
				velocity.X *= 0.6f;
				velocity.Y *= 1.4f;
			}

			velocity *= misdirectionMultiplier;


            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<HaystackNeedlerProjectile>();
                damage *= 3;
            }
        }
		
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            if (type == ModContent.ProjectileType<HaystackNeedlerProjectile>() && Main.rand.NextBool(5))
				Projectile.NewProjectile(source, position, velocity *= 0.75f, ProjectileID.PineNeedleFriendly, damage, knockback, player.whoAmI);


            int dust = Dust.NewDust(position, 1, 2, DustID.Gold, 0f, 0f, 0, default(Color), 1f);

            Main.dust[dust].velocity.X *= -2f;

            return true;
		}
		
		



        // How can I make the shots appear out of the muzzle exactly?
        // Also, when I do this, how do I prevent shooting through tiles?
        /*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
		}*/


        // How can I shoot 2 different projectiles at the same time?
		/*
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(source, position, velocity, ProjectileID.GrenadeI, damage, knockback, player.whoAmI);

			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}
		*/
    }
}
