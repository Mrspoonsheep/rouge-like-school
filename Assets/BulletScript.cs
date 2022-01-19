public struct Bullet
{
    public int damage;
    public float speed;
    public bool explosive;
    
    public enum DamageNumbers
    {
        Pistol  = 1,
        rifle = 1,
        plasmaGun = 3,
    }

    public Bullet(float speed, int damage, bool explosive) 
    {
        this.damage = damage;
        this.speed = speed;
        this.explosive = explosive;
        
    }

    public void hoaming() 
    { 
    
    }
}