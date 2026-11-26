using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManagerScript : MonoBehaviour
{
    [Header("Player GAme object")]
    [SerializeField] private Transform character;

    [Header("Game Parameters")]
    [SerializeField] private float moveDuration = 0.2f;

    enum GameStates
    {
        Ready,
        Moving,
        Dead
    }

    private GameStates gameState;
    private Vector2Int characterPos;

    void Awake()
    {
        NewLevel();
    }

    private void NewLevel()
    {
        //Setting the charcter ready to move
        gameState = GameStates.Ready;

        //Reset character position
        characterPos = new Vector2Int(0, -1);
        character.position = new Vector3(0, 0.2f, -1);
    }

    private bool InStartArea(Vector2Int location)
    {
        //Movement anywhere in the starting region is allowed
        if((location.y > -5) && (location.y < 0) && (location.y > -6) && (location.y > 6))
        {
            return true;
        }
        return false;
    }

    private IEnumerator MoveCharacter()
    {
        gameState = GameStates.Moving;
        float elapsedTime = 0f;

        //The yHeight changes if the player is on grass or the road
        float yHeight = 0.2f;

        Vector3 startPos = character.position;
        Vector3 endPos = new(characterPos.x, yHeight, characterPos.y);

        while (elapsedTime < moveDuration)
        {
            //How far through the animation are we
            float percent = elapsedTime / moveDuration;

            //Update the character position
            //Lerp stands for Linear interpolation
            Vector3 newPos = Vector3.Lerp(startPos, endPos, percent);
            character.position = newPos;

            //Update the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        //Ensure we're at the end
        character.position = endPos;

        //Need to check we're still moving at the enbd
        //If we're dead we don't want to go back to ready
        if(gameState == GameStates.Moving)
        {
            gameState = GameStates.Ready;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameStates.Ready)
        {
            Vector2Int moveDirection = Vector2Int.zero;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                //Converts the screen coordiantes to Unitys world coordinates
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                /*if (touchPos.y > 0)
                {
                    //Moves character forwards
                    character.localRotation = Quaternion.identity;
                    moveDirection.y = 1;
                }
                else if(touchPos.y < 0)
                {
                    //Moves character back
                    character.localRotation = Quaternion.Euler(0, 180, 0);
                    moveDirection.y = -1;
                }
                else if (touchPos.x < 0)
                {
                    //Moves character left
                    character.localRotation = Quaternion.Euler(0, -90, 0);
                    moveDirection.x = -1;
                }
                else if( touchPos.x > 0)
                {
                    //Moves character right
                    character.localRotation = Quaternion.Euler(0, 90, 0);
                    moveDirection.x = 1;
                }*/
            }

            //Single if/else don't want to move disgonally
            /*if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            {
                //Moves character forwards
                character.localRotation = Quaternion.identity;
                moveDirection.y = 1;
            }
            else if(Keyboard.current.downArrowKey.wasPressedThisFrame)
            {
                //Moves character back
                character.localRotation = Quaternion.Euler(0, 180, 0);
                moveDirection.y = -1;
            }
            else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
            {
                //Moves character left
                character.localRotation = Quaternion.Euler(0, -90, 0);
                moveDirection.x = -1;
            }
            else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            {
                //Moves character right
                character.localRotation = Quaternion.Euler(0, 90, 0);
                moveDirection.x = 1;
            }*/

            //Users movement code
            if(moveDirection != Vector2Int.zero)
            {
                Vector2Int destination = characterPos + moveDirection;

                //Giving the player the ability to move anywhere in the starting area
                if(InStartArea(destination))
                {
                    //Update the charcter to grid coordinates
                    characterPos = destination;

                    //Call coroutine to move the character object
                    StartCoroutine(MoveCharacter());
                }
            }
        }
    }

    public void MoveForward()
    {
        Vector2Int moveDirection = Vector2Int.zero;

        //Moves character forwards
        character.localRotation = Quaternion.identity;
        moveDirection.y = 1;
    }

    public void MoveDown()
    {
        Vector2Int moveDirection = Vector2Int.zero;

        //Moves character back
        character.localRotation = Quaternion.Euler(0, 180, 0);
        moveDirection.y = -1;
    }

    public void MoveLeft()
    {
        Vector2Int moveDirection = Vector2Int.zero;

        //Moves character left
        character.localRotation = Quaternion.Euler(0, -90, 0);
        moveDirection.x = -1;
    }

    public void MoveRight()
    {
        Vector2Int moveDirection = Vector2Int.zero;

        //Moves character right
        character.localRotation = Quaternion.Euler(0, 90, 0);
        moveDirection.x = 1;
    }
}
