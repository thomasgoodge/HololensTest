using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour
{
    // Start is called before the first frame update

    //How to add key bindings for controller
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 0.8f;
    [SerializeField] float xRange = 0.4f;
    [SerializeField] float yRange = 0.3f;
    

    [SerializeField] float positionPitchFactor = 0f;
    [SerializeField] float controlPitchFactor = -60f;
    [SerializeField] float positionYawFactor = 60f;
    [SerializeField] float controlRollFactor = -60f;
  
    
    

    float xThrow, yThrow;
 
    void Update()
    {
        // float horizontalThrow = movement.ReadValue<Vector2>().x;
        // float verticalThrow = movement.ReadValue<Vector2>().y;

        ProcessTranslation();
        ProcessRotation();
        DebugCommands();
    }
    private void ProcessRotation()
    {
       
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
       
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    
    void NextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    void PreviousLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex - 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

      private void DebugCommands()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        else if (Input.GetKey(KeyCode.R))
        {
            ReloadLevel();
        }

        else if (Input.GetKey(KeyCode.Period))
        {
            NextLevel();
        }

        else if (Input.GetKey(KeyCode.Comma))
        {
            PreviousLevel();
        }
    }

}
