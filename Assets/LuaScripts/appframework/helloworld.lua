--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2019-12-26 13:27:51
]]
return {
    data = {
        info = {
            name = 'John',
        },
    },
    computed = {
        message = function(data)
            return 'Hello ' .. data.info.name .. '!'
        end
    },
    commands = {
        click = function(data)
            print(data.info.name)
        end,
    },
}