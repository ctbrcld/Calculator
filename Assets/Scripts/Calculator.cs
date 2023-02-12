using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour

{
    public Text RequestField;
    public Text ResultField;
    private float _value1;
    private float _value2;
    private float _result;
    private bool _clear = true;
    private Operator _operator;

    private enum Operator
    {
        Addition,
        Substaction,
        Multiplication,
        Division,
        Minimal,
        Maximum,
        Power
    }

    public void AddDigit(int digit)
    {
        if (_clear)
        {
            ResultField.text = "";
            ResultField.text += digit;
            _clear = false;
        }
        else
        {
            ResultField.text += digit;
        }
    }

    public void RemoveDigit()
    {
        ResultField.text = ResultField.text.ToString().Remove(ResultField.text.ToString().Length - 1);
    }

    public void Clear()
    {
        ResultField.text = "0";
        RequestField.text = "";
        _clear = true;
    }

        public void Addition()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = _value1.ToString() + "+";
        ResultField.text = _value1.ToString();
        _clear = true;
        _operator = Operator.Addition;
    }

        public void Substaction()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = _value1.ToString() + "-";
        ResultField.text = _value1.ToString();
        _clear = true;
        _operator = Operator.Substaction;
    }  
        public void Multiplication()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = _value1.ToString() + "x";
        ResultField.text = _value1.ToString();
        _clear = true;
        _operator = Operator.Multiplication;
    }

        public void Division()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = _value1.ToString() + "÷";
        ResultField.text = _value1.ToString();
        _clear = true;
        _operator = Operator.Division;
    }

        public void Minimal()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = "Which one is lesser " + ResultField.text + " or";
        ResultField.text = _value1.ToString();
        _clear = true;
        _operator = Operator.Minimal;
    }
        public void Maximum()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = "Which one is greater " + ResultField.text + " or";
        ResultField.text = _value1.ToString();
        _clear = true;
        _operator = Operator.Maximum;
    }
 
        public void Power()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = ResultField.text + "^";
        ResultField.text = _value1.ToString();
        _clear = true;
        _operator = Operator.Power;
    }

    public void Equals()
    {
        _clear = true;
        switch (_operator)
        {
            case Operator.Addition:
                _value2 = float.Parse(ResultField.text);
                _result = _value1 + _value2;
                RequestField.text = _value1 + "+" + _value2 + "=";
                ResultField.text = _result.ToString("");
                break;
            case Operator.Substaction:
                _value2 = float.Parse(ResultField.text);
                _result = _value1 - _value2;
                RequestField.text = _value1 + "-" + _value2 + "=";
                ResultField.text = _result.ToString("");
                break;
            case Operator.Multiplication:
                _value2 = float.Parse(ResultField.text);
                _result = _value1 * _value2;
                RequestField.text = _value1 + "*" + _value2 + "=";
                ResultField.text = _result.ToString("");
                break;            
            case Operator.Division:
                if (ResultField.text == "0")
                {
                    RequestField.text = "You can't divide by 0";
                    _clear = true;
                }
                else
                {
                    _value2 = float.Parse(ResultField.text);
                    _result = _value1 / _value2;
                    RequestField.text = _value1 + "÷" + _value2 + "=";
                    ResultField.text = _result.ToString("");
                }
                break;
            case Operator.Minimal:
                _value2 = float.Parse(ResultField.text);
                _result = Mathf.Min(_value1, _value2);
                RequestField.text = _result + " is lesser";
                ResultField.text = "";
                _clear = true;
                break;            
            case Operator.Maximum:
                _value2 = float.Parse(ResultField.text);
                _result = Mathf.Max(_value1, _value2);
                RequestField.text = _result + " is greater";
                ResultField.text = "";
                _clear = true;
                break;
            case Operator.Power:
                _value2 = float.Parse(ResultField.text);
                _result = Mathf.Pow(_value1, _value2);
                RequestField.text = _value1 + "^" + _value2 + "=";
                ResultField.text = _result.ToString("");
                _clear = true;
                break;


        }

    }





}