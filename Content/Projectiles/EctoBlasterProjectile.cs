using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Projectiles
{
    public class EctoBlasterProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.LunarProjectile;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.timeLeft = 340;
            Projectile.scale = 0.75f;
            Projectile.penetrate = 10;
        }

        public override void PostAI()
        {
            Lighting.AddLight(Projectile.position, Color.WhiteSmoke.ToVector3() * Main.essScale);

            int dust = Dust.NewDust(Projectile.position, 1, 2, DustID.SilverFlame, 0f, 0f, 0, default(Color), 1f);
            int moreDust = Dust.NewDust(Projectile.position, 1, 2, DustID.SilverFlame, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity.X *= 0.5f;
            Main.dust[moreDust].velocity.X *= 0.5f;
        }

        public override void ModifyHitNPC(Terraria.NPC target, ref Terraria.NPC.HitModifiers modifiers)
        {
            if(target.boss)
            {
                modifiers.FinalDamage *= 0.6f;
            }
        }
    }
}