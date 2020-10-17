using PracticeExpression.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PracticeExpression
{
    public static class ExprFundamental
    {
        public static void Testing1()
        {
            Expression<Func<int, string>> exprLambda = x => x.ToString();

            Func<int, string> delegateLambda = exprLambda.Compile(); // x => x.ToString();
                                                                     //Compile() is really slowwwwwwwwwwwwwwwwwww. 

        }
        //public string static readonly Spec<Product> IsForSaleSpec = new Spec<Product>


        public static void Testing2()
        {
            Expression<Func<int, bool>> e1 = x => x > 5;
            Expression<Func<int, bool>> e2 = x=>x / 2 == 5;

            Expression combined = Expression.OrElse(e1.Body, e2.Body);
            var lambda = Expression.Lambda<Func<int, bool>>(combined);
        
        
        }

        public static class NativeOr
        {
        }
    }
}
