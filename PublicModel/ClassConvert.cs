﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace PublicModel
{
    /// <summary>
    /// 类转换
    /// </summary>
    public class ClassConvert
    {

        public static IList<TargetT> Convert<SourceT, TargetT>(IList<SourceT> sources) where TargetT : new()
        {
            IList<TargetT> targets = new List<TargetT>();
            foreach (SourceT source in sources)
            {
                TargetT target = new TargetT();
                target = Convert<SourceT, TargetT>(source);
                targets.Add(target);
            }

            return targets;
        }

        public static TargetT Convert<SourceT, TargetT>(SourceT source)
        {
            

            Type typeSource = typeof(SourceT);
            Type typeTarget = typeof(TargetT);

            //动态创建目标实例
            dynamic targetInstance = typeTarget.Assembly.CreateInstance(typeTarget.ToString()); 

            foreach (PropertyInfo sProperty in typeSource.GetProperties())
            {
                try
                {
                    // 属性名
                    var sPropertyName = sProperty.Name;
                    var sPropertyTypeName = sProperty.PropertyType.ToString();

                    //获取目标实例的属性
                    PropertyInfo tProperty = typeTarget.GetProperty(sPropertyName);
                    if (tProperty != null && tProperty.CanWrite) 
                    {
                        var tPropertyTypeName = tProperty.PropertyType.ToString();
                        object sValue = typeSource.GetProperty(sPropertyName).GetValue(source, null);

                        if (sValue != null && !String.IsNullOrEmpty(sValue.ToString()))
                        {
                            if(sPropertyTypeName == tPropertyTypeName){
                                //如果类型相同，则直接转换
                                tProperty.SetValue(targetInstance,sValue,null);
                            }
                            else
                            {
                                var convertValue = sValue;
                                switch (tPropertyTypeName)
                                {
                                    case "System.DateTime":
                                        convertValue = DateTime.Parse(sValue.ToString());
                                        break;
                                    case "System.Nullable`1[System.DateTime]":
                                        convertValue = DateTime.Parse(sValue.ToString());
                                        break;
                                    case "System.Int32":
                                        convertValue = Int32.Parse(sValue.ToString());
                                        break;
                                    case "System.Int64":
                                        convertValue = Int64.Parse(sValue.ToString());
                                        break;
                                    case "System.Nullable`1[System.Int32]":
                                        convertValue = Int32.Parse(sValue.ToString());
                                        break;
                                    case "System.Nullable`1[System.Int64]":
                                        convertValue = Int64.Parse(sValue.ToString());
                                        break;
                                    case "System.Double":
                                        convertValue = Double.Parse(sValue.ToString());
                                        break;
                                    case "System.Nullable`1[System.Double]":
                                        convertValue = Double.Parse(sValue.ToString());
                                        break;
                                    case "System.Decimal":
                                        convertValue = Decimal.Parse(sValue.ToString());
                                        break;
                                    case "System.Nullable`1[System.Decimal]":
                                        convertValue = Decimal.Parse(sValue.ToString());
                                        break;
                                    case "System.Nullable`1[System.Single]":
                                        convertValue = Single.Parse(sValue.ToString());

                                        break;
                                    case "System.Single":
                                        convertValue = Single.Parse(sValue.ToString());
                                        break;
                                    case "System.Boolean":
                                        convertValue = Boolean.Parse(sValue.ToString());
                                        break;
                                    case "System.Nullable`1[System.Boolean]":
                                        convertValue = int.Parse(sValue.ToString());
                                        break;
                                    case "System.String":
                                        convertValue = sValue.ToString();
                                        break;
                                    case "System.Byte[]":
                                        convertValue = sValue;
                                        break;
                                    case "System.Collections.Generic.List`1":

                                        break;
                                    case "System.Collections.Generic.ICollection`1":
                                    default:
                                        //集合判断
                                        if (sProperty.PropertyType.IsGenericType && tProperty.PropertyType.IsGenericType)
                                        {
                                            //获取实际类型
                                            var sActType = sProperty.PropertyType.GetGenericArguments().First();
                                            var tActType = tProperty.PropertyType.GetGenericArguments().First();

                                            //获取IList<TargetT> Convert<SourceT, TargetT>(IList<SourceT> sources)方法
                                            //泛型调用方法进行集合转换
                                            MethodInfo method = typeof(ClassConvert).GetMethods()
                                             .First(v=>v.Name =="Convert" && v.IsGenericMethod)
                                            .MakeGenericMethod(new Type[] {sActType,tActType });

                                            convertValue = method.Invoke(null, new object[] { sValue });
                                        }
                                        
                                        //其它情况不做任何操作
                                        break;
                                }
                                tProperty.SetValue(targetInstance, convertValue, null);
                            }
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(sProperty.Name + ex.Message);
                }
            }

            return targetInstance;
        }


    
    }
}
