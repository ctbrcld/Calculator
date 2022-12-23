using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour

{
    public InputField InputField1;
    public InputField InputField2;
    public InputField ResultField;
    private float Value1;
    private float Value2;
    private float Result;

    public void Add()
    {
        ResultField.text = (float.Parse(InputField1.text) + float.Parse(InputField2.text)).ToString();
    }
    
    public void Substract()
    {
        ResultField.text = (float.Parse(InputField1.text) - float.Parse(InputField2.text)).ToString();
    }
        
    public void Multiply()
    {
        ResultField.text = (float.Parse(InputField1.text) * float.Parse(InputField2.text)).ToString();
    }
    
    public void Divide()
    {
        if (float.Parse(InputField2.text) == 0)
        {
            ResultField.text = "Error";
        }
        else
        {
            ResultField.text = (float.Parse(InputField1.text) / float.Parse(InputField2.text)).ToString();
        }
    }  
    
    public void Min()
    {
        if (float.Parse(InputField1.text) < (float.Parse(InputField2.text)))
        {
            ResultField.text = float.Parse(InputField1.text).ToString();
        }

        else
        {
            ResultField.text = float.Parse(InputField2.text).ToString();
        }
    }
     
    public void Max()
    {
        if (float.Parse(InputField1.text) > (float.Parse(InputField2.text)))
        {
            ResultField.text = float.Parse(InputField1.text).ToString();
        }

        else
        {
            ResultField.text = float.Parse(InputField2.text).ToString();
        }
    }

       
    public void Exp()
    {
        ResultField.text = Mathf.Pow(float.Parse(InputField1.text), float.Parse(InputField2.text)).ToString();
    }


}
