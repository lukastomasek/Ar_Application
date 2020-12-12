using UnityEngine;


public class HelperClass 
{
    public float DealDamage(float min, float max)
    {
        float damage = 0f;

        damage = Random.Range(min, max);

        return damage;
    }
}
