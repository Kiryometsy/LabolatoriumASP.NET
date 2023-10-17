using Labolatorium2.Controllers;
public class Calculator
{
    public Operators? Operator { get; set; }
    public double? x { get; set; }
    public double? y { get; set; }

    public String Op
    {
        get
        {
            switch (Operator)
            {
                case Operators.ADD:
                    return "+";
                case Operators.SUB:
                    return "-";
                case Operators.MUL:
                    return "*";
                case Operators.DIV:
                    return "/";
            default:
                    return "Error";
            }
        }
    }

    public bool IsValid()
    {
        return Operator != null && x != null && y != null;
    }

    public double Calculate()
    {
        switch (Operator)
        {
            case Operators.ADD:
                return (double)(x + y);
            case Operators.SUB:
                return (double)(x - y);
            case Operators.MUL:
                return (double)(x * y);
            case Operators.DIV:
                return (double)(x / y);
        default: return double.NaN;
        }
    }
}

