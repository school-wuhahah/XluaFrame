#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class DelegateBridge : DelegateBridgeBase
    {
		
		public void __Gen_Delegate_Imp0()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                
                PCall(L, 0, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp1(string p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushstring(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp2(int p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public XLua.LuaTable __Gen_Delegate_Imp3()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                
                PCall(L, 0, 1, errFunc);
                
                
                XLua.LuaTable __gen_ret = (XLua.LuaTable)translator.GetObject(L, errFunc + 1, typeof(XLua.LuaTable));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public System.Action __Gen_Delegate_Imp4(UnityEngine.GameObject p0, XLua.LuaTable p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                translator.Push(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                System.Action __gen_ret = translator.GetDelegate<System.Action>(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public System.Func<UnityEngine.GameObject, XLua.LuaTable, System.Action> __Gen_Delegate_Imp5()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                
                PCall(L, 0, 1, errFunc);
                
                
                System.Func<UnityEngine.GameObject, XLua.LuaTable, System.Action> __gen_ret = translator.GetDelegate<System.Func<UnityEngine.GameObject, XLua.LuaTable, System.Action>>(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp6(XLua.LuaTable p0, string p1, object p2, string p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                LuaAPI.lua_pushstring(L, p1);
                translator.PushAny(L, p2);
                LuaAPI.lua_pushstring(L, p3);
                
                PCall(L, 4, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public System.Action<XLua.LuaTable, string, object, string> __Gen_Delegate_Imp7()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                
                PCall(L, 0, 1, errFunc);
                
                
                System.Action<XLua.LuaTable, string, object, string> __gen_ret = translator.GetDelegate<System.Action<XLua.LuaTable, string, object, string>>(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp8(XLua.LuaTable p0, out System.Func<UnityEngine.GameObject, System.Action> p1, out System.Action<string, bool> p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 2, errFunc);
                
                p1 = (System.Func<UnityEngine.GameObject, System.Action>)translator.GetObject(L, errFunc + 1, typeof(System.Func<UnityEngine.GameObject, System.Action>));
                p2 = (System.Action<string, bool>)translator.GetObject(L, errFunc + 2, typeof(System.Action<string, bool>));
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp9(string p0, bool p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushstring(L, p0);
                LuaAPI.lua_pushboolean(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp10(XLua.LuaTable p0, string p1, string p2, object p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                LuaAPI.lua_pushstring(L, p1);
                LuaAPI.lua_pushstring(L, p2);
                translator.PushAny(L, p3);
                
                PCall(L, 4, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
        
		static DelegateBridge()
		{
		    Gen_Flag = true;
		}
		
		public override Delegate GetDelegateByType(Type type)
		{
		
		    if (type == typeof(System.Action))
			{
			    return new System.Action(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(System.Action<string>))
			{
			    return new System.Action<string>(__Gen_Delegate_Imp1);
			}
		
		    if (type == typeof(System.Action<int>))
			{
			    return new System.Action<int>(__Gen_Delegate_Imp2);
			}
		
		    if (type == typeof(System.Func<XLua.LuaTable>))
			{
			    return new System.Func<XLua.LuaTable>(__Gen_Delegate_Imp3);
			}
		
		    if (type == typeof(System.Func<UnityEngine.GameObject, XLua.LuaTable, System.Action>))
			{
			    return new System.Func<UnityEngine.GameObject, XLua.LuaTable, System.Action>(__Gen_Delegate_Imp4);
			}
		
		    if (type == typeof(System.Func<System.Func<UnityEngine.GameObject, XLua.LuaTable, System.Action>>))
			{
			    return new System.Func<System.Func<UnityEngine.GameObject, XLua.LuaTable, System.Action>>(__Gen_Delegate_Imp5);
			}
		
		    if (type == typeof(System.Action<XLua.LuaTable, string, object, string>))
			{
			    return new System.Action<XLua.LuaTable, string, object, string>(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(System.Func<System.Action<XLua.LuaTable, string, object, string>>))
			{
			    return new System.Func<System.Action<XLua.LuaTable, string, object, string>>(__Gen_Delegate_Imp7);
			}
		
		    if (type == typeof(XUUI.ContextCreator))
			{
			    return new XUUI.ContextCreator(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(System.Action<string, bool>))
			{
			    return new System.Action<string, bool>(__Gen_Delegate_Imp9);
			}
		
		    if (type == typeof(System.Action<XLua.LuaTable, string, string, object>))
			{
			    return new System.Action<XLua.LuaTable, string, string, object>(__Gen_Delegate_Imp10);
			}
		
		    return null;
		}
	}
    
}