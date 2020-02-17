using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using PixelItems.Utils;

namespace PixelItems
{
	public class PixelPlayer : ModPlayer
	{
		public bool hasMirrorShield = false;
		public int mirrorShieldCooldownFrames = 0;

		private int lastMirrorShieldProc = 0;

		public override void ResetEffects ()
		{
			hasMirrorShield = false;
			mirrorShieldCooldownFrames = int.MaxValue;
		}

		public override bool CanBeHitByProjectile (Projectile proj)
		{
			if (hasMirrorShield && PixelItems.frameCount - lastMirrorShieldProc > mirrorShieldCooldownFrames)
			{
				lastMirrorShieldProc = PixelItems.frameCount;
				return false;
			}
			else
				return base.CanBeHitByProjectile (proj);
		}
	}
}
