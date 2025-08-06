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

		// When you right click the item
		public override void RightClick(Player player) {
			// A list of the items to give the player
			List<Item> storage = new();

			// Check the config if the player should get a Storage Heart and add to the list
			if (BagConfig.Instance.GetStorageHeart) {
				storage.Add(new(ModContent.ItemType<StorageHeart>()));
			}
			// Check the config if the player should get a Crafting Interface and add to the list
			if (BagConfig.Instance.GetCraftingAccess) {
				storage.Add(new(ModContent.ItemType<CraftingAccess>()));
			}

			// Add the configured amounts of Storage Units to the list
			for (int i = 0; i < BagConfig.Instance.StorageUnitAmount; i++) {
				storage.Add(new(ModContent.ItemType<StorageUnit>()));
			}

			if (BagConfig.Instance.CrimtaneAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.CrimtaneAmount; i++) {
					storage.Add(new(ModContent.ItemType<UpgradeCrimtane>()));
				}
			}

			// Add all the items from the list
			foreach (Item item in storage) player.QuickSpawnItem(Item.GetSource_Loot(), item);

			// Remove the 'bag' item
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