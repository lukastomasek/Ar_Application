using UnityEngine;


namespace LukasScripts
{
    public class HelperClass
    {
        public float DealDamage(float min, float max)
        {
            float damage = 0f;

            damage = Random.Range(min, max);

            return damage;
        }

        public AudioClip RandomAudio(AudioClip[] a)
        {
            int rand = Random.Range(0, a.Length);

            return a[rand];
        }

        public int RandomNumber(int rand_1, int rand_2)
        {
            int rand = Random.Range(rand_1, rand_2);
            return rand;
        }
    }

}