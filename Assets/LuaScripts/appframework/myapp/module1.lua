
return {
    data = {
        name = "haha", 
        select = 0, 
    },
    
    commands = {
        click = function(data)
            module2.set_select(data.select)
            data.select = data.select == 0 and 1 or 0 
        end,
    },
    
    computed = {
        info = function(data)
            return string.format('i am %s, my select is %d', data.name, data.select)
        end,
    },
    
    exports = {
        hello = function(p) 
            print('hello model1, p = '.. p)
        end,
    },
}
