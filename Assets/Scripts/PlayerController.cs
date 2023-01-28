using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Vector3 startPos;
  Vector3 targetPos;

  // Animator anim;

  // private void Start()
  // {
  //   anim = GetComponent<Animator>();
  // }

  bool isMoving = false;
  float moveTime = 0.2f;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
    {
      StartCoroutine(move());
    }
  }

  IEnumerator move()
  {
    isMoving = true;

    startPos = transform.position;
    targetPos = transform.position + Vector3.forward;

    float elapsedTime = 0f;

    while (elapsedTime < moveTime)
    {
      transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / moveTime);
      elapsedTime += Time.deltaTime;
      yield return null;
    }

    transform.position = targetPos;

    isMoving = false;
  }
}
