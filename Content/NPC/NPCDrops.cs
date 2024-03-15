using Microsoft.Xna.Framework;
using OrangesProgression.Content.Items;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrangesProgression.Content.NPC
{
	public class NPCDrops : GlobalNPC
	{
        /*
        public override void ModifyNPCLoot(Terraria.NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Zombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulOfSpite>(), 1));
            }
        }
        */

        
        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            globalLoot.Add(new ItemDropWithConditionRule(ModContent.ItemType<SoulOfSpite>(),5, 1, 1, new SoulOfSpiteDropCondition()));
        }
    }
}
