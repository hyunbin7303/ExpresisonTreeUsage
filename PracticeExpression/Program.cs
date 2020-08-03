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

            ExpressionUtils.DataFeed();
            ExpressionUtils.testing(ExpressionUtils.allEmployee);



        }
    }
}
