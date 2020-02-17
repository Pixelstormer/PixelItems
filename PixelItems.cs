using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using PixelItems.Utils;

namespace PixelItems
{
	public class PixelItems : Mod
	{
		private const string LANGUAGEKEY_ANY = "LegacyMisc.37";

		public static int frameCount { get; private set; } = 0;

		public override void AddRecipeGroups ()
		{
			RecipeGroup lunarWingGroup = new RecipeGroup (() => Language.GetTextValue (LANGUAGEKEY_ANY) + " Lunar Wings", new int []
			{
				ItemID.WingsSolar,
				ItemID.WingsVortex,
				ItemID.WingsNebula,
				ItemID.WingsStardust
			});

			RecipeGroup.RegisterGroup (RecipeGroupName.LunarWings.fullName (), lunarWingGroup);

			RecipeGroup basicBalloonGroup = new RecipeGroup (() => Language.GetTextValue (LANGUAGEKEY_ANY) + " Basic Balloon", new int []
			{
				ItemID.ShinyRedBalloon,
				ItemID.BalloonPufferfish
			});

			RecipeGroup.RegisterGroup (RecipeGroupName.BasicBalloons.fullName (), basicBalloonGroup);
		}

		public override void PostUpdateEverything ()
		{
			++frameCount;
		}

		public enum RecipeGroupName
		{
			LunarWings,
			BasicBalloons
		}
	}
}
