--ModifyUsers 'master', '1234', 2


--[5] 삭제 저장 프로시저
Create Proc dbo.DeleteUsers
	@UID Int
As
	Delete Users Where UID = @UID