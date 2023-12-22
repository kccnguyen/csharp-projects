using System.Linq.Expressions;
namespace Calculator;


public static class Calculator
{
    public static double Calculate(double value1, double value2, string mathOperator)
    {
        double result = 0;

        switch (mathOperator)
        {
            case "÷":
                result = value1 / value2;
                break;
            case "×":
                result = value1 * value2;
                break;
            case "+":
                result = value1 + value2;
                break;
            case "-":
                result = value1 - value2;
                break;
            case "mod":
                result = value1 % value2;
                break;
        }

        return result;
    }

    public static double? Calculate2(string text)
    {
        var x = text.Replace("mod", "%").Replace('x', '*').Replace('÷', '/');
        System.Data.DataTable table = new System.Data.DataTable();
        table.Columns.Add("x", string.Empty.GetType(), x);    
        System.Data.DataRow row = table.NewRow();
        table.Rows.Add(row);
        return double.Parse((string)row["x"]);
    }
}

public static class DoubleExtensions
{
    public static string ToTrimmedString(this double target, string decimalFormat)
    {
        string strValue = target.ToString(decimalFormat); //Get the stock string

        //If there is a decimal point present
        if (strValue.Contains("."))
        {
            //Remove all trailing zeros
            strValue = strValue.TrimEnd('0');

            //If all we are left with is a decimal point
            if (strValue.EndsWith(".")) //then remove it
                strValue = strValue.TrimEnd('.');
        }

        return strValue;
    }
}

