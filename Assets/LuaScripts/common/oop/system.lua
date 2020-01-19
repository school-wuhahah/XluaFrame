--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-10 10:47:21
]]

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
        error('the super is not supported in the "class()" function,cannot extends a c# instance multiple times.')
    end

    if isCSharpInstance then
        cls.super = super
        cls.__type = 2
        cls.base = function(self)
            if not rawget(cls, "__base") then
                local base_meta = {}
                local instance_meta = getmetatable(self)
                local original_indexer = instance_meta.__original_indexer
                base_meta.__index = function(t, k)
                    return original_indexer(self, k)
                end
                cls.__base = setmetatable({}, base_meta)
            end
            return cls.__base
        end
        return extends(super, cls)
    elseif isCSharpType and (not super.__type or super.__type == 1) then
        cls.super = super
        cls.__type = 1
        if not super.__create then
            cls.__create = function(...)
                return super(...)
            end
        end
        cls.base = function(self)
            if not rawget(cls, "__base") then
                local base_meat = {}
                base_meta.__index = function(t, k)
                    local ret = super[k]
                    if ret then
                        return ret
                    end
                    local instance_meta = getmetatable(self)
                    local original_indexer = instance_meta.__original_indexer
                    return original_indexer(self, k)
                end
                cls.__base = setmetatable({}, base_meta)
            end
            return cls.__base
        end
        setmetatable(
            cls,
            {
                __index = super,
                __call = function(t, ...)
                    local instance = t.__create(...)
                    extends(instance, t)
                    instance:ctor(...)
                    return instance
                end
            }
        )
        if not cls.ctor then
            cls.ctor = function(...)
            end
        end
        return cls
    elseif superType == "function" or (super and super.__type == 3) then
        cls.super = nil
        cls.__type = 3

        cls.base = function(self)
            if not rawget(cls, "__base") then
                local base_meta = {}
                base_meta.__index = function(t, k)
                    if superType == "table" then
                        local ret = super[k]
                        if ret then
                            return ret
                        end
                    end
                    local instance_meta = getmetatable(self)
                    local original_indexer = instance_meta.__original_indexer
                    return original_indexer(self, k)
                end
                cls.__base = setmetatable({}, base_meta)
            end
            return cls.__base
        end

        if superType == "table" then
            cls.__create = super.__create
            cls.super = super

            setmetatable(
                cls,
                {
                    __index = superType,
                    __call = function(t, ...)
                        local instance = t.__create(...)
                        extends(instance, t)
                        instance:ctor(...)
                        return instance
                    end
                }
            )
        else
            cls.__create = super
            cls.ctor = function(...)
            end
            setmetatable(
                cls,
                {
                    __call = function(t, ...)
                        local instance = t.__create(...)
                        extends(instance, t)
                        instance:ctor(...)
                        return instance
                    end
                }
            )
        end
        if not cls.ctor then
            cls.ctor = function(...)
            end
        end
        return cls
    else
        --继承lua对象
        cls.__type = 0
        cls.super = super
        cls.__index = cls
        cls.new = function(...)
            local instance = setmetatable({}, cls)
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
        return cls
    end
end

--@desc 扩展一个userdata实例
--@target: userdata target 要扩展的目标对象
--@cls: table cls 初始化表，初始化成员变量和方法
function extends(target, cls)
    if type(target) ~= "userdata" then
        error("the target is not userdata.")
    end
    local meta = {}
    if cls then
        setmetatable(meta, {__index = cls})
    end
    local original_meta = getmetatable(target)
    local original_indexer = original_meta.__index
    local original_newindexer = original_meta.__newindex
    for k, v in pairs(original_meta) do
        rawset(meta, k, v)
    end
    meta.__original_indexer = original_meta
    meta.__original_newindexer = original_newindexer
    meta.__index = function(t, k)
        return meta[k] or original_indexer(t, k)
    end
    meta.__newindex = function(t, k, v)
        if rawget(meta, k) ~= nil then
            rawset(meta, k, v)
        else
            local success, err = pcall(original_newindexer, t, k, v)
            if not success then
                if err:sub(-13) == "no such field" then
                    rawset(meta, k, v)
                else
                    error(err)
                end
            end
        end
    end
    meta.__call = function(...)
        error(string.format("Unsupported operation, this is an instance of the '%s' class.", meta.__name))
    end
    debug.setmetatable(target, meta)
    return meta
end
