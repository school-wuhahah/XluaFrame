﻿using System.Collections.Generic;
using System;
using XLua;
using UnityEngine.UI;

namespace XUUI.UGUIAdapter
{

    public static class AdapterGenConfig
    {
        [LuaCallCSharp]
        public static List<Type> LuaCallCSharp = new List<Type>()
        {
            typeof(TextAdapter),
            typeof(InputFieldAdapter),
            typeof(DropdownAdapter),
            typeof(ButtonAdapter),
            typeof(DropdownOptionsAdapter),
            typeof(AdapterBase),
            typeof(RawAdapterBase),
            typeof(RawTextAdapter),
            typeof(RawInputFieldAdapter),
            typeof(RawDropdownAdapter),
            typeof(RawButtonAdapter),
        };

        [CSharpCallLua]
        public static List<Type> CSharpCallLua = new List<Type>()
        {
            typeof(Action),
            typeof(Action<string>),
            typeof(Action<int>),
        };
    }
}