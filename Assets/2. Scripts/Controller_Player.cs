using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_Player : MonoBehaviour
{
    #region Variables to use: 

    // Private non-visible variables: 
    private Vector2 movementInput;
    private Rigidbody2D playerRb;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    [Header("Player Attributes: ")]
    public float movementSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
  
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Not used at the moment. 
    }

    // Fixed Update is called rigth before the Update
    void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.y, 0));
                }
            }
        }
    }

    #region Methods in use: 

    private bool TryMove(Vector2 direction)
    {
        int count = playerRb.Cast(
                direction,
                movementFilter,
                castCollisions,
                movementSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            playerRb.MovePosition(playerRb.position + direction * movementSpeed * Time.fixedDeltaTime);

            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    #endregion
}
