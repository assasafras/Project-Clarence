using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Assets.Scripts.Utils
{
    public class ExceptionUtils
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }
        public static string GetCurrentClass(object o)
        {
            return o.GetType().ToString();
        }


        public static string GetCurrentClassAndMethod(object o, string msg)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(2);
            return GetCurrentClass(o) + "." + sf.GetMethod().Name + " - " + msg;

        }
    }
}
