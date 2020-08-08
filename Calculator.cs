namespace myapp
{
    class Calculator
    {
        public int Add(params int[] numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            return sum;
        }
    }
}