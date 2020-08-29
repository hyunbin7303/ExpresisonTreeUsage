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

        public static void Testisng2()
        {
            //Create the expression parameters 
            ParameterExpression num1 = Expression.Parameter(typeof(int), "num1"); 
            ParameterExpression num2 = Expression.Parameter(typeof(int), "num2"); 
            //ParameterExpression num3 = Expression.Parameter(typeof(int), "num3");

            //Create the expression parameters 
            ParameterExpression[] parameters = new ParameterExpression[] { num1, num2 }; 
            //Create the expression body 
            BinaryExpression body = Expression.Add(num1, num2);
            //Create the expression 
            Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(body, parameters); 
            // Compile the expression 
            Func<int, int, int> compiledExpression = expression.Compile(); 
            // Execute the expression 
            int result = compiledExpression(3, 4); //return 7
        }

        public static void Testing3()
        {
            ParameterExpression pe = Expression.Parameter(typeof(Employee), "e");

            MemberExpression me = Expression.Property(pe, "Age");

            ConstantExpression constant = Expression.Constant(18, typeof(int));

            Expression<Func<Employee, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;

            Expression.Lambda<Func<Employee, bool>>(
                Expression.AndAlso(
                    Expression.GreaterThan(Expression.Property(pe, "Age"), Expression.Constant(12, typeof(int))),
                    Expression.LessThan(Expression.Property(pe, "Age"), Expression.Constant(20, typeof(int)))),
                        new[] { pe });
        }


        public static double CalculateSlope(double x1, double y1, double x2, double y2)
        {

            ParameterExpression paramX1 = Expression.Parameter(typeof(double));
            ParameterExpression paramY1 = Expression.Parameter(typeof(double));
            ParameterExpression paramX2 = Expression.Parameter(typeof(double));
            ParameterExpression paramY2 = Expression.Parameter(typeof(double));

            BinaryExpression ySub = Expression.Subtract(paramY2, paramY1);
            BinaryExpression xSub = Expression.Subtract(paramX2, paramX1);
            BinaryExpression div = Expression.Divide(ySub, xSub);

            Expression<Func<double, double, double, double, double>> slopeCalculate =
              Expression.Lambda<Func<double, double, double, double, double>>(div, paramY2, paramY1, paramX2, paramX1);

            return slopeCalculate.Compile()(y2, y1, x2, x1);
        }


        public static decimal userCosts(Employee e1, Employee e2)
        {
            ParameterExpression orderEx1 = Expression.Parameter(typeof(Employee), "e1");
            ParameterExpression orderEx2 = Expression.
        }
    }
}
