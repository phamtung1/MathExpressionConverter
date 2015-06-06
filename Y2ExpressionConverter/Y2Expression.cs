/**********************************************************************
 * Expression Conversion, Evaluation and Expression Tree Builder
 * Author: Yin Yang
 * yinyang.it@gmail.com
 * http://yinyangit.wordpress.com
 *
 * Date: 27 Jan 2011
 * Lasted Update: 25 March 2011
 * Version 1.2.1
 **********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Y2_Expression_Converter
{
    public class Y2Expression
    {

        public static string Infix2Prefix(string infix)
        {

            infix = ExprHelper.FormatExpression(infix);

            string[] tokens = infix.Split(' ').ToArray();

            tokens = ProcessConvert(tokens).Split(' ').Reverse().ToArray();

            StringBuilder result = new StringBuilder();

            Array.ForEach(tokens, s => result.Append(s).Append(" "));
            return result.ToString();

        }

        public static string Infix2Postfix(string infix)
        {
            infix = ExprHelper.FormatExpression(infix);

            string[] tokens = infix.Split(' ').ToArray();

            return ProcessConvert(tokens);
        }

        private static string ProcessConvert(string[] tokens)
        {
            Stack<string> stack = new Stack<string>();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                if (ExprHelper.IsOperator(token))
                {
                    if ((i == 0) || (i > 0 && (ExprHelper.IsOperator(tokens[i - 1]) || tokens[i - 1] == "(")))
                    {
                        if (token == "-")
                        {
                            result.Append(token + tokens[i + 1]).Append(" ");
                            i++;
                        }
                        else if (ExprHelper.IsUnaryFunction(token))
                        {
                            stack.Push(token);
                        }
                    }
                    else
                    {
                        while (stack.Count > 0 && ExprHelper.GetPriority(token) <= ExprHelper.GetPriority(stack.Peek()))
                            result.Append(stack.Pop()).Append(" ");
                        stack.Push(token);
                    }
                }

                else if (token == "(")
                    stack.Push(token);
                else if (token == ")")
                {
                    string x = stack.Pop();
                    while (x != "(")
                    {
                        result.Append(x).Append(" ");
                        x = stack.Pop();
                    }
                }
                else// (IsOperand(s))
                {
                    result.Append(token).Append(" ");
                }
            }

            while (stack.Count > 0)
                result.Append(stack.Pop()).Append(" ");

            return result.ToString();
        }

        #region Evaluate

        public static double EvaluatePrefix(string prefix)
        {
            return EvaluatePostfix(prefix.Trim().Split(' ').Reverse());
        }

        public static double EvaluatePostfix(string postfix)
        {
            return EvaluatePostfix(postfix.Trim().Split(' '));
        }

        private static double EvaluatePostfix(IEnumerable<string> tokens)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string s in tokens)
            {
                if (ExprHelper.IsOperator(s))
                {
                    double x = stack.Pop();

                    if (ExprHelper.IsUnaryFunction(s))
                    {
                        switch (s)
                        {
                            case "sqrt":
                                x = Math.Sqrt(x);
                                break;
                            case "sin":
                                x = Math.Sin(x);
                                break;
                            case "cos":
                                x = Math.Cos(x);
                                break;
                            case "tan":
                                x = Math.Tan(x);
                                break;
                            default:
                                throw new Exception("Invalid function");
                        }
                        stack.Push(x);
                    }
                    else
                    {
                        double y = stack.Pop();

                        switch (s)
                        {
                            case "+": y += x; break;
                            case "-": y -= x; break;
                            case "*": y *= x; break;
                            case "/": y /= x; break;
                            case "%": y %= x; break;
                            case "^": y = Math.Pow(y, x); break;
                            default:
                                throw new Exception("Invalid operator");
                        }

                        stack.Push(y);
                    }
                }
                else  // IsOperand
                {
                    stack.Push(double.Parse(s));
                }

            }
            return stack.Pop();
        }

        public static double EvaluateExpressionTree(BinaryTreeNode node)
        {            
            double t = 0;
            if (node.IsLeaf)
                t = double.Parse(node.Value);
            else
            {
                double x = EvaluateExpressionTree(node.LeftChild);

                string s = node.Value;

                if (ExprHelper.IsUnaryFunction(s))
                {
                    switch (s)
                    {
                        case "sqrt":
                            t = Math.Sqrt(x);
                            break;
                        case "sin":
                            t = Math.Sin(x);
                            break;
                        case "cos":
                            t = Math.Cos(x);
                            break;
                        case "tan":
                            t = Math.Tan(x);
                            break;
                        default:
                            throw new Exception("Invalid function");
                    }
                }
                else
                {
                    double y = EvaluateExpressionTree(node.RightChild);

                    switch (s)
                    {
                        case "+": t=y + x; break;
                        case "-": t=y - x; break;
                        case "*": t= y* x; break;
                        case "/": t=y/ x; break;
                        case "%": t=y % x; break;
                        case "^": t = Math.Pow(y, x); break;
                        default:
                            throw new Exception("Invalid operator");
                    }
                   
                }
            }
            return t;
        }

        #endregion

        #region Create Expression Tree
        /// <summary>
        /// Tạo một cây nhị phân 3 node với node gốc là toán tử, 2 node lá là toán hạng
        /// </summary>
        /// <param name="node"></param>
        /// <param name="opStack"></param>
        /// <param name="nodeStack"></param>        
        private static void CreateSubTree(Stack<BinaryTreeNode> opStack, Stack<BinaryTreeNode> nodeStack)
        {
            BinaryTreeNode node = opStack.Pop();
            node.LeftChild = nodeStack.Pop();
            if (!ExprHelper.IsUnaryFunction(node.Value))
                node.RightChild = nodeStack.Pop();
            nodeStack.Push(node);
        }

        public static BinaryTreeNode Infix2ExpressionTree(string infixExpression)
        {
            List<string> prefix = new List<string>();
            Stack<BinaryTreeNode> operatorStack = new Stack<BinaryTreeNode>();
            Stack<BinaryTreeNode> nodeStack = new Stack<BinaryTreeNode>();

            infixExpression = ExprHelper.FormatExpression(infixExpression);

            string[] tokens = infixExpression.Split(' ').ToArray();

            for (int i = 0; i < tokens.Count(); i++)
            {
                if (ExprHelper.IsOperator(tokens[i]))
                {
                    if ((i == 0) || (i > 0 && (ExprHelper.IsOperator(tokens[i - 1]) || tokens[i - 1] == "(")))
                    {
                        if (tokens[i] == "-")
                        {
                            nodeStack.Push(new BinaryTreeNode(tokens[i] + tokens[i + 1]));
                            i++;
                        }
                        else if (ExprHelper.IsUnaryFunction(tokens[i]))
                            operatorStack.Push(new BinaryTreeNode(tokens[i]));
                    }
                    else
                    {
                        while (operatorStack.Count > 0 && ExprHelper.GetPriority(operatorStack.Peek().Value) >= ExprHelper.GetPriority(tokens[i]))
                            CreateSubTree(operatorStack, nodeStack);

                        operatorStack.Push(new BinaryTreeNode(tokens[i]));
                    }
                }


                else if (tokens[i] == "(")
                    operatorStack.Push(new BinaryTreeNode(tokens[i]));
                else if (tokens[i] == ")")
                {
                    while (operatorStack.Peek().Value != "(")
                        CreateSubTree(operatorStack, nodeStack);
                    operatorStack.Pop();
                }
                else //if (IsOperand(tokens[i]))
                    nodeStack.Push(new BinaryTreeNode(tokens[i]));
            }

            while (operatorStack.Count > 0)
                CreateSubTree(operatorStack, nodeStack);

            return nodeStack.Peek();
        }

        public static BinaryTreeNode Postfix2ExpressionTree(string postfixExpression)
        {
            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();

            IEnumerable<string> enumer = postfixExpression.Split(' ');

            foreach (string s in enumer)
            {
                BinaryTreeNode node = new BinaryTreeNode(s);
                if (ExprHelper.IsOperand(s))
                    stack.Push(node);
                else if (ExprHelper.IsOperator(s))
                {
                    node.RightChild = stack.Pop();
                    node.LeftChild = stack.Pop();
                    stack.Push(node);
                }
            }
            return stack.Pop();
        }

        #endregion
    }
}

