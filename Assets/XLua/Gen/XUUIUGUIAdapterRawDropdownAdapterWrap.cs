#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class XUUIUGUIAdapterRawDropdownAdapterWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(XUUI.UGUIAdapter.RawDropdownAdapter);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 2, 3);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnValueChange", _g_get_OnValueChange);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "target", _g_get_target);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnValueChange", _s_set_OnValueChange);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Value", _s_set_Value);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "target", _s_set_target);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<UnityEngine.UI.Dropdown>(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					UnityEngine.UI.Dropdown _dropdown = (UnityEngine.UI.Dropdown)translator.GetObject(L, 2, typeof(UnityEngine.UI.Dropdown));
					string _bindTo = LuaAPI.lua_tostring(L, 3);
					
					XUUI.UGUIAdapter.RawDropdownAdapter gen_ret = new XUUI.UGUIAdapter.RawDropdownAdapter(_dropdown, _bindTo);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to XUUI.UGUIAdapter.RawDropdownAdapter constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnValueChange(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                XUUI.UGUIAdapter.RawDropdownAdapter gen_to_be_invoked = (XUUI.UGUIAdapter.RawDropdownAdapter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnValueChange);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_target(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                XUUI.UGUIAdapter.RawDropdownAdapter gen_to_be_invoked = (XUUI.UGUIAdapter.RawDropdownAdapter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.target);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnValueChange(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                XUUI.UGUIAdapter.RawDropdownAdapter gen_to_be_invoked = (XUUI.UGUIAdapter.RawDropdownAdapter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnValueChange = translator.GetDelegate<System.Action<int>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                XUUI.UGUIAdapter.RawDropdownAdapter gen_to_be_invoked = (XUUI.UGUIAdapter.RawDropdownAdapter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Value = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_target(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                XUUI.UGUIAdapter.RawDropdownAdapter gen_to_be_invoked = (XUUI.UGUIAdapter.RawDropdownAdapter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.target = (UnityEngine.UI.Dropdown)translator.GetObject(L, 2, typeof(UnityEngine.UI.Dropdown));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
