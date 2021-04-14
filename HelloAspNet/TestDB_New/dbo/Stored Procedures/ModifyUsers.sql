--ViewUsers 5


--[4] 수정 저장 프로시저
Create Proc dbo.ModifyUsers
	@UserID NVarChar(25),
	@Password NVarChar(20),
	@UID Int
As
	Begin Tran
		Update Users
		Set	
			UserID = @UserID,
			[Password] = @Password
		Where UID = @UID
	Commit Tran