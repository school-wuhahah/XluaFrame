--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-16 09:52:02
]]
local panel2 = {}

panel2.panelpath = "Panel2"

panel2.luauiview = nil
panel2.gameobj = nil

function panel2:init(canvasobj, viewbinding)
    local panel2pb = loadasset(typeof(CS.UnityEngine.GameObject), self.panelpath)
    self.gameobj = newgameobject(panel2pb, canvasobj.transform) 
    self.luauiview = self.gameobj:AddComponent(typeof(CS.LuaUIView))
    self.luauiview.luascriptpath = "panel2"

    local array = CS.VariableArray()
    local textcmpt = findcompent(self.gameobj.transform, "Tip", typeof(CS.UnityEngine.UI.Text))
    array:AddVariable("textcmpt", variabletype.Component, textcmpt)
    local btncmpt = findcompent(self.gameobj.transform, "Button", typeof(typeof(CS.UnityEngine.UI.Button)))
    array:AddVariable("btncmpt", variabletype.Component, btncmpt)
    local dropdowncmpt = findcompent(self.gameobj.transform, "Dropdown", typeof(CS.UnityEngine.UI.Dropdown))
    array:AddVariable("dropdowncmpt", variabletype.Component, dropdowncmpt)
    local inputfieldcmpt = findcompent(self.gameobj.transform, "InputField", typeof(CS.UnityEngine.UI.InputField))
    array:AddVariable("inputfieldcmpt", variabletype.Component, inputfieldcmpt)
    self.luauiview.variableArray = array

    viewbinding:AddBinding(createbinding(componenttype.Text, textcmpt, "module2.info", false))
    viewbinding:AddBinding(createbinding(componenttype.Button, btncmpt, "module2.click", false))
    viewbinding:AddBinding(createbinding(componenttype.Dropdown, dropdowncmpt, "module2.select", false))
    viewbinding:AddBinding(createbinding(componenttype.InputField, inputfieldcmpt, "module2.message", false))
end


function panel2:start()
    print("panel1 start .... ")
end

return panel2