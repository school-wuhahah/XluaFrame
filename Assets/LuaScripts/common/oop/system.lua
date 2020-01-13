--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-10 10:47:21
]]

-- local classtype = {
--     class = 1,
--     instance = 2,
-- }

function class(classname, super)
    assert(type(classname) == "string" and string.len(classname) > 0)
    
    local superType = type(super)
    local isCSharpType = super and superType == "table" and typeof(super)
    local isCSharpInstance = super and superType == "userdata"

	local cls = {}
	cls.__classname = classname
    cls.__class = cls

    if isCSharpInstance and super.__type == 2 then
        --不允许多次扩展一个C#的实例
		error("the super is not supported in the \"class()\" function,cannot extends a c# instance multiple times.")
    end

    if isCSharpInstance then
        
    elseif isCSharpType and (not super.__type or super.__type == 1) then
    elseif superType == "function" or (super and super.__type == 3) then

    else
        --继承lua对象
        cls.__type = 0
        cls.super = super
        cls.__index = cls
        cls.new = function(t, ...)
            local instance = setmetatable({}, t)
            instance:ctor(...)
            return instance
        end

        if super then
            cls.base = function(self)
                return cls.super
            end
            setmetatable(cls, {__index = super, __call = cls.new})
        else
            setmetatable(cls, {__call = cls.new})
        end

        if not cls.ctor then
            cls.ctor = function(...)
            end
        end
    end
    
end