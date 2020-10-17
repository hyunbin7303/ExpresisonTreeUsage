using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace PracticeExpression
{

    class Program
    {


        private static void SetterTest()
        {
            var setterNameProperty = ExpressionUtils.CreateSetter<Employee, string>("Name");
            var setterBirthDateProperty = ExpressionUtils.CreateSetter<Employee, DateTime>("BirthDate");
            Employee emp = new Employee();
            setterNameProperty(emp, "John");
            setterBirthDateProperty(emp, new DateTime(1990, 6, 5));
            Console.WriteLine("Name: {0}, DOB: {1}", emp.Name, emp.birthofDate);

            var getterNameProperty = ExpressionUtils.CreateGetter<Employee, string>("Name");
            var getterBirthDateProperty = ExpressionUtils.CreateGetter<Employee, DateTime>("BirthDate");
            Employee emp1 = new Employee()
            {
                Name = "John",
                birthofDate = new DateTime(1990, 6, 5)
            };
            var name = getterNameProperty(emp1);
            var birthDate = getterBirthDateProperty(emp1);
            Console.WriteLine("Name: {0}, DOB: {1}", name, birthDate);
        }

        static void Main(string[] args)
        {

            ExprFundamental.Testing2();

            ExpressionUtils.DataFeed();
            ExpressionUtils.testing(ExpressionUtils.allEmployee);


            //Create the expression parameters
            ParameterExpression num1 = Expression.Parameter(typeof(int), "num1");
            ParameterExpression num2 = Expression.Parameter(typeof(int), "num2");

            //Create the expression parameters
            ParameterExpression[] parameters = new ParameterExpression[] { num1, num2 };

            //Create the expression body
            BinaryExpression body = Expression.Add(num1, num2);

            Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(body, parameters);
            Func<int, int, int> compiledExpr = expression.Compile();
            int result = compiledExpr(20, 30);
            int result2 = compiledExpr(40, 50);
            Console.WriteLine(result + "- " + result2);

            // a Query expression is compiled to expression trees or to delegates,
            //depending on the type that is applied to query result.
        
        
        }
    }
}
