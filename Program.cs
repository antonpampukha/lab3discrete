
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter a vector with the value of the Boolean function:");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Vector cannot be empty.");
            return;
        }
        if (!input.All(char.IsDigit))
        {
            Console.WriteLine("Vector include character");
            return;
        }

        int numVariables = 0;
        int len = input.Length;
        if (len == 1)
        {
            Console.WriteLine("Length mustn`t be 1");
            return;
        }

        while (len > 1)
        {
            numVariables++;
            if (len % 2 != 0)
            {
                Console.WriteLine("Input length must be a power of 2.");
                return;
            }
            len /= 2;
        }


        //List<bool> functionValues = input.Select(c => c == '1').ToList();
        List<bool> functionValues = new List<bool>();

        
        for (int i = 0; i < input.Length; i++)
        {
            if (int.TryParse(input[i].ToString(), out int number) && ((number == 1) || (number == 0)))
                functionValues.Add(Convert.ToBoolean(number));
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
        }
       
        if (IsSelfDual(functionValues))
            Console.WriteLine("Func is self dual");
        else
            Console.WriteLine("Func isn`t self dual");
    }
   
    static bool IsSelfDual(List<bool> function)
    {
        int value = function.Count / 2;
        for (int i = 0; i < value; i++)
        {
            if (function[i] == function[function.Count - i - 1])
                return false;
        }
        return true;
    }
}