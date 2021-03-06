﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PixelItems.Items.Armour.Jouster
{
	[AutoloadEquip (EquipType.Body)]
	public class JousterBody : ModItem
	{
		public override void SetStaticDefaults ()
		{
			Tooltip.SetDefault ("+4% increased movement speed");
		}

		public override void SetDefaults ()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice (0, 0, 86, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 5;
		}

		public override bool IsArmorSet (Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<JousterHelmet> () && legs.type == ModContent.ItemType<JousterLegs> ();
		}

		public override void UpdateArmorSet (Player player)
		{
			if (player.mount.Active)
			{
				player.endurance += 0.06f;
				player.allDamage += 0.18f;

				player.magicCrit += 10;
				player.meleeCrit += 10;
				player.rangedCrit += 10;
				player.thrownCrit += 10;
			}
			
			player.setBonus = "While mounted, gain the following bonuses:" +
							  "\n6% reduced damage" +
							  "\n18% increased damage" +
							  "\n10% increased critical strike chance";
		}

		public override void UpdateEquip (Player player)
		{
			player.moveSpeed += 0.04f;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe (mod);
			recipe.AddIngredient (ItemID.GladiatorBreastplate);
			recipe.AddIngredient (ItemID.FossilOre, 30);
			recipe.AddTile (TileID.Anvils);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
