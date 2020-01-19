--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-17 15:47:27
]]
require "common.slpy.slpy_defines"
local canvas_slpy = require "common.slpy.canvas_slpy"

local canvas_slpy_creator = {}
canvas_slpy_creator.uirootname = "UIRoot"
canvas_slpy_creator.prefixstr = "Canvas_Slid_%d"
canvas_slpy_creator.uicameraname = "UICamera"
canvas_slpy_creator.canvas_slpy_tab = {}

function canvas_slpy_creator:init()
    if isnull(self.rootobj) then
        local uirootpb = loadasset(typeof(CS.UnityEngine.GameObject), self.uirootname)
        self.rootobj = newgameobject(uirootpb)
        self.rootobj.name = self.uirootname
        if not isnull(self.rootobj) then
            self.uicamera = findcompent(self.rootobj.transform, self.uicameraname, typeof(CS.UnityEngine.Camera))
        end
    end
end

function canvas_slpy_creator:check(priorityid)
    if not self:checkroot() then
        return false
    end
    if not checkslpriorityvalid(priorityid) then
        return false
    end 
    if not self.canvas_slpy_tab[priorityid] then
        return false
    end
    return true
end

--@desc 检测UIRoot是否存在
function canvas_slpy_creator:checkroot()
    if isnull(self.rootobj) then
        return false
    end
    return true
end


function canvas_slpy_creator:create(priorityid)
    if not self:check(priorityid) then
        local canvas_slpy_tmp = canvas_slpy.new(priorityid, self.rootobj, self.uicamera)
        self.canvas_slpy_tab[priorityid] = canvas_slpy_tmp
    end
end

function canvas_slpy_creator:getcanvasslpy(priorityid)
    if not self:check(priorityid) then
        self:create(priorityid)
    end
    return self.canvas_slpy_tab[priorityid]
end


return canvas_slpy_creator