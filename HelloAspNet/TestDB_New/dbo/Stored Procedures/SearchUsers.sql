--DeleteUsers 2


--[6] 검색 저장 프로시저
Create Proc dbo.SearchUsers
	@SearchField NVarChar(25),
	@SearchQuery NVarChar(25)
As
	Declare @strSql NVarChar(255)
	Set @strSql = '
		Select * From Users 
		Where 
			' + @SearchField + ' Like ''%' + @SearchQuery + '%''
	'
	-- Print @strSql
	Exec(@strSql)