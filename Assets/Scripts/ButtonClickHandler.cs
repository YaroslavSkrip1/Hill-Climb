using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private Button button;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite pressedSprite;

    private bool _isButtonPressed = false;

    private void Update()
    {
        if (_isButtonPressed && button.image != null && pressedSprite != null)
            button.image.sprite = pressedSprite;
        else if (!_isButtonPressed && button.image != null && normalSprite != null) 
            button.image.sprite = normalSprite;
    }
    
    private void MoveForward()
    {
        _isButtonPressed = true;
        carController.SetMovement(1f);
    }

    private void MoveBackward()
    { 
        _isButtonPressed = true;
        carController.SetMovement(-1f);
    }

    private void ResetMovement()
    {
        _isButtonPressed = false;
        button.image.sprite = normalSprite;
        carController.SetMovement(0f);
    }
}