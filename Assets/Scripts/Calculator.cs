using UnityEngine;
using UnityEngine.UI;

public partial class Calculator : MonoBehaviour

{
    private const string DefaultValue = "0";
    private const string CommaValue = ",";

    [SerializeField] private Text _requestField;
    [SerializeField] private Text _resultField;

    private float _value1;
    private float _value2;
    private float _result;
    private Operator _operator;
    private bool _clearField = true;


    public void AddDigit(int digit)
    {
        if (_resultField.text == DefaultValue)
        {
            _resultField.text = digit.ToString();
            return;
        }

        if (_clearField)
        {
            _resultField.text = string.Empty;
            _resultField.text += digit;
            _clearField = false;
        }
        else
        {
            _resultField.text += digit;
        }
    }

    public void RemoveDigit()
    {
        if (_resultField.text == string.Empty)
        {
            _clearField = true;
        }
        else
        {
            _resultField.text = _resultField.text.Remove(_resultField.text.Length - 1);
        }

    }

    public void Clear()
    {
        _resultField.text = DefaultValue;
        _requestField.text = string.Empty;
        _clearField = false;
    }

    public void Comma()
    {
        var comma = _resultField.text.Substring(_resultField.text.Length - 1, 1);
        if (comma != CommaValue)
        {
            _resultField.text += CommaValue;
            _clearField = false;
        }
    }

    public void Addition()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = _value1 + "+";
        _resultField.text = _value1.ToString();
        _clearField = true;
        _operator = Operator.Addition;
    }

    public void Substaction()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = _value1 + "-";
        _resultField.text = _value1.ToString();
        _clearField = true;
        _operator = Operator.Substaction;
    }
    public void Multiplication()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = _value1 + "x";
        _resultField.text = _value1.ToString();
        _clearField = true;
        _operator = Operator.Multiplication;
    }

    public void Division()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = _value1 + "÷";
        _resultField.text = _value1.ToString();
        _clearField = true;
        _operator = Operator.Division;
    }

    public void Minimal()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = "Which one is lesser " + _resultField.text + " or";
        _resultField.text = _value1.ToString();
        _clearField = true;
        _operator = Operator.Minimal;
    }
    public void Maximum()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = "Which one is greater " + _resultField.text + " or";
        _resultField.text = _value1.ToString();
        _clearField = true;
        _operator = Operator.Maximum;
    }

    public void Power()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = _resultField.text + "^";
        _resultField.text = _value1.ToString();
        _clearField = true;
        _operator = Operator.Power;
    }

    public void Sinus()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = "sin(" + _value1 + "㎭)=";
        _resultField.text = Mathf.Sin(_value1).ToString();
        _clearField = true;
    }
    public void Cotangent()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = "ctg(" + _value1 + "㎭)=";
        _resultField.text = (1 / Mathf.Tan(_value1)).ToString();
        _clearField = true;
    }

    public void Pi()
    {
        double pi = Mathf.PI;
        _requestField.text = "π=";
        _resultField.text = pi.ToString();
        _clearField = true;
    }

    public void Log2()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = "log₂" + _value1 + "=";
        _resultField.text = Mathf.Log(_value1, 2).ToString();
        _clearField = true;
    }

    public void Log10()
    {
        _value1 = float.Parse(_resultField.text);
        _requestField.text = "log₁₀" + _value1 + "=";
        _resultField.text = Mathf.Log10(_value1).ToString();
        _clearField = true;
    }

    public void Factorize()
    {
        _value1 = float.Parse(_resultField.text);
        int n = (int)_value1;
        if (n < 2)
        {
            _requestField.text = "Wrong value!";
            _clearField = true;
            return;
        }

        string s = string.Empty;
        while (n % 2 == 0)
        {
            n /= 2;
            s += "2*";
        }

        int b = 3;
        int c = (int)Mathf.Sqrt(n) + 1;
        while (b < c)
        {
            if (n % b != 0)
            {
                b += 2;
                continue;
            }

            if (n / b * b - n == 0)
            {
                s += b + "*";
                n /= b;
                c = (int)Mathf.Sqrt(n) + 1;
            }

            else
            {
                b += 2;
            }
        }

        s += n;
        _requestField.text = s;
        _clearField = true;
    }

    public void Equals()
    {
        _clearField = true;
        switch (_operator)
        {
            case Operator.Addition:
                _value2 = float.Parse(_resultField.text);
                _result = _value1 + _value2;
                _requestField.text = _value1 + "+" + _value2 + "=";
                _resultField.text = _result.ToString();
                break;
            case Operator.Substaction:
                _value2 = float.Parse(_resultField.text);
                _result = _value1 - _value2;
                _requestField.text = _value1 + "-" + _value2 + "=";
                _resultField.text = _result.ToString();
                break;
            case Operator.Multiplication:
                _value2 = float.Parse(_resultField.text);
                _result = _value1 * _value2;
                _requestField.text = _value1 + "*" + _value2 + "=";
                _resultField.text = _result.ToString();
                break;
            case Operator.Division:
                if (_resultField.text == DefaultValue)
                {
                    _requestField.text = "You can't divide by " + DefaultValue;
                    _clearField = true;
                }
                else
                {
                    _value2 = float.Parse(_resultField.text);
                    _result = _value1 / _value2;
                    _requestField.text = _value1 + "÷" + _value2 + "=";
                    _resultField.text = _result.ToString();
                }
                break;
            case Operator.Minimal:
                _value2 = float.Parse(_resultField.text);
                _result = Mathf.Min(_value1, _value2);
                _requestField.text = _result + " is lesser";
                _resultField.text = string.Empty;
                _clearField = true;
                break;
            case Operator.Maximum:
                _value2 = float.Parse(_resultField.text);
                _result = Mathf.Max(_value1, _value2);
                _requestField.text = _result + " is greater";
                _resultField.text = string.Empty;
                _clearField = true;
                break;
            case Operator.Power:
                _value2 = float.Parse(_resultField.text);
                _result = Mathf.Pow(_value1, _value2);
                _requestField.text = _value1 + "^" + _value2 + "=";
                _resultField.text = _result.ToString("");
                _clearField = true;
                break;


        }

    }





}