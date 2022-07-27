namespace Core.Calculator
{
    public enum StateEnum
    {
        PreOperand1,
        Operand1,
        Operator,
        PreOperand2,
        Operand2,
        ReadyToCalculate,
        Result,
    }
}