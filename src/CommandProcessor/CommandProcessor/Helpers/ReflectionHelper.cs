using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MvcContrib.CommandProcessor.Helpers
{
	internal static class ReflectionHelper
	{
		//public static string FindPropertyName(LambdaExpression lambdaExpression)
		//{
		//    return FindProperty(lambdaExpression).Name;
		//}

		public static MemberInfo FindMember(LambdaExpression lambdaExpression)
		{
			Expression expressionToCheck = lambdaExpression;

			bool done = false;

			while (!done)
			{
				switch (expressionToCheck.NodeType)
				{
					case ExpressionType.Convert:
						expressionToCheck = ((UnaryExpression)expressionToCheck).Operand;
						break;
					case ExpressionType.Lambda:
						expressionToCheck = lambdaExpression.Body;
						break;
					case ExpressionType.MemberAccess:
						var propertyInfo = ((MemberExpression)expressionToCheck).Member;
						return propertyInfo;
					case ExpressionType.Call:
						return ((MethodCallExpression)expressionToCheck).Method;
					default:
						done = true;
						break;
				}
			}

			return null;
		}

		public static PropertyInfo FindProperty(LambdaExpression lambdaExpression)
		{
			Expression expressionToCheck = lambdaExpression;

			bool done = false;

			while (!done)
			{
				switch (expressionToCheck.NodeType)
				{
					case ExpressionType.Convert:
						expressionToCheck = ((UnaryExpression) expressionToCheck).Operand;
						break;
					case ExpressionType.Lambda:
						expressionToCheck = lambdaExpression.Body;
						break;
					case ExpressionType.MemberAccess:
						var propertyInfo = ((MemberExpression) expressionToCheck).Member as PropertyInfo;
						return propertyInfo;
					default:
						done = true;
						break;
				}
			}

			return null;
		}

		public static Type GetMemberType(this MemberInfo memberInfo)
		{
			if (memberInfo is MethodInfo)
				return ((MethodInfo) memberInfo).ReturnType;
			if (memberInfo is PropertyInfo)
				return ((PropertyInfo) memberInfo).PropertyType;
			if (memberInfo is FieldInfo)
				return ((FieldInfo) memberInfo).FieldType;
			return null;
		}
	}
}