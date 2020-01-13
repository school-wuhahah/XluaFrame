local breakSocketHandle, debugXpCall = require("LuaDebug")("localhost", 7003)

require "common.init"

local function main()
    print("hello xluaFrame ...")
    local simpleTest = require("SimpleTest")
    simpleTest:init()
    local test = class("test", CS.UnityEngine.GameObject)
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
