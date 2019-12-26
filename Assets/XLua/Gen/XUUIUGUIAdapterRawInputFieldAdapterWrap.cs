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
    public class XUUIUGUIAdapterRawInputFieldAdapterWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(XUUI.UGUIAdapter.RawInputFieldAdapter);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 1, 2);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnValueChange", _g_get_OnValueChange);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnValueChange", _s_set_OnValueChange);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Value", _s_set_Value);
            
			
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
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<UnityEngine.UI.InputField>(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					UnityEngine.UI.InputField _input = (UnityEngine.UI.InputField)translator.GetObject(L, 2, typeof(UnityEngine.UI.InputField));
					string _bindTo = LuaAPI.lua_tostring(L, 3);
					
					XUUI.UGUIAdapter.RawInputFieldAdapter gen_ret = new XUUI.UGUIAdapter.RawInputFieldAdapter(_input, _bindTo);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to XUUI.UGUIAdapter.RawInputFieldAdapter constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnValueChange(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                XUUI.UGUIAdapter.RawInputFieldAdapter gen_to_be_invoked = (XUUI.UGUIAdapter.RawInputFieldAdapter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnValueChange);
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
			
                XUUI.UGUIAdapter.RawInputFieldAdapter gen_to_be_invoked = (XUUI.UGUIAdapter.RawInputFieldAdapter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnValueChange = translator.GetDelegate<System.Action<string>>(L, 2);
            
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
			
                XUUI.UGUIAdapter.RawInputFieldAdapter gen_to_be_invoked = (XUUI.UGUIAdapter.RawInputFieldAdapter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Value = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
