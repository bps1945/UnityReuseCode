﻿print('Lua访问特性标记的对象方法')
            local luaM2 = CS.CSModelWithAttribute
            local luaO2 = luaM2()
            luaM2:SayHello1()
            luaO2:SayHello2()
            luaO2:SayHello3('我是阿拉丁')  --读者反馈新增一个C#方法 PC不需要重新 Generate，安卓、ios需要

            --测试字符串返回
            local value = luaO2:SayHello4('你好，我是lua')
            print(value)                              

            --测试ref
            local inputValue = '你好，我是lua'
            local outputValue = luaO2:SayHelloWithRefParam(inputValue)
            print(outputValue)                          --lua是通过字符串返回

            local outValue1,outValue2 = luaO2:SayHelloWithRefParamAndReturnString(inputValue)
            print(outValue1)
            print(outValue2)

            --测试out
            inputValue = '我是测试lua'
            outputValue = luaO2:SayHelloWithOutParam(inputValue)
            print(outputValue)




print('Lua访问有命名空间的对象/静态方法')
local luaModel = CS.Aladdin_XLua.CSModel
local luaObj = luaModel()
luaObj:SayHello()



            local luaM3 = CS.CSModelTest
            local luaO3 = luaM3()
            luaO3.TestDelegate('lua中测试委托')

            luaO3.onClick = function(obj)
                print('hello 我是lua')
                print(obj)
            end
            luaO3.onClick('我是lua')

