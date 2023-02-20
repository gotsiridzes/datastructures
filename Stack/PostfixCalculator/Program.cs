using System.Collections.Generic;
using System;

public class Program
{
    private static void Main(string[] args)
    {
        var result = Calculate(args);
        Console.WriteLine(result);
    }

    private static int Calculate(string[] args){

        var stack = new Stack<int>();
        foreach (var token in args)
        {
            if(int.TryParse(token, out int value)){
                stack.Push(value);
            }
            else{
                int rhs = stack.Pop();
                int lhs = stack.Pop();

                switch(token){
                    case "+": stack.Push(lhs+rhs); break;
                    case "-": stack.Push(lhs-rhs); break;
                    case "*": stack.Push(lhs*rhs); break;
                    case "/": stack.Push(lhs/rhs); break;
                    case "%": stack.Push(lhs%rhs); break;
                    default: throw new ArgumentException($"token {token} is not recognised as valid operand");
                }
            }
        }

        return stack.Pop();
    }
}

