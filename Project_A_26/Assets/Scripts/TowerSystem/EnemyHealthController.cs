using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int totalHeath;                  //체력 설정
    public int moneyOnDeath = 50;

    public void TakeDamage(int damageAmount)    //데미지를 받는 함수
    {
        totalHeath -= damageAmount;
        print(totalHeath);
        if (totalHeath <=0)
        {
            totalHeath = 0;
            Destroy(gameObject);
            //싱글톤으로 돈을 올려주는 처리 함수
            //죽은 이후 처리들을 여기서 해준다.
        }
    }
}
