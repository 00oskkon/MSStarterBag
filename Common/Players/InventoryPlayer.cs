using MSStarterBag.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSStarterBag.Common.Players
{
	public class InventoryPlayer : ModPlayer
	{
		// Override your characters starting items
		public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath) {
			// Create an item
			static Item createItem(int type) {
                		Item i = new Item();
                		i.SetDefaults(type);
                		return i;
           		}

			// Assign the starterbag to the created item
            		if (!mediumCoreDeath) {
                		yield return createItem(ModContent.ItemType<StarterBag>());
			}
		}
	}
}