--ListUsers


--[3] 상세 저장 프로시저
Create Proc dbo.ViewUsers
	@UID Int
As
	Select [UID], [UserID], [Password] From Users Where UID = @UID