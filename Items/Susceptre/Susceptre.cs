using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VexoVexing.Items.Susceptre
{
    public class Susceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Susceptre"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("They are among us");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 92;
            Item.mana = 5;
            Item.DamageType = DamageClass.Magic;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 6;
            Item.value = 920000;
            Item.rare = -12;
            Item.UseSound = SoundID.DD2_DarkMageAttack;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<SusceptreProjectile>();
            Item.shootSpeed = 15;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new(velocity.X * 3, velocity.Y * 3);
            position += offset;
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}