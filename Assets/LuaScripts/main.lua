local breakSocketHandle, debugXpCall = require("LuaDebug")("localhost", 7003)

local function main()
    print("hello xluaFrame ...")
    local canvasobj = CS.UnityEngine.GameObject.Find("Canvas")
    local app = canvasobj:AddComponent(typeof(CS.App))
    app.appmodelname = "myapp"
end

local function logtraceback(msg)
    local tracemsg = debug.traceback()
    print("error: " .. tostring(msg) .. "\n" .. tracemsg)
    return msg
end

local ret, msg = xpcall(main, logtraceback)
if not ret then
    error("\n" .. "lua error msg:" .. "\n" .. "\t" .. msg)
end
