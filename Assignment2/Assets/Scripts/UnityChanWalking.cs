using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanWalking : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;

    private bool isWandering = false;
    private bool isRotRight = false;
    private bool isRotLeft = false;
    private bool isWalking = false;

    private Vector3 rotAxis = new Vector3(0,1,0);

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false) {
            StartCoroutine(Wander());
        }
        if (isRotRight == true) {
            transform.Rotate(rotAxis, Time.deltaTime * rotSpeed);
        }
        if (isRotLeft == true) {
            transform.Rotate(rotAxis, Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true) {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

        }
    }

    private IEnumerator Wander() {
        int rotTime = Random.Range(1,3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1,2);
        int walkWait = Random.Range(1,2);
        int walkTime = Random.Range(1,3);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1) {
            isRotRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotRight = false;
        } else {
            isRotLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotLeft = false;
        }
        isWandering = false;
    }
}
