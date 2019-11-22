use Students

go
CREATE PROCEDURE [dbo].NameUpdate
	@Id int,
	@LastName nvarchar(50)
AS
UPDATE Persons SET LastName = @LastName WHERE Id = @Id;