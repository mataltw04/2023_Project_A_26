using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//제너릭 형식으로 class생성
public class GenericContainerExample : MonoBehaviour
{
    private GenericContainer<int> intContainer;                         //컨테이너 선언
    private GenericContainer<string> stringContainer;

    void Start()
    {
        intContainer = new GenericContainer<int>(10);                   //10칸으로 설정
        stringContainer = new GenericContainer<string>(5);              //5칸으로 설정
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))                            //키보드1을 누르면
        {       
            intContainer.Add(Random.Range(0, 100));                     //0-100중 랜덤숫자를 컨테이너에 넣는다.
            DisplayContainerItems(intContainer);                        //함수를 통해서 Debug.Log에 보여준다
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))                           //키보드2을 누르면
        {       
            string randomString = "Item" + Random.Range(0, 100);        //임의의 문자열을 만들어준다.
            stringContainer.Add(randomString);                          //0-100중 랜덤 문자열 컨테이너에 넣는다
            DisplayContainerItems(stringContainer);                     //함수를 통해서 Debug.log에 보여준다
        }
    }
    //컨테이너에 담긴 값들을 보여주는 함수
    private void DisplayContainerItems<T>(GenericContainer<T> container)
    {
        T[] item = container.GetItems();                                //아이템 리스트를 받아온다.
        string temp = "";                                               //Debug.Log에 보여질 칸 String
        for(int i = 0; i < item.Length; i++)                            //컨테이너의 모든 값을 for문으로 돌면서
        {
            if(item[i] !=null)                                          //값이 NULL이 아닐 경우
            {
                temp += item[i].ToString() + "/";
            }
            else
            {
                temp += "Empty /";
            }
        }
        Debug.Log(temp);
    }

}
