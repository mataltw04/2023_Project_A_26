using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    private Tower thisTower;                    //Ÿ�� ���۳�Ʈ�� �ִ� ������Ʈ 

    public GameObject projectile;               //�߻�ü ����
    public Transform firePoint;                 //�߻� ��ġ ����
    public float timeBetweenShots = 1f;         //�߻� ����
    private float shotCounter;                  //�ð� ����

    private Transform target;                   //��ǥ Ÿ�� ����
    public Transform launcherModel;             //�� ȸ�� ��Ű�����ؼ� 

    // Start is called before the first frame update
    void Start()
    {
        thisTower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }

        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0 && target != null)
        {
            shotCounter = thisTower.fireRate;               //������Ʈ�� Tower ���۳�Ʈ���� ������ FireRate���� �ð��� �����ͼ� �Է�
            firePoint.LookAt(target);                       //�Ѿ� �߻�� Target�� �ٶ󺻴�.
            Instantiate(projectile, firePoint.position, firePoint.rotation);    //�Ѿ��� �����Ѵ�. 
        }

        if (thisTower.enemiesUpdate)         //���� �迭 LIst�� ����������
        {
            if (thisTower.enemiesInRange.Count > 0)
            {
                float minDistance = thisTower.range + 1;

                foreach (EnemyController enemy in thisTower.enemiesInRange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);

                        if (distance < minDistance)
                        {
                            minDistance = distance; //���� ����� �Ÿ��� ���� 
                            target = enemy.transform;
                        }
                    }
                }

            }
            else
            {
                target = null;
            }
        }
    }
}