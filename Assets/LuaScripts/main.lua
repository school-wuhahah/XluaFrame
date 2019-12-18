local breakSocketHandle, debugXpCall = require("LuaDebug")("localhost", 7003)

local xlua = require "xlua.util"
local function main()
    print("hello xluaFrame ...")
    xlua.print_func_ref_by_csharp()
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
