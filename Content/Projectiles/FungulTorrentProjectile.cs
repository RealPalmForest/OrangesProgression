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
    public class FungulTorrentProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 2;
            Projectile.friendly = true;
            Projectile.timeLeft = 140;
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            int dust1 = Dust.NewDust(Projectile.position, 1, 2, DustID.GlowingMushroom, 0f, 0f, 0, default(Color), 1f);
            int dust2 = Dust.NewDust(Projectile.position, 1, 2, DustID.GlowingMushroom, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust1].velocity.X *= 4f;
            Main.dust[dust2].velocity.X *= 4f;


            Projectile.velocity = oldVelocity * -Main.rand.NextFloat(0.5f, 0.75f);

            return false;
        }


        public override void Kill(int timeLeft)
        {
            int dust1 = Dust.NewDust(Projectile.position, 1, 2, DustID.Cloud, 0f, 0f, 0, default(Color), 1f);
            int dust2 = Dust.NewDust(Projectile.position, 1, 2, DustID.Cloud, 0f, 0f, 0, default(Color), 1f);
            int dust3 = Dust.NewDust(Projectile.position, 1, 2, DustID.Cloud, 0f, 0f, 0, default(Color), 1f);
            int dust4 = Dust.NewDust(Projectile.position, 1, 2, DustID.Cloud, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust1].velocity *= Main.rand.NextFloat(3f, 5f);
            Main.dust[dust2].velocity *= Main.rand.NextFloat(3f, 5f);
            Main.dust[dust3].velocity *= Main.rand.NextFloat(3f, 5f);
            Main.dust[dust4].velocity *= Main.rand.NextFloat(3f, 5f);
        }

        public override void PostAI()
        {
            Lighting.AddLight(Projectile.position, Color.WhiteSmoke.ToVector3() * Main.essScale);

            int dust1 = Dust.NewDust(Projectile.position, 1, 2, DustID.GlowingMushroom, 0f, 0f, 900, default(Color), 1f);
            Main.dust[dust1].velocity.X *= 0.1f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.scale = Main.rand.NextFloat(0.8f, 1.3f);
        }
    }
}