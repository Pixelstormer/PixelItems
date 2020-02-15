using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PixelItems.Utils;

namespace PixelItems.Items.Accessories
{
	// TOOD: Set proper values for SetDefaults and Vertical/HorizontalWingsSpeeds. Currently using those of ExampleMod's ExampleWings.
	[AutoloadEquip (EquipType.Wings)]
	public class InfiniteWings : ModItem
	{
		public override void SetStaticDefaults ()
		{
			// DisplayName.SetDefault ("");
			Tooltip.SetDefault ("Allows flight." +
								"\nSelf-sustaining, these wings never tire.");
		}

		public override void SetDefaults ()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory (Player player, bool hideVisual)
		{
			player.wingTime = float.PositiveInfinity;
		}

		public override void VerticalWingSpeeds (Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds (Player player, ref float speed, ref float acceleration)
		{
			speed = 9f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe (mod);
			recipe.AddIngredient (ItemID.LunarBar, 10);
			recipe.AddIngredient (ItemID.WyvernBanner);
			recipe.AddRecipeGroup (PixelItems.RecipeGroupName.LunarWings.fullName ());
			recipe.AddTile (TileID.LunarCraftingStation);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
