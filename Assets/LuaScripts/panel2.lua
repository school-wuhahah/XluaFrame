--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-16 09:52:02
]]
local panel2 = {}

panel2.viewbinding = nil

function panel2:init(viewbinding)
    self.viewbinding = viewbinding
end

function panel2:Binding()
    if not self.viewbinding then
        return
    end

    self.viewbinding:AddBinding(CreateBinding(ComponentType.Text, self.textcmpt, "module2.info", false))
    self.viewbinding:AddBinding(CreateBinding(ComponentType.Button, self.btncmpt, "module2.click", false))
    self.viewbinding:AddBinding(CreateBinding(ComponentType.Dropdown, self.dropdowncmpt, "module2.select", false))
    self.viewbinding:AddBinding(CreateBinding(ComponentType.InputField, self.inputfieldcmpt, "module2.message", false))

    print("initpanel2 bind success ... ")
end

function panel2:start()
    print("panel1 start .... ")
    self:Binding()
end

return panel2