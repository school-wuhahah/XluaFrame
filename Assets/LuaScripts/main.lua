local breakSocketHandle, debugXpCall = require("LuaDebug")("localhost", 7003)

local xlua = require "xlua.util"
local function main()
    print("hello xluaFrame ...")
    xlua.print_func_ref_by_csharp()
end

main()