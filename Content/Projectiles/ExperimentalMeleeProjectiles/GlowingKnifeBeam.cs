using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace OrangesProgression.Content.Projectiles.ExperimentalMeleeProjectiles
{
    public class GlowingKnifeBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            base.Projectile.width = 16;
            base.Projectile.height = 38;

            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.damage = 10;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 15;
            base.Projectile.knockBack = 2;
            base.Projectile.penetrate = 4;
            base.Projectile.tileCollide = true;
            base.Projectile.alpha = 150;
            base.Projectile.aiStyle = ProjAIStyleID.Beam;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.timeLeft = 150;
        }

        public override void AI()
        {
            Player player = Main.player[base.Projectile.owner];

            
            if (base.Projectile.timeLeft >= base.Projectile.timeLeft - 10)
            {
                base.Projectile.rotation = (Main.MouseWorld - player.Center).ToRotation() + MathHelper.ToRadians(90);
            }
            

            int rand = Main.rand.Next(2);
            if (rand == 0)
            {
                int dust1 = Dust.NewDust(base.Projectile.position + base.Projectile.velocity * -1, base.Projectile.width, base.Projectile.height, DustID.Firework_Blue, base.Projectile.velocity.X * -0.25f, base.Projectile.velocity.Y * 0.01f, 150, default(Color), 0.5f);
                int dust2 = Dust.NewDust(base.Projectile.position + base.Projectile.velocity * -1, base.Projectile.width, base.Projectile.height, DustID.Firework_Pink, base.Projectile.velocity.X * -0.01f, base.Projectile.velocity.Y * 0.01f, 150, default(Color), 0.8f);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].shader = GameShaders.Armor.GetSecondaryShader(player.cPet, player);
            }
            

            Lighting.AddLight(base.Projectile.Center, 1);
        }


        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                int minValue = -6;
                int maxValue = 6;
                Vector2 randomVector = new Vector2(Main.rand.Next(minValue, maxValue), Main.rand.Next(minValue, maxValue));

                int dust3 = Dust.NewDust(Projectile.position, 1, 1, DustID.Firework_Red, 0, 0, 0, default(Color), 0.8f);
                Main.dust[dust3].noGravity = false;
                Main.dust[dust3].velocity = randomVector;
            }
        }
    }
}
