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

    self:runApp(canvas, "myapp")
end

function simple:runApp(canvasobj, name)
    local panel1pb = CS.Asset.Load(self.panel1, typeof(CS.UnityEngine.GameObject))
    local panel2pb = CS.Asset.Load(self.panel2, typeof(CS.UnityEngine.GameObject))
    CS.UnityEngine.Object.Instantiate(panel1pb, canvasobj.transform)
    CS.UnityEngine.Object.Instantiate(panel2pb, canvasobj.transform)
    local app = canvasobj:AddComponent(typeof(CS.App))
    app.appmodelname = "myapp"
end

return simple
