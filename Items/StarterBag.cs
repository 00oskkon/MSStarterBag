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

			// Warning!
			// Everything below looks like crap
			// I might clean it up...

			// Add the configured amounts of Storage Units to the list
			if (BagConfig.Instance.StorageUnitAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.StorageUnitAmount; i++) {
					storage.Add(new(ModContent.ItemType<StorageUnit>()));
				}
			}

			// Add the configured amounts of Crimtane Storage Upgrades to the list
			if (BagConfig.Instance.CrimtaneAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.CrimtaneAmount; i++) {
					storage.Add(new(ModContent.ItemType<UpgradeCrimtane>()));
				}
			}

			// Add the configured amounts of Demonite Storage Upgrades to the list
			if (BagConfig.Instance.DemoniteAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.DemoniteAmount; i++) {
					storage.Add(new(ModContent.ItemType<UpgradeDemonite>()));
				}
			}

			// Add the configured amounts of Hellstone Storage Upgrades to the list
			if (BagConfig.Instance.HellstoneAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.HellstoneAmount; i++) {
					storage.Add(new(ModContent.ItemType<UpgradeHellstone>()));
				}
			}

			// Add the configured amounts of Hallowed Storage Upgrades to the list
			if (BagConfig.Instance.HallowedAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.HallowedAmount; i++) {
					storage.Add(new(ModContent.ItemType<UpgradeHallowed>()));
				}
			}

			// Add the configured amounts of Blue Chlorophyte Storage Upgrades to the list
			if (BagConfig.Instance.ChlorophyteAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.ChlorophyteAmount; i++) {
					storage.Add(new(ModContent.ItemType<UpgradeBlueChlorophyte>()));
				}
			}

			// Add the configured amounts of Luminite Storage Upgrades to the list
			if (BagConfig.Instance.LuminiteAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.LuminiteAmount; i++) {
					storage.Add(new(ModContent.ItemType<UpgradeLuminite>()));
				}
			}

			// Add the configured amounts of Terra Storage Upgrades to the list
			if (BagConfig.Instance.TerraAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.TerraAmount; i++) {
					storage.Add(new(ModContent.ItemType<UpgradeTerra>()));
				}
			}

			// Add the configured amounts of Shadow Diamonds to the list
			if (BagConfig.Instance.ShadowDiamondAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.ShadowDiamondAmount; i++) {
					storage.Add(new(ModContent.ItemType<ShadowDiamond>()));
				}
			}

			// Add the configured amounts of Storage Components to the list
			if (BagConfig.Instance.ComponentAmount > 0) {
				for (int i = 0; i < BagConfig.Instance.ComponentAmount; i++) {
					storage.Add(new(ModContent.ItemType<StorageComponent>()));
				}
			}

			// Add all the items from the list
			foreach (Item item in storage) player.QuickSpawnItem(Item.GetSource_Loot(), item);

			// Remove the 'bag' item
			Item.TurnToAir();
		}
	}
}