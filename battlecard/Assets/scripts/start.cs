using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public GameObject p1, p2, p3;
    public GameObject enemy;

    public GameObject bulletp1, bulletp2, bulletp3, bulletenemy;

    private int count = 1;
    private bool hasAttacked = false;

    void Start()
    {
        StartCoroutine(AttackWithDelay());
    }

    IEnumerator AttackWithDelay()
    {
        while (true)
        {
            if (!hasAttacked)
            {
                if (count == 1)
                {
                    Attack(p1, enemy, bulletp1);
                }
                else if (count == 2)
                {
                    Attack(p2, enemy, bulletp2);
                }
                else if (count == 3)
                {
                    Attack(p3, enemy, bulletp3);
                }
                else if (count == 4)
                {
                    int randomAttack = Random.Range(1, 4); 
                    if (randomAttack == 1)
                    {
                        Attack(enemy, p1, bulletenemy);
                    }
                    else if (randomAttack == 2)
                    {
                        Attack(enemy, p2, bulletenemy);
                    }
                    else
                    {
                        Attack(enemy, p3, bulletenemy);
                    }
                    count = 0; 
                }
                count++;
                hasAttacked = true;
            }
            yield return new WaitForSeconds(2f);
            hasAttacked = false;
        }
    }

    void Attack(GameObject attacker, GameObject target, GameObject bulletPrefab)
    {
        // Tạo viên đạn tại vị trí của attacker
        GameObject bullet = Instantiate(bulletPrefab, attacker.transform.position, Quaternion.identity);
        Vector3 targetPosition = target.transform.position;
        Vector3 direction = (targetPosition - attacker.transform.position).normalized;
        StartCoroutine(MoveBullet(bullet.transform, direction, targetPosition));
    }

    IEnumerator MoveBullet(Transform bulletTransform, Vector3 direction, Vector3 targetPosition)
    {
        while (Vector3.Distance(bulletTransform.position, targetPosition) > 0.1f)
        {
            bulletTransform.position += direction * Time.deltaTime * 10;
            yield return null;
        }
        bulletTransform.position = targetPosition;
        Destroy(bulletTransform.gameObject);
    }
}
