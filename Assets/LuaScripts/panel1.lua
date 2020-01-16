--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-16 09:52:02
]]
local panel1 = {}

panel1.viewbinding = nil

function panel1:init(viewbinding)
    self.viewbinding = viewbinding
end

function panel1:Binding()
    if not self.viewbinding then
        return
    end

    self.viewbinding:AddBinding(CreateBinding(ComponentType.Text, self.textcmpt, "module1.info", false))
    self.viewbinding:AddBinding(CreateBinding(ComponentType.Button, self.btncmpt, "module1.click", false))
    self.viewbinding:AddBinding(CreateBinding(ComponentType.Dropdown, self.dropdowncmpt, "module1.select", false))
    self.viewbinding:AddBinding(CreateBinding(ComponentType.InputField, self.inputfieldcmpt, "module1.name", false))
    print("initpanel1 bind success ... ")
end

function panel1:start()
    print("panel1 start .... ")
    self:Binding()
end

return panel1