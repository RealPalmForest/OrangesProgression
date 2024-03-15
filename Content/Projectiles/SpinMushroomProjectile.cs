using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Projectiles
{
    public class SpinMushroomProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.Mushroom;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.penetrate = 2;
            Projectile.friendly = true;
            Projectile.timeLeft = 200;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(5))
            {
                //int dust1 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, DustID.Palladium, base.Projectile.velocity.X / 5, base.Projectile.velocity.Y, 100, default, 1f);

                int dust = Dust.NewDust(Projectile.position, 1, 2, DustID.Palladium, 0f, 0f, 75, default(Color), 1f);
                int moreDust = Dust.NewDust(Projectile.position, 1, 2, DustID.Palladium, 0f, 0f, 75, default(Color), 1f);
                Main.dust[dust].velocity.X *= 0.5f;
                Main.dust[moreDust].velocity.X *= 0.5f;

                //int particleDust = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, DustID.OrangeStainedGlass, base.Projectile.velocity.X * 0.01f, base.Projectile.velocity.Y, 220, default, 0.8f);
                //Main.dust[particleDust].noGravity = true;
            }

            base.AI();
        }
    }
}