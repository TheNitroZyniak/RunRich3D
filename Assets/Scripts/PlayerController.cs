using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerController : MonoBehaviour{

    [SerializeField] private Camera mainCamera;
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator anim;
    [SerializeField] GameObject[] models;

    [SerializeField] GameObject particles, red;

    public float moveSpeed = 5f;
    private bool isMoving = false;

    private IPlayerState currentState;

    bool gameStarted;

    public void SetState(IPlayerState state) {
        if (currentState != null)
            currentState.ExitState(this);

        currentState = state;
        currentState.EnterState(this);
    }

    private void Start() {
        SetState(new IdleState());
    }

    void Update() {
        Move();
    }

    private void Move() {
        if (Input.GetMouseButtonDown(0)) {
            isMoving = true;
            if (!gameStarted) {
                CoinsManager.instance.AddCoins(0);
                UIManager.instance.DeactivateTutor();
                SetState(new MiddleState());
                gameStarted = true;
            }
        }
        else if (Input.GetMouseButtonUp(0)) isMoving = false;

        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0f;
        forward.Normalize();
        Vector3 desiredDirection = forward * moveSpeed;
        if (isMoving) {
            Vector3 right = mainCamera.transform.right;
            right.y = 0f;

            right.Normalize();
            float mouseInputX = Input.GetAxis("Mouse X");
            desiredDirection = desiredDirection + (right * mouseInputX * 20);

        }
        desiredDirection.Normalize();
        characterController.Move(desiredDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("TurnRight")) 
            StartCoroutine (RotateOverTime(true));
        else if (other.CompareTag("TurnLeft")) {
            StartCoroutine(RotateOverTime(false));
        }


        if (other.CompareTag("Coin")) {
            CoinsManager.instance.AddCoins(2);
            Instantiate(particles, other.transform.position, Quaternion.identity);

            CheckChangeState();
        }
        else if (other.CompareTag("Good")) {
            CoinsManager.instance.AddCoins(20);
            CheckChangeState();
        } else if (other.CompareTag("Bad")) {
            CoinsManager.instance.SubtractCoins(20);
            CheckChangeState();
        } else if (other.CompareTag("Alcohol")) {
            CoinsManager.instance.SubtractCoins(20);
            Instantiate(red, other.transform.position, Quaternion.identity);
            CheckChangeState();
        } 
        else if (other.CompareTag("Finish")) {
            SetState(new VictoryState());
        }

        other.gameObject.SetActive(false);
    }

    public void SetModel(int modelToActivate) {
        for(int i = 0; i < models.Length; i++) models[i].SetActive(false);
        models[modelToActivate].SetActive(true);
    }

    public void SetAnimation(string newAnimation) {
        anim.SetTrigger(newAnimation);
    }

    public void SetSpeed(float newSpeed) {
        moveSpeed = newSpeed;
    }


    void CheckChangeState() {
        IPlayerState newState;
        int coins = CoinsManager.instance.coins;
        if (coins <= 0) newState = new LoseState();   
        else if (coins > 0 && coins <= 30) newState = new PoorState();
        else if (coins > 30 && coins < 70) newState = new MiddleState();
        else newState = new BuisnessState();

        if (newState.ToString() != currentState.ToString()) 
            SetState(newState);
            
    }

    IEnumerator RotateOverTime(bool right) {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        Quaternion targetRotation;
        if(right)
            targetRotation = startRotation * Quaternion.Euler(0f, 90f, 0f);
        else
            targetRotation = startRotation * Quaternion.Euler(0f, -90f, 0f);

        while (elapsedTime < 2f){
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
    }
}
