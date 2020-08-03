using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PracticeExpression
{
    public static class ExpressionUtils
    {
        public static List<Employee> allEmployee = new List<Employee>();
        public static void DataFeed()
        {
            Employee emp1 = new Employee() { Name = "Kevin", birthofDate = new DateTime(2019, 5, 10) };
            Employee emp2 = new Employee() { Name = "Kevin2", birthofDate = new DateTime(2020, 6, 2) };
            Employee emp3 = new Employee() { Name = "John2", birthofDate = new DateTime(2020, 6, 3) };
            Employee emp4 = new Employee() { Name = "John3", birthofDate = new DateTime(2020, 3, 3) };
            Employee emp5 = new Employee() { Name = "John4", birthofDate = new DateTime(2020, 7, 26) };
            allEmployee.Add(emp1);
            allEmployee.Add(emp2);
            allEmployee.Add(emp3);
            allEmployee.Add(emp4);
            allEmployee.Add(emp5);
        }
        public static Action<TEntity, TProperty> CreateSetter<TEntity, TProperty>(string name) where TEntity : class
        {
            PropertyInfo propertyInfo = typeof(TEntity).GetProperty(name);
            ParameterExpression instance = Expression.Parameter(typeof(TEntity), "instance");
            ParameterExpression propertyValue = Expression.Parameter(typeof(TProperty), "propertyValue");
            var body = Expression.Assign(Expression.Property(instance, name), propertyValue);
            return Expression.Lambda<Action<TEntity, TProperty>>(body, instance, propertyValue).Compile();
        }
        public static Func<TEntity, TProperty> CreateGetter<TEntity, TProperty>(string name) where TEntity : class
        {
            ParameterExpression instance = Expression.Parameter(typeof(TEntity), "instance");
            var body = Expression.Property(instance, name);
            return Expression.Lambda<Func<TEntity, TProperty>>(body, instance).Compile();
        }
        public static void testing(List<Employee> employees)
        {
            var parameter = Expression.Parameter(typeof(Employee), "x");
            var birthofDateProp = typeof(Employee).GetProperty(nameof(Employee.birthofDate));
            var nameProp = typeof(Employee).GetProperty(nameof(Employee.Name));

            ParameterExpression param = Expression.Parameter(typeof(Employee), "x");
            var property = Expression.Property(param, "birthofDate");
            ConstantExpression constant = Expression.Constant(new DateTime(2015, 1, 1), typeof(DateTime));
            Expression finalExpression = Expression.LessThanOrEqual(property, constant);
            var tree = Expression.Lambda<Func<Employee, bool>>(finalExpression, param);
            Console.WriteLine(tree);

            Expression<Func<Employee, bool>> handMaidExpression = x => x.birthofDate == new DateTime(2015, 1, 1);
            Console.WriteLine(handMaidExpression);
        }
        private static readonly MethodInfo DateTimeGreaterThanOrEqualMethod = typeof(DateTime).GetMethod("op_GreaterThanOrEqual",
                        BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo DateTimeLessThanOrEqualMethod = typeof(DateTime).GetMethod("op_LessThanOrEqual",
                                BindingFlags.Static | BindingFlags.Public);

    }


}
