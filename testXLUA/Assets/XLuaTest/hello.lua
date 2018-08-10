







print('asdfasdf!!!!')

--function fuckNewFunction(self)
	--CS.UnityEngine.GameObject.Instantiate(self.thePrefab);
--end

function fuckNewFunction(self)
	self:ShowResult();
	print(self.theIntHehe.Length)
end


xlua.private_accessible(CS.LuaTestController)

--xlua.hotfix(CS.LuaTestController, 'ShowResult',fuckNewFunction );

local util=require 'util';
util.hotfix_ex(CS.LuaTestController, 'ShowResult', fuckNewFunction)

print(CS.UnityEngine.Time.deltaTime)
print(CS.UnityEngine.Time.deltaTime)
print(CS.UnityEngine.Time.deltaTime)