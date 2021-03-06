﻿using System;
using System.Text.RegularExpressions;


namespace Y2_Expression_Converter
{
    public class ExprHelper
    {
        private const string UNARY_FUNCS="sqrt|sin|cos";

        public static string FormatExpression(string expression)
        {
            expression = expression.ToLower().Replace(" ", "");
            expression = Regex.Replace(expression, @"(\+|\-|\*|\/|\%|\^){3,}", match => match.Value[0].ToString());

            expression = Regex.Replace(expression, @"(\+|\-|\*|\/|\%|\^)(\+|\*|\/|\%|\^)", match =>
                match.Value[0].ToString()
            );
            expression = Regex.Replace(expression, @"\+|\-|\*|\/|\%|\^|\)|\(", match =>
                String.Format(" {0} ", match.Value)
            );
            expression = expression.Replace("  ", " ");
            expression = expression.Trim();

            return expression;
        }

        public static int GetPriority(string op)
        {
            if (UNARY_FUNCS.IndexOf(op,StringComparison.OrdinalIgnoreCase)>=0)
                return 3;
            if (op == "*" || op == "/" || op == "%"||op == "^")
                return 2;
            if (op == "+" || op == "-")
                return 1;
            return 0;
        }


        public static bool IsOperator(string str)
        {
            return Regex.Match(str, @"^(\+|\-|\*|\/|\%|\^|"+UNARY_FUNCS+")$").Success;
        }
        public static bool IsUnaryFunction(string str)
        {
            return Regex.Match(str, @"^("+UNARY_FUNCS+")$").Success;
        }
        public static bool IsOperand(string str)
        {
            return Regex.Match(str, @"^\d+$|^([a-z]|[A-Z])$").Success;
        }
    }
}
                                                           