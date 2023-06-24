using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VexoVexing.Items.WaterArrow
{
    public class WaterArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This should not be possible");
            Item.SetNameOverride("Water arrow");
        }

        public override void SetDefaults()
        {
            Item.ammo = AmmoID.Arrow;
            Item.damage = 92;
            Item.DamageType = DamageClass.Ranged;
            Item.shoot = ModContent.ProjectileType<WaterArrowProjectile>();
            Item.maxStack = 999;
            Item.consumable = true;
            Item.crit = 4;
            Item.knockBack = 5;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}