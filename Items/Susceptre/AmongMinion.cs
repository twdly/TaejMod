using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VexoVexing.Dusts;

namespace VexoVexing.Items.Susceptre
{
    public class AmongMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Imposters");
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = -1;
            Projectile.damage = 92;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.minion = true;
            Projectile.minionSlots = 0f;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 920;
            Projectile.owner = Main.myPlayer;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {
            // Makes the among obey gravity
            Projectile.velocity += Vector2.UnitY * 0.1f;

            int attackTarget = -1;
            Projectile.Minion_FindTargetInRange(920, ref attackTarget, false);
            if (attackTarget != -1)
            {
                Projectile.velocity += (Main.npc[attackTarget].Center - Projectile.Center) * 0.1f;
                if (Projectile.velocity.Length() > 25)
                {
                    Projectile.velocity *= 0.1f;
                }
                // Projectile.friendly = attackTarget != -1;
            }
            else
            {
                Projectile.velocity.X *= 0.5f;
            }

            // Play effects when the among disappears
            if (Projectile.timeLeft == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Clentaminator_Red);
                }
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Zombie92);
            }

            // Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ninetytwodust>());
            // Dust.NewDustPerfect(Projectile.position, ModContent.DustType<ninetytwodust>());
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 3;
        }
    }
}