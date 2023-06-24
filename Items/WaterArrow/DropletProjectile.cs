using System;
using Microsoft.Xna.Framework;
using static Microsoft.Xna.Framework.MathHelper;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace VexoVexing.Items.WaterArrow
{
    class DropletProjectile : ModProjectile
    {
        public int count = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Arrow Droplet");
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.friendly = true;
            Projectile.stepSpeed = 92;
            Projectile.penetrate = -1;
            Projectile.scale = 0.5f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.SplashWeak);
            for (int i = 0; i < 92; i++)
            {
                Dust.NewDust(Projectile.Center, 5, 5, DustID.Water);
            }
            return true;
        }

        public override void AI()
        {
            // for (int i = 0; i < 10; i++)
            // {
            //     Dust.NewDust(Projectile.Center, 5, 5, DustID.Water);
            // }
        }
    }
}
