namespace Office.Weapons
{
    /// <summary>
    /// Allows an entity to be hitted.
    /// </summary>
    public interface IHittable
    {
        void Hit(float damage);
    }
}