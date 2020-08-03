using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PracticeExpression
{
    public class TestingExpr
    {
        public static void Testing()
        {
            ParameterExpression numParam = Expression.Parameter(typeof(int), "val");
            ConstantExpression ten = Expression.Constant(10, typeof(int));
            BinaryExpression numLessThanTen = Expression.LessThan(numParam, ten);
            Expression<Func<int, bool>> expression =
                Expression.Lambda<Func<int, bool>>(
                    numLessThanTen,
                    new ParameterExpression[] { numParam });
            var eResults = expression.Compile();
        }
    }
}
