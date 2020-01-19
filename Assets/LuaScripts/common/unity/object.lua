--[[
    luaide  模板位置位于 Template/FunTemplate/NewFileTemplate.lua 其中 Template 为配置路径 与luaide.luaTemplatesDir
    luaide.luaTemplatesDir 配置 https://www.showdoc.cc/web/#/luaide?page_id=713062580213505
    author:{author}
    time:2020-01-17 16:01:34
]]

--@desc 检测unity对象是否为null
--@unity_object: unity对象
function isnull(unity_object)
    if unity_object == nil then
        return true
    end
    if type(unity_object) == "userdata" and unity_object.IsNull ~= nil then
        return unity_object:IsNull()
    end
    return false
end

--@desc 加载预制体资源
--@unity_type: 资源类型
--@pb_path: 资源路径
function loadasset(unity_type, pb_path)
    local asset = nil
    if not isnull(unity_type) and pb_path ~= nil then
        asset = CS.Asset.Load(pb_path, unity_type)
        return asset
    end
    return asset
end

--@desc 实例化unity对象
--@assetpb: 预制体资源
function newgameobject(assetpb, parenttf)
    if not isnull(assetpb) then
        return CS.UnityEngine.Object.Instantiate(assetpb, parenttf)
    end
end

--@desc 递归查找unity对象transform
--@roottf: 根节点的transform
--@name: 节点名称
function findtransform(roottf, name)
    if isnull(roottf) or not name then
        return nil
    end
    local child = roottf:Find(name)
    if not isnull(child) then
        return child
    end
    local go = nil
    for i = 0, roottf.childCount - 1 do
        local child = roottf:GetChild(i)
        go = findtransform(child, name)
        if not isnull(go) then
            return go
        end
    end
    return nil
end

--@desc 递归查找unity对象组件
--@roottf: 根节点的transform
--@name: 节点名称
--@utype: 组件类型
function findcompent(roottf, name, utype)
    local tgtf = findtransform(roottf, name)
    if isnull(tgtf) then
        return nil
    end
    if utype == nil or utype == typeof(CS.UnityEngine.Transform) then
        return tgtf
    end
    return tgtf:GetComponent(utype)
end

--@desc 将obj与func封在一起
--@obj: obj
--@func: 函数
function handler(obj, func)
    return function(...)
        return func(obj, ...)
    end
end
