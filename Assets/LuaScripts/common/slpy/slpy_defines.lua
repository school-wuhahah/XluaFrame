--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-17 15:50:33
]]

sortlayerpriority = {
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

componenttype = CS.XUUI.UGUIAdapter.ComponentType
binding = CS.XUUI.UGUIAdapter.Binding
variabletype = CS.VariableType

createbinding = function(cmpttype, cmpt, bindto, multifields)
    local binding = binding()
    binding.Type = cmpttype
    binding.Component = cmpt
    binding.BindTo = bindto
    binding.MultiFields = multifields
    return binding
end

checkslpriorityvalid = function(id)
    if id == nil or type(id) ~= "number" then
        return false
    end
    for k, v in pairs(sortlayerpriority) do
        if v == id then
            return true
        end
    end
    return false
end
