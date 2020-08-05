using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


//https://tyrrrz.me/blog/expression-trees
//https://www.codementor.io/@juliandambrosio/how-to-use-expression-trees-to-build-dynamic-queries-c-xyk1l2l82


namespace PracticeExpression
{
    public class TestingExpr
    {
        public static void Testing(int inputNum)
        {
            ParameterExpression numParam = Expression.Parameter(typeof(int), "val");
            ConstantExpression ten = Expression.Constant(inputNum, typeof(int));
            BinaryExpression numLessThanTen = Expression.LessThan(numParam, ten);
            Expression<Func<int, bool>> expression =
                Expression.Lambda<Func<int, bool>>(
                    numLessThanTen,
                    new ParameterExpression[] { numParam });
            var eResults = expression.Compile();
        }


        public static void TestingIfThen(string strTest)
        {
            var TestCondition = Expression.Constant(strTest == "Kevin");
            var ifTrueBlock = WriteLineExpression("String is the same");
            ConditionalExpression ifThenExpr = Expression.IfThen(TestCondition, ifTrueBlock);
            Expression.Lambda<Action>(ifThenExpr).Compile()();
        }

        public static void TestingIf(string strTest)
        {
            var TestCondition = Expression.Constant(strTest == "Kevin");
        }

        public static Expression WriteLineExpression(string check)
        {
            return Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant(check));
        }
        public static Expression ConstructGreetingExpression()
        {
            var personNameParameter = Expression.Parameter(typeof(string), "personName");

            // Condition
            var isNullOrWhiteSpaceMethod = typeof(string)
                .GetMethod(nameof(string.IsNullOrWhiteSpace));

            var condition = Expression.Not(
                Expression.Call(isNullOrWhiteSpaceMethod, personNameParameter));

            // True clause
            var trueClause = Expression.Add(
                Expression.Constant("Greetings, "),
                personNameParameter);

            // False clause
            var falseClause = Expression.Constant(null, typeof(string));

            // Ternary conditional
            return Expression.Condition(condition, trueClause, falseClause);
        }

    }
}
