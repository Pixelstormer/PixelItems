using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PixelItems.Items.Armour.Jouster
{
	[AutoloadEquip (EquipType.Legs)]
	public class JousterLegs : ModItem
	{
		public override void SetStaticDefaults ()
		{
			Tooltip.SetDefault ("Jouster leg armour." +
								"\nIncreased movement speed." +
								"\nSet bonus: Grants extra bonuses while mounted.");
		}

		public override void SetDefaults ()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 45;
		}

		public override bool IsArmorSet (Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<JousterHelmet> () && body.type == ModContent.ItemType<JousterBody> ();
		}

		public override void UpdateArmorSet (Player player)
		{
			if (player.mount.Active)
				player.statDefense += 100;

			player.setBonus = "+100 defence while mounted.";
		}

		public override void UpdateEquip (Player player)
		{
			player.moveSpeed += 0.5f;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient (ItemID.GladiatorLeggings);
			recipe.AddTile (TileID.WorkBenches);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
