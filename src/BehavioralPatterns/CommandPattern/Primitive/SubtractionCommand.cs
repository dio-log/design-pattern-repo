namespace DesignPatternSample.BehavioralPatterns.CommandPattern.Primitive;

public class SubtractionCommand : ICommand
{
    private Calculator _calculator;
    private double _operand;

    public SubtractionCommand(Calculator calculator, double operand)
    {
        _calculator = calculator;
        _operand = operand;
    }
    public void Execute()
    {
        _calculator.Subtract(_operand);
    }

    public void Undo()
    {
        _calculator.Add(_operand);
    }
}