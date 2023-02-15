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
        if (ResultField.text == "0")
        {
            ResultField.text = digit.ToString();
        }
        else if (_clear)
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
        if (ResultField.text == "")
        {
            _clear = true;
        }
        else
        {
            ResultField.text = ResultField.text.ToString().Remove(ResultField.text.ToString().Length - 1);
        }

    }

    public void Clear()
    {
        ResultField.text = "0";
        RequestField.text = "";
        _clear = false;
    }

    public void Comma()
    {
        var comma = ResultField.text.ToString().Substring(ResultField.text.ToString().Length - 1, 1);
        if (comma != ",")
        {
            ResultField.text += ",";
            _clear = false;
        }
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

    public void Sinus()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = "sin(" + _value1.ToString() + "㎭)=";
        ResultField.text = Mathf.Sin(_value1).ToString("");
        _value1 = Mathf.Sin(_value1);
        _clear = true;
    }
    public void Cotangent()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = "ctg(" + _value1.ToString() + "㎭)=";
        ResultField.text = (1 / Mathf.Tan(_value1)).ToString("");
        _value1 = Mathf.Sin(_value1);
        _clear = true;
    }

    public void Pi()
    {
        double pi = Mathf.PI;
        RequestField.text = "π=";
        ResultField.text = pi.ToString();
        _clear = true;
    }

    public void Log2()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = "log₂" + _value1.ToString() + "=";
        ResultField.text = Mathf.Log(_value1, 2).ToString("");
        _clear = true;
    }

    public void Log10()
    {
        _value1 = float.Parse(ResultField.text);
        RequestField.text = "log₁₀" + _value1.ToString() + "=";
        ResultField.text = Mathf.Log10(_value1).ToString("");
        _clear = true;
    }

    public void Factorize()
    {
        _value1 = float.Parse(ResultField.text);
        string s = string.Empty;
        int b, c, n;
        n = ((int)_value1);
        if (n < 2)
        {
            RequestField.text = "Wrong value!";
            _clear = true;
        }
        else
        {

            while ((n % 2) == 0)
            {
                n = n / 2;
                s += "2*";
            }
            b = 3; c = (int)Mathf.Sqrt(n) + 1;
            while (b < c)
            {
                if ((n % b) == 0)
                {
                    if (n / b * b - n == 0)
                    {
                        s += b.ToString() + "*";
                        n = n / b;
                        c = (int)Mathf.Sqrt(n) + 1;
                    }
                    else
                        b += 2;
                }
                else
                    b += 2;
            }
            s += n.ToString();
            RequestField.text = s;
            _clear = true;
        }
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