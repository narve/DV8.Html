using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

//using log4net;

namespace DV8.Html.Utils
{
    public static class Reflect
    {
//        public static T LogAndReturn<T>(this T obj, ILog log, string msg)
//        {
//            log.Debug(msg);
//            return obj;
//        }

        public static string ToDebugString(this object obj)
        {
            if (obj == null) return "[NULL]";
            try
            {
                return obj.GetType().GetProperties()
                    .Select(pi => pi.Name + "=" + pi.GetValue(obj))
                    .ItemsToString();
            }
            catch (Exception e)
            {
                return obj + "; " + e;
            }
        }

        public static bool HasAttr<T>(this MemberInfo mi) => mi.AttrOrNull<T>() != null;

        public static T AttrOrNull<T>(this MemberInfo mi)
        {
//            Assert.NotNull("Missing method-info", mi);
            var attrs = mi.GetCustomAttributes(typeof(T), false);
            switch (attrs.Length)
            {
                case 0:
                    return default(T);
                case 1:
                    return (T) attrs[0];
                default:
                    throw new ArgumentException();
            }
        }

        public static IEnumerable<Type> GetImplementationsOf<T>()
        {
            var intf = typeof(T);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm=>asm.GetLoadableTypes())
                .Where(intf.IsAssignableFrom)
                .Where(t => t != intf)
                .Where(t => !t.IsAbstract)
                .Where(t => !t.IsInterface)
                ;
        }

        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }


        //        public static string GetAttr(this Enum value, Type attrType)
        //        {
        //            return
        //                value
        //                    .GetType()
        //                    .GetMember(value.ToString())
        //                    .FirstOrDefault()
        //                    ?.GetCustomAttribute<DescriptionAttribute>()
        //                    ?.Description;
        //        }
        //
        //        public static object GetAttr(this MemberInfo theType, Type attrType)
        //        {
        //            var attrs = theType.GetCustomAttributes(attrType, false);
        //            if (attrs.Length != 1)
        //                throw new NotSupportedException(attrType + " for " + theType + ", " + attrType + ": " + attrs.Length);
        //            return attrs[0];
        //        }
        //
        //        public static bool IsSubClassOfGeneric(this Type child, Type parent)
        //        {
        //            if (child == parent)
        //                return false;
        //
        //            if (child.IsSubclassOf(parent))
        //                return true;
        //
        //            var parameters = parent.GetGenericArguments();
        //            var isParameterLessGeneric = !(parameters != null && parameters.Length > 0 &&
        //                                           ((parameters[0].Attributes & TypeAttributes.BeforeFieldInit) == TypeAttributes.BeforeFieldInit));
        //
        //            while (child != null && child != typeof(object))
        //            {
        //                var cur = GetFullTypeDefinition(child);
        //                if (parent == cur ||
        //                    (isParameterLessGeneric &&
        //                     cur.GetInterfaces().Select(GetFullTypeDefinition).Contains(GetFullTypeDefinition(parent))))
        //                    return true;
        //                else if (!isParameterLessGeneric)
        //                    if (GetFullTypeDefinition(parent) == cur && !cur.IsInterface)
        //                    {
        //                        if (VerifyGenericArguments(GetFullTypeDefinition(parent), cur))
        //                            if (VerifyGenericArguments(parent, child))
        //                                return true;
        //                    }
        //                    else
        //                        foreach (var item in child.GetInterfaces().Where(i => GetFullTypeDefinition(parent) == GetFullTypeDefinition(i)))
        //                            if (VerifyGenericArguments(parent, item))
        //                                return true;
        //
        //                child = child.BaseType;
        //            }
        //
        //            return false;
        //        }

        //        private static Type GetFullTypeDefinition(Type type)
        //        {
        //            return type.IsGenericType ? type.GetGenericTypeDefinition() : type;
        //        }
        //
        //        private static bool VerifyGenericArguments(Type parent, Type child)
        //        {
        //            Type[] childArguments = child.GetGenericArguments();
        //            Type[] parentArguments = parent.GetGenericArguments();
        //            if (childArguments.Length == parentArguments.Length)
        //                for (int i = 0; i < childArguments.Length; i++)
        //                    if (childArguments[i].Assembly != parentArguments[i].Assembly || childArguments[i].Name != parentArguments[i].Name ||
        //                        childArguments[i].Namespace != parentArguments[i].Namespace)
        //                        if (!childArguments[i].IsSubclassOf(parentArguments[i]))
        //                            return false;
        //
        //            return true;
        //        }


        public static bool IsNullable(this Type type)
        {
            return
                type != null &&
                type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        [SuppressMessage("ReSharper", "TailRecursiveCall")]
        public static bool IsNumeric(this Type type)
        {
            if (type == null || type.IsEnum)
                return false;

            if (IsNullable(type))
                return IsNumeric(Nullable.GetUnderlyingType(type));

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }

        public static string RawName(this Type typeRef, bool fqn = false)
        {
            Debug.Assert(typeRef != null, "typeRef != null");
            Debug.Assert(typeRef.FullName != null, "typeRef.FullName != null");
            return string.Concat((fqn ? typeRef.FullName : typeRef.Name).TakeWhile(c => c != '`'));
        }

        public static string GenArgs(this Type typeRef, bool fqn = false)
        {
            return string.Join(", ", typeRef.GetGenericArguments().Select(t => t.GenericFqn(fqn)).ToArray());
        }

        public static string GenericFqn(this Type typeRef, bool fqn = false)
        {
            return typeRef.IsGenericType
                ? $"{typeRef.GetGenericTypeDefinition().RawName(fqn)}<{typeRef.GenArgs()}>"
                : typeRef.RawName(fqn);
        }
    }
}