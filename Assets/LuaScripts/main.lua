local breakSocketHandle, debugXpCall = require("LuaDebug")("localhost", 7003)

require "common.init"

local function main()
    print("hello xluaFrame ...")
    canvas_slpy_creator:init()
    local panel1 = require "panel1"
    canvas_slpy_tool:adduimodelinit(sortlayerpriority.Main, "panel1", handler(panel1, panel1.init))
    local panel2 = require "panel2"
    canvas_slpy_tool:adduimodelinit(sortlayerpriority.Main, "panel2", handler(panel2, panel2.init))
    canvas_slpy_tool:runuiapp(sortlayerpriority.Main, "myapp")
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
