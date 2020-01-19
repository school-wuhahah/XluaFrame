--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-19 10:39:30
]]
local canvas_slpy = class("canvas_slpy")
canvas_slpy.prefixstr = "Canvas_Slid_%d"
canvas_slpy.canvastempname = "CanvasTemplate"
canvas_slpy.uimodel_init_tabs ={}

function canvas_slpy:ctor(...)
    local args = {...}
    self:init(args[1], args[2], args[3])
end

function canvas_slpy:init(priorityid, rootobj, uicamera)
    if not isnull(uicamera) then
        local tmpcanvaspb = loadasset(typeof(CS.UnityEngine.GameObject), self.canvastempname)
        self.canvasobj = newgameobject(tmpcanvaspb, rootobj.transform)
        self.canvasobj.name = string.format(self.prefixstr, priorityid)
        self.viewbinding = self.canvasobj:AddComponent(typeof(CS.XUUI.UGUIAdapter.ViewBinding))
        self.app = self.canvasobj:AddComponent(typeof(CS.App))
        local canvascmpt = self.canvasobj:GetComponent(typeof(CS.UnityEngine.Canvas))
        canvascmpt.worldCamera = uicamera
        canvascmpt.sortingLayerID = priorityid
    end
end

function canvas_slpy:adduimodelinit(uimodelname, func)
    if not uimodelname or type(uimodelname) ~= "string" then
        return
    end
    if not func or type(func) ~= "function" then
        return
    end
    for k, v in pairs(self.uimodel_init_tabs) do
        if k == uimodelname then
            return
        end
    end
    self.uimodel_init_tabs[uimodelname] = func
end

function canvas_slpy:runuiapp(appname)
    if not appname or type(appname) ~= "string" then
        return
    end
    for k, func in pairs(self.uimodel_init_tabs) do
        if func and type(func) == "function" then
            local state, err = pcall(func, self.canvasobj, self.viewbinding)
            if not state then
                print("canvas_slpy runuiapp uimodel init error : ", err)
            end
        end
    end
    if not isnull(self.app) then
        self.app.appmodelname = appname
        self.app:RunApp()
    end
end

function canvas_slpy:dispose()
    self.uimodel_init_tabs = {}
end

return canvas_slpy
