using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    [SerializeField] private GameObject[] attackPrefab;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;

    private GameObject bulletTarget;
    private float timer;
    [SerializeField] private EnemySeek seeker;
    public enum ShootMode
    {
        Closest,
        Strongest,
        Weakest//most hurt
    }
    [SerializeField] public ShootMode mode;
    [SerializeField] UnitHandler unitInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<EnemySeek>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case ShootMode.Closest:
                {
                    bulletTarget = seeker.FindClosestEnemy();
                    break;
                }
            case ShootMode.Strongest:
                {
                    bulletTarget = seeker.FindStrongestEnemy();
                    break;
                }
            case ShootMode.Weakest:
                {
                    bulletTarget = seeker.FindWeakestEnemy();
                    break;
                }
            default:
                {
                    bulletTarget = seeker.FindClosestEnemy();
                    break;
                }
        }
        switch (unitInfo.unitType)
        {
            case UnitHandler.UnitType.Ranger:
                {
                    Shoot();
                    break;
                }
            case UnitHandler.UnitType.Mage:
                {
                    ShootRaycast();
                    break;
                }
            case UnitHandler.UnitType.Warrior:
                {
                    ShootRaycastArea();
                    break;
                }
            default:
                {
                    Shoot();
                    break;
                }

        }
     
        
    }
    void Shoot()
    {
        if (bulletTarget != null)
        {


            if (bulletTarget.activeSelf)
            {


                timer += Time.deltaTime;
                if (timer > FindObjectOfType<UnitHandler>().fireRate)
                {

                    GameObject bullet = Instantiate(attackPrefab[0], bulletSpawnPoint.transform.position, Quaternion.identity, gameObject.transform);
                    Vector3 direction =bulletTarget.transform.position - bulletSpawnPoint.transform.position;
                    Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
                    bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
                    timer = 0;
                    Destroy(bullet, bulletLifeTime);

                }
            }
        }
    }

    void ShootRaycast()
    {
        if (bulletTarget != null)
        {

            if (bulletTarget.activeSelf)
            {
                timer += Time.deltaTime;
                if (timer > FindObjectOfType<UnitHandler>().fireRate)
                {
                    RaycastHit hit;
                    Vector3 direction = bulletTarget.transform.position - bulletSpawnPoint.transform.position;
                    Debug.DrawRay(bulletSpawnPoint.transform.position, direction);
                    if (Physics.Raycast(bulletSpawnPoint.transform.position, direction, out hit, 500))
                    {
                        if (hit.collider.gameObject == bulletTarget)
                        {

                            FindObjectOfType<UnitHandler>().EarnXP(hit.collider.gameObject.GetComponent<EnemyDestroyer>().TakeDamage(FindObjectOfType<UnitHandler>().dmg));
                            GameObject bullet = Instantiate(attackPrefab[1], bulletSpawnPoint.transform.position, Quaternion.identity);
                            bullet.transform.rotation = Quaternion.LookRotation(direction);
                            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
                            timer = 0;
                            Destroy(bullet, 0.1f);
                        }
                        else if (hit.collider.gameObject.tag == "Enemy")
                        {
                            FindObjectOfType<UnitHandler>().EarnXP(hit.collider.gameObject.GetComponent<EnemyDestroyer>().TakeDamage(FindObjectOfType<UnitHandler>().dmg));
                            GameObject bullet = Instantiate(attackPrefab[1], bulletSpawnPoint.transform.position, Quaternion.identity);
                            bullet.transform.rotation = Quaternion.LookRotation(direction);
                            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
                            timer = 0;
                            Destroy(bullet, 0.1f);
                        }
                    }
                }
            }
        }
    }

    void ShootRaycastArea()
    {
        if (bulletTarget != null)
        {

            if (bulletTarget.activeSelf)
            {
                timer += Time.deltaTime;
                if (timer > FindObjectOfType<UnitHandler>().fireRate)
                {
                    RaycastHit hit, hit2, hit3;
                    Vector3 direction = bulletTarget.transform.position - bulletSpawnPoint.transform.position;

                    if (Physics.Raycast(bulletSpawnPoint.transform.position, direction, out hit, 500))
                    {
                        if (hit.collider.gameObject == bulletTarget)
                        {
                            FindObjectOfType<UnitHandler>().EarnXP(hit.collider.gameObject.GetComponent<EnemyDestroyer>().TakeDamage(FindObjectOfType<UnitHandler>().dmg));
                            GameObject bullet = Instantiate(attackPrefab[2], bulletSpawnPoint.transform.position, Quaternion.identity, gameObject.transform);
                            bullet.transform.rotation = Quaternion.LookRotation(direction);
                            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
                            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);

                            timer = 0;
                            Destroy(bullet, 1f);
                        }
                        else if (hit.collider.gameObject.tag == "Enemy")
                        {
                            FindObjectOfType<UnitHandler>().EarnXP(hit.collider.gameObject.GetComponent<EnemyDestroyer>().TakeDamage(FindObjectOfType<UnitHandler>().dmg));
                            GameObject bullet = Instantiate(attackPrefab[2], bulletSpawnPoint.transform.position, Quaternion.identity, gameObject.transform);
                            bullet.transform.rotation = Quaternion.LookRotation(direction);
                            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
                            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);

                            timer = 0;
                            Destroy(bullet, 1f);
                        }
                    }
                    if (Physics.Raycast(bulletSpawnPoint.transform.position, direction, out hit2, 500))
                    {
                        if (hit2.collider.gameObject == bulletTarget)
                        {
                            FindObjectOfType<UnitHandler>().EarnXP(hit.collider.gameObject.GetComponent<EnemyDestroyer>().TakeDamage(FindObjectOfType<UnitHandler>().dmg));
                            GameObject bullet = Instantiate(attackPrefab[2], bulletSpawnPoint.transform.position, Quaternion.identity, gameObject.transform);
                            bullet.transform.rotation = Quaternion.Euler(direction.x, direction.y, direction.z * -20);
                            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
                            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);

                            timer = 0;
                            Destroy(bullet, 1f);
                        }
                        else if (hit2.collider.gameObject.tag == "Enemy")
                        {
                            FindObjectOfType<UnitHandler>().EarnXP(hit.collider.gameObject.GetComponent<EnemyDestroyer>().TakeDamage(FindObjectOfType<UnitHandler>().dmg));
                            GameObject bullet = Instantiate(attackPrefab[2], bulletSpawnPoint.transform.position, Quaternion.identity, gameObject.transform);
                            bullet.transform.rotation = Quaternion.Euler(direction.x, direction.y, direction.z * -20);
                            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
                            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);

                            timer = 0;
                            Destroy(bullet, 1f);
                        }
                    }
                    if (Physics.Raycast(bulletSpawnPoint.transform.position, direction, out hit3, 500))
                    {
                        if (hit3.collider.gameObject == bulletTarget)
                        {
                            FindObjectOfType<UnitHandler>().EarnXP(hit.collider.gameObject.GetComponent<EnemyDestroyer>().TakeDamage(FindObjectOfType<UnitHandler>().dmg));
                            GameObject bullet = Instantiate(attackPrefab[2], bulletSpawnPoint.transform.position, Quaternion.identity, gameObject.transform);
                            bullet.transform.rotation = Quaternion.Euler(direction.x, direction.y, direction.z * 20);
                            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
                            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
                            timer = 0;
                            Destroy(bullet, 1f);
                        }
                        else if (hit3.collider.gameObject.tag == "Enemy")
                        {
                            FindObjectOfType<UnitHandler>().EarnXP(hit.collider.gameObject.GetComponent<EnemyDestroyer>().TakeDamage(FindObjectOfType<UnitHandler>().dmg));
                            GameObject bullet = Instantiate(attackPrefab[2], bulletSpawnPoint.transform.position, Quaternion.identity, gameObject.transform);
                            bullet.transform.rotation = Quaternion.Euler(direction.x, direction.y, direction.z * 20);
                            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
                            bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
                            timer = 0;
                            Destroy(bullet, 1f);
                        }
                    }
                }
            }
        }
    }
}
