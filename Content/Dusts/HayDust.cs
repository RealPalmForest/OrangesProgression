using System.Security.Policy;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OrangesProgression.Content.Dusts
{
    public class HayDust : ModDust
    {
        public override void SetStaticDefaults()
        {
            //UpdateType = 219;
            UpdateType = DustID.Dirt;
        }

        public override void OnSpawn(Dust dust)
        {
            dust.frame = new Rectangle(0, 0, 16, 16);
        }

        public override bool Update(Dust dust)
        {
            dust.velocity *= 0.4f;
            dust.velocity.Y -= 0.3f;
            dust.alpha += 1;
            if (dust.alpha > 100)
            {
                dust.active = false;
            }
            return false;
        }
    }
}