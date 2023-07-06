using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    #region Variables to use: 

    // Private non-visible variables:
    private Vector2 playerInput;
    private bool isMoving;

    [Header("Player Movement Attributes: ")]
    public float movementSpeed;
 
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Not used at the moment. 
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement(); 
    }

    #region Methods in use: 

    private void CheckMovement()
    {
        if (isMoving != true)
        {
            playerInput.x = Input.GetAxisRaw("Horizontal");
            playerInput.y = Input.GetAxisRaw("Vertical");

            if (playerInput != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += playerInput.x;
                targetPos.y += playerInput.y;

                StartCoroutine(MoveCharacter(targetPos));
            }
        }
    }

    private IEnumerator MoveCharacter(Vector3 targetPos)
    {
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    #endregion
}
