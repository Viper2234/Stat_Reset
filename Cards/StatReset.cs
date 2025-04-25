using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ModdingUtils.Extensions;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace Stat_Reset.Cards
{
    class StatReset : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            UnityEngine.Debug.Log($"[{Stat_Reset.ModInitials}][Card] {GetTitle()} has been setup.");
        }

        public void ResetGunStats(Gun gun)
        {
            // Get the type of the Gun class
            Type gunType = gun.GetType();

            // Get the internal method ResetStats using reflection
            MethodInfo resetStatsMethod = gunType.GetMethod("ResetStats", BindingFlags.NonPublic | BindingFlags.Instance);

            if (resetStatsMethod != null)
            {
                // Invoke the ResetStats method on the Gun object
                resetStatsMethod.Invoke(gun, null);
                Debug.Log("Gun stats have been reset.");
            }
            else
            {
                Debug.LogWarning("ResetStats method not found.");
            }
        }

        public void ResetBlockStats(Block block)
        {
            // Get the type of the Gun class
            Type blocktype = block.GetType();

            // Get the internal method ResetStats using reflection
            MethodInfo resetStatsMethod = blocktype.GetMethod("ResetStats", BindingFlags.NonPublic | BindingFlags.Instance);

            if (resetStatsMethod != null)
            {
                // Invoke the ResetStats method on the Gun object
                resetStatsMethod.Invoke(block, null);
                Debug.Log("Block stats have been reset.");
            }
            else
            {
                Debug.LogWarning("ResetStats method not found.");
            }
        }

        public void ResetStatModifiyingStats(CharacterStatModifiers statModifiers)
        {
            // Get the type of the Gun class
            Type statModifierstype = statModifiers.GetType();

            // Get the internal method ResetStats using reflection
            MethodInfo resetStatsMethod = statModifierstype.GetMethod("ResetStats", BindingFlags.NonPublic | BindingFlags.Instance);

            if (resetStatsMethod != null)
            {
                // Invoke the ResetStats method on the Gun object
                resetStatsMethod.Invoke(statModifiers, null);
                Debug.Log("Block stats have been reset.");
            }
            else
            {
                Debug.LogWarning("ResetStats method not found.");
            }
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            // Reset stats for the gun using reflection
            if (gun != null)
            {
                ResetGunStats(gun);
            }

            if (block != null)
            {
                ResetBlockStats(block);
            }

            if (characterStats != null)
            {
                ResetStatModifiyingStats(characterStats);
            }
        }

        protected override string GetTitle()
        {
            return "Stat Reset";
        }
        protected override string GetDescription()
        {
            return "Set all stats to their default values";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "All Stats",
                    amount = "Default",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return Stat_Reset.ModInitials;
        }
    }
}
