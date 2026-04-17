using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public enum InputType { Keyboard, Gyroscope, Joystick }
    public InputType inputType = InputType.Keyboard;

    void Awake()
    {
        instance = this;
        AutoDetectPlatform();
    }

    void AutoDetectPlatform()
    {
#if UNITY_ANDROID || UNITY_IOS
            if (SystemInfo.supportsGyroscope)
            {
                inputType = InputType.Gyroscope;
                Input.gyro.enabled = true;
            }
#elif UNITY_GAMEPAD
            inputType = InputType.Joystick;
#else
        inputType = InputType.Keyboard;
#endif
    }

    public float GetHorizontalInput()
    {
        switch (inputType)
        {
            case InputType.Gyroscope:
                return Input.gyro.gravity.x;
            case InputType.Joystick:
                return Input.GetAxis("Horizontal");
            default:
                return Input.GetAxis("Horizontal");
        }
    }
}