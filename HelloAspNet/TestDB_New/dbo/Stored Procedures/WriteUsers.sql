--[User][0][2] Users 관련 저장 프로시저 생성

--[1] 입력 저장 프로시저
Create Proc dbo.WriteUsers
	@UserID NVarChar(25),
	@Password NVarChar(20)
As
	Insert Into Users Values(@UserID, @Password)