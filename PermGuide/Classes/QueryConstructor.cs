using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    public class QueryConstructor
    {
        public class QueryTree
        {
            public QueryTree(Type type, string name)
            {
                ActualType = type;
                Name = name;
                Children = new List<QueryTree>();
                Criterium = "";
                CompareEquals = true;
                mInner = new List<object>();
            }

            public QueryTree(Type type, string name, List<QueryTree> children) :
                this(type, name)
            {
                Children = new List<QueryTree>(children);
            }

            public void Add(QueryTree node)
            {
                Children.Add(node);
            }

            public void Add(Type type, string name)
            {
                Children.Add(new QueryTree(type, name));
            }

            public override string ToString()
            {
                return Name;
            }

            public bool HasChildren => Children.Count != 0;
            public string Name { get; internal set; }
            public List<QueryTree> Children { get; internal set; }
            public string Criterium { get; set; }
            public bool CompareEquals { get; set; }
            public Type ActualType { get; internal set; }
            internal List<object> mInner;
        }

        public QueryConstructor(params string[] recordNames)
        {
            mRecordNames = new HashSet<Type>(
                from v
                in recordNames
                select GetThisAssemblyType(v)
            );
        }
        
        public QueryTree GetAttributes(string typename)
        {
            return GetAttributes(GetThisAssemblyType(typename), 0, typename);
        }

        public List<T> Query<T>(DbSet<T> set, QueryTree root) where T : class
        {
            List<T> result = new List<T>();
            List<Func<object, bool>> checks = new List<Func<object, bool>>();

            foreach (var a in root.Children)
            {
                if (a.HasChildren)
                {
                    foreach (var b in a.Children)
                    {
                        if (b.Criterium != string.Empty)
                        {
                            bool foldLambda(object x)
                            {
                                object criterium = Convert.ChangeType(b.Criterium, b.ActualType);
                                var collection = x.GetType().GetProperty(a.Name).GetValue(x) as IEnumerable;

                                bool ok = false;

                                foreach (var inner in collection)
                                {
                                    ok = b.CompareEquals
                                        ? criterium.Equals(x)
                                        : !criterium.Equals(x);

                                    if (ok)
                                        break;
                                }

                                return ok;

                                /*return a.CompareEquals
                                ? collection.Any(item => criterium.Equals(x))
                                : collection.Any(item => !criterium.Equals(x));*/
                            }

                            checks.Add(foldLambda);
                        }
                    }
                }
                else if (a.Criterium != string.Empty)
                {
                    bool lambda(object x)
                    {
                        object criterium = Convert.ChangeType(a.Criterium, a.ActualType);
                        var val = x.GetType().GetProperty(a.Name).GetValue(x);

                        return a.CompareEquals
                        ? criterium.Equals(val)
                        : !criterium.Equals(val);
                    }
                    
                    checks.Add(lambda);
                }
            }

            foreach (var v in set)
            {
                bool ok = true;

                foreach (var p in checks)
                    if (!p(v))
                    {
                        ok = false;
                        break;
                    }

                if (ok)
                    result.Add(v);
            }

            return result;
        }

        private QueryTree GetAttributes(Type type, int depth, string rootName)
        {
            QueryTree result = new QueryTree(type, rootName);

            try
            {
                foreach (var prop in type.GetProperties())
                {
                    if (mRecordNames.Contains(prop.PropertyType))
                    {
                        if (depth == 0)
                            result.Add(GetAttributes(prop.PropertyType, depth + 1, prop.Name));
                    }
                    else if (prop.PropertyType.Name.Contains("ICollection"))
                    {
                        if (depth == 0)
                        {
                            result.Add(
                                GetAttributes(
                                    prop.PropertyType.GenericTypeArguments.First(),
                                    depth + 1,
                                    prop.Name
                                )
                            );
                        }
                    }
                    else
                    {
                        result.Add(prop.PropertyType, prop.Name);
                    }
                }
            }
            catch (TypeLoadException)
            {
                throw;
            }

            return result;
        }

        private Type GetThisAssemblyType(string typename)
        {
            var asm = Assembly.GetExecutingAssembly();
            var name = asm.GetName().Name;
            return Type.GetType($"{name}.{typename}", true);
        }

        private HashSet<Type> mRecordNames;
    }
}