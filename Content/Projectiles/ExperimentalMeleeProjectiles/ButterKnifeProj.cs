using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OrangesProgression.Content.Projectiles.ExperimentalMeleeProjectiles
{
    public class ButterKnifeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            base.Projectile.width = 32;
            base.Projectile.height = 32;

            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.damage = 10;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 15;
            base.Projectile.knockBack = 0;
            base.Projectile.penetrate = 0;
            base.Projectile.tileCollide = true;
            base.Projectile.alpha = 150;
            base.Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.timeLeft = 100;
        }

        public override void AI()
        {
            Player player = Main.player[base.Projectile.owner];
            /*
            if (base.Projectile.timeLeft == 150)
            {
                base.Projectile.rotation = (Main.MouseWorld - player.Center).ToRotation() + MathHelper.ToRadians(90);
            }
            */
            

            Lighting.AddLight(base.Projectile.Center, 1);
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                int minValue = -3;
                int maxValue = 3;
                Vector2 randomVector = new Vector2(Main.rand.Next(minValue, maxValue), Main.rand.Next(minValue, maxValue));

                int dust3 = Dust.NewDust(Projectile.position, 1, 1, DustID.Iron, 0, 0, 0, default(Color), 0.8f);
                Main.dust[dust3].noGravity = false;
                Main.dust[dust3].velocity = randomVector;
            }
        }
    }
}
