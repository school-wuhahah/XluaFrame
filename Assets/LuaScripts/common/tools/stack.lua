--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-10 09:28:54
]]

local stack = {}
stack.__index = stack

function stack:new()
    local t = {stack_table = {}, count = 0}
    return setmetatable(t, stack)
end

function stack:clear()
    self.count = 0
    self.stack_table = {}
end

function stack:push(value)
    self.count = self.count + 1
    table.insert(self.stack_table, value)
end

function stack:pop()
    self.count = math.max(0, self.count - 1)
    return table.remove(self.stack_table)
end

function stack:peek()
    return self.stack_table[#self.stack_table]
end

function stack:contains(value)
    for k, v in pairs(self.stack_table) do
        if v == value then
            return true
        end
    end
    return false
end

setmetatable(stack, {__call = stack.new})

return stack