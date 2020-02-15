using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using PixelItems.Utils;

namespace PixelItems
{
	public class PixelItems : Mod
	{
		public PixelItems()
		{

		}

		public override void AddRecipeGroups ()
		{
			RecipeGroup lunarWingGroup = new RecipeGroup (() => Language.GetTextValue("LegacyMisc.37") + " Lunar Wings", new int []
			{
				ItemID.WingsSolar,
				ItemID.WingsVortex,
				ItemID.WingsNebula,
				ItemID.WingsStardust
			});
			RecipeGroup.RegisterGroup (RecipeGroupName.LunarWings.fullName (), lunarWingGroup);
		}

		public enum RecipeGroupName
		{
			LunarWings
		}
	}
}
