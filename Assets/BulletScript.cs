public struct Bullet
{
    public int damage;
    public float speed;
    
    public enum DamageNumbers
    {
        Pistol = 2,
        Rifle = 2,
        Plasma = 5,
        Alien = 7,
        Robot = 3,
    }

    public Bullet(float speed, int damage)
    {
        this.damage = damage;
        this.speed = speed;

    }
}