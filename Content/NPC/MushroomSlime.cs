using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace OrangesProgression.Content.NPC
{
    // This ModNPC serves as an example of a completely custom AI.
    public class MushroomSlime : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 26;
            NPC.damage = 14;
            NPC.defense = 5;
            NPC.lifeMax = 30;
            NPC.value = 50f;
            NPC.aiStyle = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.GreenSlime;
            AnimationType = NPCID.GreenSlime;

            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.25f;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
            {
                NPC.frameCounter = 0;
            }
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Gel, Main.rand.Next(0, 2));
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Mushroom, Main.rand.Next(1, 4)); // Drops 1 - 3 Mushrooms
        }
    }
}