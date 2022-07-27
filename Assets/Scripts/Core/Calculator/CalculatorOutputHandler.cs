namespace Core.Calculator
{
    public class CalculatorOutputHandler
    {
        private readonly TextField _textField;
        
        public CalculatorOutputHandler(TextField textField)
        {
            _textField = textField;
        }

        public void AddOutput(float output)
        {
            _textField.Append(output);
        }
        
        public void AddZeroZeroOutput()
        {
            _textField.Append("¯\\_(ツ)_/¯");
        }
        
        public void AddPositiveZeroOutput()
        {
            _textField.Append('∞');
        }
    }
}