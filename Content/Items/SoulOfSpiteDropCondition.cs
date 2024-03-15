using Microsoft.VisualBasic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;

namespace OrangesProgression.Content.Items
{
    public class SoulOfSpiteDropCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            Terraria.NPC npc = info.npc;

            return !npc.boss
                && !npc.friendly
                && npc.lifeMax > 1
                && npc.value >= 1f
                && info.player.ZoneGraveyard;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Drops in Graveyard biome";
        }
    }
}