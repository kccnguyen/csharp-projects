using Calculator.ViewModels;
using System.Diagnostics.Metrics;

namespace Calculator;

public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        OnClear(this, null);

    }

    string currentEntry = "";
    int currentState = 1;
    string mathOperator;
    double firstNumber, secondNumber;
    string decimalFormat = "N0";



    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;

        var resultText = this.resultText.Text.Trim();
        if (resultText.Length <= 1 && resultText == "0")
        {
            this.resultText.Text = "";
        }

        var EndText = this.resultText.Text.Length > 0
            ? this.resultText.Text[^1].ToString()
            : string.Empty; 
        var isNumeric = int.TryParse(EndText, out int num);
        var _pressed = isNumeric ? pressed : " " + pressed;
      
        this.resultText.Text += _pressed;
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;

        var resultText = this.resultText.Text.Trim();
        if(resultText.Length <= 1 && resultText =="0")
        {
            this.resultText.Text = "";
        }
        this.resultText.Text += string.IsNullOrEmpty(this.resultText.Text) ? pressed : " " + pressed;
    }


    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        decimalFormat = "N0";
        this.resultText.Text = "0";
        currentEntry = string.Empty;
    }

    void OnCalculate(object sender, EventArgs e)
    {
        double? result = Calculator.Calculate2(this.resultText.Text);
            if (result !=null)
        {
            this.CurrentCalculation.Text = this.resultText.Text;
            this.resultText.Text = result?.ToTrimmedString(decimalFormat);
        }
        
    }

    void OnNegative(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            secondNumber = -1;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

    void OnPercentage(object sender, EventArgs e)
    {
        double? result = Calculator.Calculate2(this.resultText.Text);
        if (result!=null)
        {
            var x = result + " * 0.01";
            result = Calculator.Calculate2(x);
            this.CurrentCalculation.Text = result?.ToString();
            this.resultText.Text = result?.ToTrimmedString(decimalFormat);
        }
    }
    void OnSqRoot(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            resultText.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(resultText.Text)));
        }
    }
}
