--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-06 19:29:29
]]

SortLayerPriority = {
    Default = 0, --预留 目前没有使用到
    Main = 10, --主场景层
    MainForSystem = 20, --主场景层上各种外围系统层级
    MainForFloatBoxTips = 40, --主场景层上的各种邀请或者浮动界面(跑马灯)
    LowLoadingCommonMessageBoxTips0 = 50, --游戏中各种通用弹框（低于loading页面）
    Loading0 = 60, --各种loading页面层级
    UpLoadingCommonMessageBoxTips0 = 70, --游戏中各种通用弹框层级（高于loading页面）
    NewPlayerGuide0 = 80, --游戏中新手指引层级
    SystemBoxTips0 = 90 --系统弹框
    --Count = 100
}

ComponentType = CS.XUUI.UGUIAdapter.ComponentType
Binding = CS.XUUI.UGUIAdapter.Binding

VariableType = CS.VariableType

CreateBinding = function(cmpttype, cmpt, bindto, multifields)
    local binding = Binding()
    binding.Type = cmpttype
    binding.Component = cmpt
    binding.BindTo = bindto
    binding.MultiFields = multifields
    return binding
end

local simple = {}

simple.uirootname = "UIRoot"
simple.canvastmp = "CanvasTemplate"
simple.panel1 = "Panel1"
simple.panel2 = "Panel2"

function simple:init()
    local uirootpb = CS.Asset.Load(self.uirootname, typeof(CS.UnityEngine.GameObject))
    local canvaspb = CS.Asset.Load(self.canvastmp, typeof(CS.UnityEngine.GameObject))
    local uiroot = CS.UnityEngine.Object.Instantiate(uirootpb)
    uiroot.name = self.uirootname
    local uicameracmpt = uiroot:GetComponentInChildren(typeof(CS.UnityEngine.Camera))
    local canvas = CS.UnityEngine.Object.Instantiate(canvaspb, uiroot.transform)
    local canvascmpt = canvas:GetComponent(typeof(CS.UnityEngine.Canvas))
    canvascmpt.worldCamera = uicameracmpt
    canvascmpt.sortingLayerID = SortLayerPriority.Main
    canvas.name = "Canvas_SLID_"..tostring(SortLayerPriority.Main)
    self.viewbinding = canvas:AddComponent(typeof(CS.XUUI.UGUIAdapter.ViewBinding))

    self:runApp(canvas, "myapp")
end

function simple:runApp(canvasobj, name)
    print("runapp : "..name.." bgn ...")
    self:initpanel1(canvasobj)
    self:initpanel2(canvasobj)
    local app = canvasobj:AddComponent(typeof(CS.App))
    app.appmodelname = name
    print("runapp : "..name.." end ...")
end

function simple:initpanel1(canvasobj)
    local panel1pb = CS.Asset.Load(self.panel1, typeof(CS.UnityEngine.GameObject))
    local panel1obj = CS.UnityEngine.Object.Instantiate(panel1pb, canvasobj.transform)
    local panel1luaui = panel1obj:AddComponent(typeof(CS.LuaUIView))
    panel1luaui.luascriptpath = "panel1"

    local array = CS.VariableArray()
    local textcmpt = panel1obj.transform:Find("Tip"):GetComponent(typeof(CS.UnityEngine.UI.Text))
    array:AddVariable("textcmpt", VariableType.Component, textcmpt)
    local btncmpt = panel1obj.transform:Find("Button"):GetComponent(typeof(CS.UnityEngine.UI.Button))
    array:AddVariable("btncmpt", VariableType.Component, btncmpt)
    local dropdowncmpt = panel1obj.transform:Find("Dropdown"):GetComponent(typeof(CS.UnityEngine.UI.Dropdown))
    array:AddVariable("dropdowncmpt", VariableType.Component, dropdowncmpt)
    local inputfieldcmpt = panel1obj.transform:Find("InputField"):GetComponent(typeof(CS.UnityEngine.UI.InputField))
    array:AddVariable("inputfieldcmpt", VariableType.Component, inputfieldcmpt)
    panel1luaui.variableArray = array

    local panel1 = require "panel1"
    panel1:init(self.viewbinding)
end

function simple:initpanel2(canvasobj)
    local panel2pb = CS.Asset.Load(self.panel2, typeof(CS.UnityEngine.GameObject))
    local panel2obj = CS.UnityEngine.Object.Instantiate(panel2pb, canvasobj.transform)
    local panel2luaui = panel2obj:AddComponent(typeof(CS.LuaUIView))
    panel2luaui.luascriptpath = "panel2"

    local array = CS.VariableArray()
    local textcmpt = panel2obj.transform:Find("Tip"):GetComponent(typeof(CS.UnityEngine.UI.Text))
    array:AddVariable("textcmpt", VariableType.Component, textcmpt)
    local btncmpt = panel2obj.transform:Find("Button"):GetComponent(typeof(CS.UnityEngine.UI.Button))
    array:AddVariable("btncmpt", VariableType.Component, btncmpt)
    local dropdowncmpt = panel2obj.transform:Find("Dropdown"):GetComponent(typeof(CS.UnityEngine.UI.Dropdown))
    array:AddVariable("dropdowncmpt", VariableType.Component, dropdowncmpt)
    local inputfieldcmpt = panel2obj.transform:Find("InputField"):GetComponent(typeof(CS.UnityEngine.UI.InputField))
    array:AddVariable("inputfieldcmpt", VariableType.Component, inputfieldcmpt)
    panel2luaui.variableArray = array

    local panel2 = require "panel2"
    panel2:init(self.viewbinding)
end


return simple
