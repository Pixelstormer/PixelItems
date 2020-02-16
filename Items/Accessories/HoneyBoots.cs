using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PixelItems.Items.Accessories
{
	[AutoloadEquip (EquipType.Shoes)]
	public class HoneyBoots : ModItem
	{
		public override void SetStaticDefaults ()
		{
			Tooltip.SetDefault ("Honey is no longer sticky to walk on.");
		}

		public override void SetDefaults ()
		{
			item.width = 16;
			item.height = 24;
			item.value = Item.sellPrice (0, 2, 50, 0);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void UpdateAccessory (Player player, bool hideVisual)
		{
			player.sticky = false;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe (mod);
			recipe.AddIngredient (ItemID.IceSkates);
			recipe.AddIngredient (ItemID.WaterWalkingBoots);
			recipe.AddTile (TileID.TinkerersWorkbench);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
