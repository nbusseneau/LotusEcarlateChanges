
namespace LotusEcarlateChanges.Changes;

public static class Constants
{
  public static class Weapon
  {
    public static class MovementModifier
    {
      public const float Knife = 0f;
      public const float Fist = 0f;
      public const float OneHanded = -0.05f;
      public const float TwoHanded = -0.10f;
      public const float Buckler = -0.05f;
      public const float Shield = -0.05f;
      public const float TowerShield = -0.10f;
    }

    public static class ParryBonus
    {
      public const float TowerShield = 1.1f;
    }
  }

  public static class Armor
  {
    public static class VeryLight
    {
      public static class MovementModifier
      {
        public const float Helm = 0f;
        public const float Chest = -0.01f;
        public const float Legs = -0.01f;
      }

      public static class Weight
      {
        public const float Helm = 1f;
        public const float Chest = 6f;
        public const float Legs = 3f;
      }
    }

    public static class SemiLight
    {
      public static class MovementModifier
      {
        public const float Helm = 0f;
        public const float Chest = -0.04f;
        public const float Legs = -0.02f;
      }

      public static class Weight
      {
        public const float Helm = 3f;
        public const float Chest = 10f;
        public const float Legs = 5f;
      }
    }

    public static class Normal
    {
      public static class MovementModifier
      {
        public const float Helm = -0.01f;
        public const float Chest = -0.06f;
        public const float Legs = -0.03f;
      }

      public static class Weight
      {
        public const float Helm = 4f;
        public const float Chest = 12f;
        public const float Legs = 6f;
      }
    }

    public static class Heavy
    {
      public static class MovementModifier
      {
        public const float Helm = -0.02f;
        public const float Chest = -0.08f;
        public const float Legs = -0.04f;
      }

      public static class Weight
      {
        public const float Helm = 5f;
        public const float Chest = 15f;
        public const float Legs = 10f;
      }
    }

    public static class VeryHeavy
    {
      public static class MovementModifier
      {
        public const float Helm = -0.02f;
        public const float Chest = -0.10f;
        public const float Legs = -0.06f;
      }

      public static class Weight
      {
        public const float Helm = 6f;
        public const float Chest = 18f;
        public const float Legs = 12f;
      }
    }
  }
}
