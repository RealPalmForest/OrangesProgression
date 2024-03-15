using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.Projectiles
{
    public class PalmsTomeOfBananasProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.SuperStar;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.timeLeft = 240;
            Projectile.scale = 0.75f;
            Projectile.penetrate = 4;
        }

        public override void OnSpawn(IEntitySource source)
        {
            //Projectile.position = Projectile.pl
        }

        public override void PostAI()
        {
            Projectile.scale += 0.008f;
            Projectile.velocity *= 1.01f;


            Lighting.AddLight(Projectile.position, Color.WhiteSmoke.ToVector3() * Main.essScale);

            if(Projectile.timeLeft > 235)
            {
                int dust1 = Dust.NewDust(Projectile.position, 1, 2, DustID.Firework_Yellow, 0f, 0f, 700, default(Color), 1f);
                Main.dust[dust1].velocity *= 1.1f;
            }
        }

        public override void ModifyHitNPC(Terraria.NPC target, ref Terraria.NPC.HitModifiers modifiers)
        {
            if(target.boss)
                modifiers.FinalDamage *= 0.8f;
        }
    }
}