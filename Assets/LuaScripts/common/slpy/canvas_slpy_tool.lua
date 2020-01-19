--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-19 11:25:12
]]
local canvas_slpy_tool = {}

function canvas_slpy_tool:getcanvasslpy(priorityid)
    return canvas_slpy_creator:getcanvasslpy(priorityid)
end

function canvas_slpy_tool:runuiapp(priorityid, appname)
    if self:getcanvasslpy(priorityid) then
        self:getcanvasslpy(priorityid):runuiapp(appname)
    end
end

function canvas_slpy_tool:adduimodelinit(priorityid, uimodelname, func)
    if self:getcanvasslpy(priorityid) then
        self:getcanvasslpy(priorityid):adduimodelinit(uimodelname, func)
    end
end

return canvas_slpy_tool