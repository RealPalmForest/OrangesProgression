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
    public class HaystackNeedlerProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.Nail;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.timeLeft = 200;
            Projectile.scale = 0.85f;

        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (Main.rand.NextBool(1, 3))
            {
                int minValue = -4;
                int maxValue = 4;
                Vector2 randomVector = new Vector2(-1, Main.rand.Next(minValue, maxValue));

                int dust1 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Hay, 1, 1, 0, default(Color), 1.1f);
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].velocity = randomVector;
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 1; i++)
            {
                int minValue = -2;
                int maxValue = 2;
                Vector2 randomVector = new Vector2(Main.rand.Next(minValue, maxValue), Main.rand.Next(minValue, maxValue));

                int minValue2 = -3;
                int maxValue2 = 3;
                Vector2 randomVector2 = new Vector2(Main.rand.Next(minValue2, maxValue2), Main.rand.Next(minValue2, maxValue2));

                int dust2 = Dust.NewDust(Projectile.position, 1, 1, ModContent.DustType<HayDust>(), 0, 0, 0, default, 1f);
                Main.dust[dust2].noGravity = false;
                Main.dust[dust2].velocity = randomVector;

                
                int dust3 = Dust.NewDust(Projectile.position, 1, 1, DustID.GoldCritter, 0, 0, 0, default(Color), 0.8f);
                Main.dust[dust3].noGravity = false;
                Main.dust[dust3].velocity = randomVector2;
                
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return false;
        }
    }
}