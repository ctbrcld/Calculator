using UnityEngine;
public class DigitButton : MonoBehaviour
{
    private enum DigitType
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9
    }

    [SerializeField] private DigitType _digit;
    [SerializeField] private Calculator _calculator;
    public void Click()
    {
        _calculator.AddDigit((int)_digit);
    }
}