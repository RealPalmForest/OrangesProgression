using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Items.Weapons.Ranged
{
    public class SharkronLauncher : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 60;
            Item.height = 20;
            Item.scale = 1.1f;
            Item.rare = ItemRarityID.Purple;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 98;
            Item.knockBack = 3f;
            Item.noMelee = true;
            Item.shoot = ProjectileID.MiniSharkron;
            Item.shootSpeed = 14f;
            Item.useAmmo = AmmoID.Bullet;
            Item.UseSound = SoundID.Item11;
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, -3f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.Bullet) {
				type = ProjectileID.MiniSharkron;
			}
        }

        public override bool CanBeConsumedAsAmmo(Item weapon, Player player)
        {
            return Main.rand.NextFloat() >= .33f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Lighting.AddLight(Item.Center, Color.Blue.ToVector3() * 4f);
            return true;
        }
    }
}