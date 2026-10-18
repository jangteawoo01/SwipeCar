using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject car;
    public GameObject flag;
    public Text distance_Text;

    void Update()
    {
        // 깃발과 자동차 사이의 거리 구하기
        float lenght = flag.transform.position.x - car.transform.position.x;

        if (lenght >= 0) { 
        // Text에다가 표시 해주기
            distance_Text.text = "목표 지점까지 "+lenght.ToString("F3")+"m";
        }else
        {
            distance_Text.text = "Game Over";
        }

    }
}
