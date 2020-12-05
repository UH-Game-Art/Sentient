using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform aimTransform;
    public Transform firePoint; //point of fire from gun
    public int damage = 10; //damage enemy takes 
    public GameObject bulletPrefab;
    public float fireRate = 0.3f;
    private float nextFire = 0.0f;



    private void Start()
    {
        aimTransform = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.player_bullet, 0.3f);
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

    }




}
