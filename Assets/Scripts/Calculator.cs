using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour

{
    [SerializeField] private InputField _inputField1;
    [SerializeField] private InputField _inputField2;
    [SerializeField] private InputField _resultField;

    private float GetValue1()
    {
        return float.Parse(_inputField1.text);
    }

    private float GetValue2()
    {
        return float.Parse(_inputField2.text);
    }

    public void Addition()
    {
        _resultField.text = (GetValue1() + GetValue2()).ToString();
    }
    
    public void Substraction()
    {
        _resultField.text = (GetValue1() - GetValue2()).ToString();
    }
        
    public void Multiply()
    {
        _resultField.text = (GetValue1() * GetValue2()).ToString();
    }
    
    public void Divide()
    {
        if (GetValue2() == 0)
        {
            _resultField.text = "Error: Can't divide by 0";
        }
        else
        {
            _resultField.text = (GetValue1() / GetValue2()).ToString();
        }
    }  
    
    public void FindMinimalValue()
    {
        if (GetValue1() < GetValue2())
        {
            _resultField.text = GetValue2().ToString();
        }
        else
        {
            _resultField.text = GetValue2().ToString();
        }
    }
     
    public void FindMaximumValue()
    {
        if (GetValue1() > GetValue2())
        {
            _resultField.text = GetValue1().ToString();
        }
        else
        {
            _resultField.text = GetValue2().ToString();
        }
    }
  
    public void Power()
    {
        _resultField.text = Mathf.Pow(GetValue1(), GetValue2()).ToString();
    }


}
