// Add MagicStorage usage
using MagicStorage;
using MagicStorage.Items;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using MSStarterBag.Common.Configs;

namespace MSStarterBag.Items
{
	// Create the StarterBag class, derived from ModItem and ILocalizedModType
	public class StarterBag : ModItem, ILocalizedModType
	{
		// Static default values
		public override void SetStaticDefaults() {
            		Item.ResearchUnlockCount = 0;
        	}

		// Default values
		public override void SetDefaults() {
            		Item.width = 24;
            		Item.height = 24;
            		Item.consumable = true;
            		Item.rare = ItemRarityID.Blue;
        	}

		// You can right click the item
        	public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player) {
			List<Item> storage = new();
			storage.Add(new(ModContent.ItemType<StorageHeart>()));
			storage.Add(new(ModContent.ItemType<CraftingAccess>()));

			for (int i = 0; i < BagConfig.Instance.StorageUnitAmount; i++) {
				storage.Add(new(ModContent.ItemType<StorageUnit>()));
			}

			foreach (Item item in storage) player.QuickSpawnItem(Item.GetSource_Loot(), item);

			Item.TurnToAir();
		}

		/*
		// Change the loot of the starter bag
		public override void ModifyItemLoot(ItemLoot itemLoot) {
			// Add the StorageHeart
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StorageHeart>()));
			// Add the CraftingAccess
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CraftingAccess>()));
			// Add the StorageUnit
			itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<StorageUnit>(), 1, BagConfig.Instance.StorageUnitAmount, BagConfig.Instance.StorageUnitAmount));
		} */
	}
}