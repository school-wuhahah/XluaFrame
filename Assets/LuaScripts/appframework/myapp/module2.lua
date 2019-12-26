local data = {
    message = "hehe",
    select = 1,
}
    
return {
    data = data,
    
    commands = {
        click = function(data)
            module1.hello(1)
            data.select = data.select == 0 and 1 or 0
        end,
    },
    
    computed = {
        info = function(data)
            return string.format('message is %s, select is %d', data.message, data.select)
        end,
    },
    
    exports = {
        set_select = function(p)
            data.select = p
        end,
    },
}
