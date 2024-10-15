using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    
    Rigidbody rigid;
    Animator anim;

    public float moveSpeed = 3f;
    private float rotationSpeed;
    private Vector3 targetPoint;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        SetRandomTargetPoint();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
            gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        SetRandomTargetPoint(); // Ȱ��ȭ�� �� ��ǥ ��ġ ����
    }
    void SetRandomTargetPoint()
    {
        int ranNum = Random.Range(0, GameManager.instance.endPoint.Length);
        targetPoint = GameManager.instance.endPoint[ranNum].position;
    }
    void MovePlayer()
    {
        rotationSpeed = 5f;
        Vector3 direction = (targetPoint - rigid.position).normalized; // ��ǥ ����
        Vector3 movePos = direction * moveSpeed * Time.fixedDeltaTime; // �̵� �Ÿ�
        Quaternion lookAt = Quaternion.LookRotation(direction);

        if (Vector3.Distance(rigid.position, targetPoint) > 0.1f)
        {
            rigid.rotation = Quaternion.Slerp(rigid.rotation, lookAt, Time.fixedDeltaTime * rotationSpeed);
            rigid.MovePosition(rigid.position + movePos);
        }
        else
        {
            SetRandomTargetPoint(); // ��ǥ�� �����ϸ� �� ��ǥ ����
        }
    }
}
