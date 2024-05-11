using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OrangesProgression.Content.Dusts;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Projectiles
{
    public class CupidArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.timeLeft = 500;

            Projectile.scale = 0.9f;

            Projectile.width = 0;
            Projectile.height = 0;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(1, 4))
            {
                int dust = Dust.NewDust(Projectile.position, 1, 1, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust].velocity *= 1.1f;
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.Lovestruck, 420);
        }

        public override void OnKill(int timeLeft)
        {
            Dust.NewDust(Projectile.position, 1, 1, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1f);
            Dust.NewDust(Projectile.position, 1, 1, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1f);
            Dust.NewDust(Projectile.position, 1, 1, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1f);
            Dust.NewDust(Projectile.position, 1, 1, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1f);
            Dust.NewDust(Projectile.position, 1, 1, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1f);
        }
    }
}