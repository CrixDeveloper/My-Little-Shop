using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_Player : MonoBehaviour
{
    #region Variables to use: 

    // Private non-visible variables: 
    private Vector2 movementInput;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    [Header("Player Attributes: ")]
    public float movementSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
  
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Getting components to avoid making all player's variables public: 

        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Not used at the moment. 
    }

    // Fixed Update is called rigth before the Update
    void FixedUpdate()
    {
        PlayerMovementChecking();
    }

    #region Methods in use: 

    private void PlayerMovementChecking()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success && movementInput.x > 0)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
            }
            //------------------------------------------------------ We want to avoid with this checking if there is a place to go, if is not then the player should not attempt moving. 
            if (!success && movementInput.y > 0)
            {
                success = TryMove(new Vector2(0, movementInput.y));
            }

            playerAnimator.SetBool("isMoving", success);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }

        // We need to change between normal walking and side walking:
        
        if (movementInput.x > 0 || movementInput.x < 0)
        {
            playerAnimator.SetBool("isSideWalking", true);
        }
        else if (movementInput.x == 0)
        {
            playerAnimator.SetBool("isSideWalking", false);
        }
    }

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
