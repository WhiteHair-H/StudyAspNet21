--WriteUsers 'redplus', '1234'


--[2] 출력 저장 프로시저
--Create Proc dbo.ListUsers
--As
--	Select * From Users Order By UID Desc
--Go
Create Proc dbo.ListUsers
As
	Select [UID], [UserID], [Password] From Users Order By UID Desc