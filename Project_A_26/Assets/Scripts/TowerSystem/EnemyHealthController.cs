using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int totalHeath;                  //ü�� ����
    public int moneyOnDeath = 50;

    public void TakeDamage(int damageAmount)    //�������� �޴� �Լ�
    {
        totalHeath -= damageAmount;
        print(totalHeath);
        if (totalHeath <=0)
        {
            totalHeath = 0;
            Destroy(gameObject);
            //�̱������� ���� �÷��ִ� ó�� �Լ�
            //���� ���� ó������ ���⼭ ���ش�.
        }
    }
}
