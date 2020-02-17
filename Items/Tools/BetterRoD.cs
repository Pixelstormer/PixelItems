using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PixelItems.Items.Tools
{
	public class BetterRoD : ModItem
	{
		public override void SetStaticDefaults ()
		{
			DisplayName.SetDefault ("Better Rod of Discord");
			Tooltip.SetDefault ("Teleports you to the position of the mouse." +
								"\nDoes not inflict Chaos State, and ignores terrain.");
		}

		public override void SetDefaults ()
		{
			item.CloneDefaults (ItemID.RodofDiscord);
			item.autoReuse = true;
			item.useTime = 20;
			item.useAnimation = 20;
			item.value = Item.sellPrice (0, 15, 0, 0);
			item.rare = ItemRarityID.Red;

			//item.buffType = BuffID.Slow;
			//item.buffTime = 30;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient (ItemID.RodofDiscord);
			recipe.AddIngredient (ItemID.FragmentNebula, 18);
			recipe.AddIngredient (ItemID.LunarBar, 12);
			recipe.AddIngredient (ItemID.SoulofNight, 20);
			recipe.AddTile (TileID.LunarCraftingStation);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}

		public override bool UseItem (Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				Vector2 newPosition = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				player.Teleport (newPosition, 1);
				// player.AddBuff (BuffID.Slow, 120);
				NetMessage.SendData (MessageID.Teleport, -1, -1, null, 0, player.whoAmI, newPosition.X, newPosition.Y, 1);
				//NetMessage.SendData(Terraria.ID.MessageID.AddPlayerBuff, -1, -1, null, player.whoAmI, BuffID.Slow);
			}
			return true;
		}
	}
}
