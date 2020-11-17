using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootingRange = 40f;
    [SerializeField] private float aimSpeed = 2.7f;
    public float fireRate = 0.2f;
    public float nextFire = 0.0f;
    private Transform firePoint;
    private Transform player;
    private bool playerWithinRange = false;
    private bool playerFound = false;

    // Start is called before the first frame update
    void Start()
    {
        if (player = GameObject.FindGameObjectWithTag("Player").transform)
        {
            firePoint = this.gameObject.transform.GetChild(0).transform;
            Debug.Log(this.gameObject.transform.GetChild(0).name);
            playerFound = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerFound && withinRange())
        {
            HandleAiming();
            shoot();
        }
    }

    private void HandleAiming()
    {
        if (transform.position.x < player.position.x)
        {
            Vector3 vectorToTarget = player.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);
            angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg);
            firePoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if (transform.position.x >= player.position.x)
        {
            Vector3 vectorToTarget = player.position - transform.position;
            float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 180;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);
            angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg);
            firePoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private bool withinRange()
    {
        bool inRange = false;
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer > shootingRange)
        {
            inRange = false;
        }
        else
        {
            inRange = true;
        }

        return inRange;
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
