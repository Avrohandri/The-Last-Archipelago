using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX; // Prefab efek visual saat dihancurkan
    [SerializeField] private AudioClip destroySFX;  // AudioClip SFX saat objek hancur
    [SerializeField] private float sfxVolume = 1f;  // Volume untuk SFX

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Mengecek jika terkena damage dari objek yang dapat merusak
        if (other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>())
        {
            // Drop item jika ada
            GetComponent<PickUpSpawner>().DropItems();

            // Mainkan efek visual saat objek dihancurkan
            Instantiate(destroyVFX, transform.position, Quaternion.identity);

            // Mainkan SFX saat objek dihancurkan
            if (destroySFX != null)
            {
                AudioSource.PlayClipAtPoint(destroySFX, transform.position, sfxVolume);
            }

            // Hancurkan objek ini
            Destroy(gameObject);
        }
    }
}
