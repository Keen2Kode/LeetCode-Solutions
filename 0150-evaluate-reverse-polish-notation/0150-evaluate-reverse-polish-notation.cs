public class Solution {
    public int EvalRPN(string[] tokens) {
        
        // stack
        // number? push
        // op? pop last 2, push result

        Stack<int> stack = new();
        foreach (string token in tokens) {
            bool isNum = int.TryParse(token, out int num);
            if (isNum) {
                stack.Push(num);
            }
            else {
                int num2 = stack.Pop();
                int num1 = stack.Pop();
                stack.Push(Result(num1, num2, token));
            } 
        }
        return stack.Peek();
    }

    public int Result(int num1, int num2, string token) {
        if (token == "+") {
            return num1+num2;
        }
        else if (token == "-") {
            return num1-num2;
        }
        else if (token == "*") {
            return num1*num2;
        }
        else if (token == "/") {
            return num1/num2;
        }
        throw new ArgumentException();
    }
}