using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using PixelItems.Utils;

namespace PixelItems.Items.Accessories
{
	[AutoloadEquip (EquipType.Shoes)]
	public class GripBoots : ModItem
	{
		public override bool Autoload (ref string name)
		{
			IL.Terraria.Player.TryBouncingBlocks += HookBounceCheck;
			return base.Autoload (ref name);
		}

		private void HookBounceCheck (ILContext il)
		{
			ILCursor cursor = new ILCursor (il);

			if (!cursor.TryGotoNext (i => i.MatchLdarg (0)))
				throw new InvalidOperationException ($"{nameof (PixelItems)} IL editing failed: {nameof (GripBoots.HookBounceCheck)} could not find entry point.");

			ILLabel continueMethodLabel = il.DefineLabel ();

			cursor.Emit (OpCodes.Ldarg_0);
			cursor.EmitDelegate<Func<Player, bool>> (player => this.isEquippedOn (player));
			cursor.Emit (OpCodes.Brfalse, continueMethodLabel);
			cursor.Emit (OpCodes.Ret);
			cursor.MarkLabel (continueMethodLabel);
		}

		public override void SetStaticDefaults ()
		{
			Tooltip.SetDefault ("These boots let you walk on ice without slipping, and on pink slime without bouncing.");
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
			player.slippy = false;
			player.slippy2 = false;
		}

		public override void AddRecipes ()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient (ItemID.IceSkates);
			recipe.AddIngredient (ItemID.ShoeSpikes);
			recipe.AddIngredient (ItemID.IceBlock, 8);
			recipe.AddIngredient (ItemID.PinkSlimeBlock, 8);
			recipe.AddTile (TileID.Solidifier);
			recipe.SetResult (this);
			recipe.AddRecipe ();
		}
	}
}
