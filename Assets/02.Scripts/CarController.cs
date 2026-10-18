using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    float moveSpeed = 0f;
    float moveSpeedDeceleration = 0.998f;
    Vector2 startPos;
    bool isClicked = false;

    void Update()
    {
        // 키보드 R키의 입력 감지
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            /*
            // 자동차의 속도 값을 0으로 변경
            moveSpeed = 0f;

            // 자동차의 위치를 시작지점으로 이동
            transform.position = new Vector3(-7f, -3.7f, 0f);

            isClicked = false;
            */
        }
        if(isClicked.Equals(false)) { 
            if (Input.GetMouseButtonDown(0))
            {
                // 마우스 시작 지점의 좌표 값
                startPos = Input.mousePosition;
            } else if (Input.GetMouseButtonUp(0))
            {
                // 마우스 버튼에서 손가락을 떼었을 때 좌표
                Vector2 endPos = Input.mousePosition;

                // 스와이프 된 거리를 구한다
                float swipeLength = Mathf.Abs(endPos.x - startPos.x);
                
                // 스와이프 길이를 처음 속도로 변경한다 500을 나누는 이유는, 그냥 거리 상태면 값이 너무 커서 차가 너무 빨리 움직이기 때문에
                moveSpeed = swipeLength / 500.0f;

                //효과음을 재생한다
                GetComponent<AudioSource>().Play();
                isClicked = true;

            }
        }
        if (isClicked) { 
            // 이동
            transform.Translate(moveSpeed, 0, 0);
            Debug.Log(transform.position.x);
            if (transform.position.x >= 0)
            {
                // 감속
                moveSpeedDeceleration = 0.9998f;
                Debug.Log(moveSpeedDeceleration);
            }
            else
            {
                // 감속
                moveSpeedDeceleration = 0.97f;
                Debug.Log(moveSpeedDeceleration);

            }
            moveSpeed *= moveSpeedDeceleration;

        }

    }
}
