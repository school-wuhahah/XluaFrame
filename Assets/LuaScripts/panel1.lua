--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-16 09:52:02
]]
local panel1 = {}

panel1.panelpath = "Panel1"

panel1.luauiview = nil
panel1.gameobj = nil

function panel1:init(canvasobj, viewbinding)

    local panel1pb = loadasset(typeof(CS.UnityEngine.GameObject), self.panelpath)
    self.gameobj = newgameobject(panel1pb, canvasobj.transform) 
    self.luauiview = self.gameobj:AddComponent(typeof(CS.LuaUIView))
    self.luauiview.luascriptpath = "panel1"

    local array = CS.VariableArray()
    local textcmpt = findcompent(self.gameobj.transform, "Tip", typeof(CS.UnityEngine.UI.Text))
    array:AddVariable("textcmpt", variabletype.Component, textcmpt)
    local btncmpt = findcompent(self.gameobj.transform, "Button", typeof(CS.UnityEngine.UI.Button))
    array:AddVariable("btncmpt", variabletype.Component, btncmpt)
    local dropdowncmpt = findcompent(self.gameobj.transform, "Dropdown", typeof(CS.UnityEngine.UI.Dropdown))
    array:AddVariable("dropdowncmpt", variabletype.Component, dropdowncmpt)
    local inputfieldcmpt = findcompent(self.gameobj.transform, "InputField", typeof(CS.UnityEngine.UI.InputField))
    array:AddVariable("inputfieldcmpt", variabletype.Component, inputfieldcmpt)
    self.luauiview.variableArray = array
    
    viewbinding:AddBinding(createbinding(componenttype.Text, textcmpt, "module1.info", false))
    viewbinding:AddBinding(createbinding(componenttype.Button, btncmpt, "module1.click", false))
    viewbinding:AddBinding(createbinding(componenttype.Dropdown, dropdowncmpt, "module1.select", false))
    viewbinding:AddBinding(createbinding(componenttype.InputField, inputfieldcmpt, "module1.name", false))
end

function panel1:start()
    print("panel1 start .... ")
end

return panel1