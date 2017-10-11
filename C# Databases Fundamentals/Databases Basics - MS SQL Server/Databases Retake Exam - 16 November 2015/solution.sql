USE PhotographySystem
GO

-- 1.Album's name and description
SELECT
  a.Name,
  ISNULL(a.[Description], 'No description') AS [Description]
FROM
  Albums AS a
ORDER BY 
  a.Name ASC

-- 2. Albums and photographs
SELECT
  p.Title,
  a.Name
FROM
  Albums AS a
  JOIN AlbumsPhotographs AS ab ON a.Id = ab.AlbumId
  JOIN Photographs AS p ON ab.PhotographId = p.Id
ORDER By
  a.Name ASC,
  p.Title DESC

-- 3.Photographs with Category and Author
SELECT
  p.Title,
  p.Link,
  p.[Description],
  c.Name AS CategoryName,
  u.FullName AS Author
FROM
  Photographs AS p
  JOIN Categories AS c ON p.CategoryId = c.Id
  JOIN Users AS u ON p.UserId = u.Id
WHERE
  p.[Description] IS NOT NULL
ORDER BY
  p.Title ASC

-- 4.Users Born is January
SELECT
  u.Username,
  u.FullName,
  u.BirthDate,
  ISNULL (p.Title, 'No photos') AS Photo
FROM
  Users AS u
  LEFT JOIN Photographs AS p ON p.UserId = u.Id 
WHERE 
  MONTH(u.BirthDate) = 1
ORDER BY
  u.FullName ASC

-- 5.Photographs with Equipment
SELECT  
  p.Title, 
  c.Model AS CameraModel, 
  l.Model AS LensModel
FROM 
  Photographs AS p
  JOIN Equipments AS e ON p.EquipmentId = e.Id
  JOIN Cameras AS c ON e.CameraId = c.Id
  JOIN Lenses AS l ON e.LensId = l.Id
ORDER BY 
  p.Title ASC

-- 6.Most expensive photo per category
SELECT
  p.Title,
  c.Name as [Category Name],
  cm.Model,
  m.Name [Manufacturer Name],
  cm.Megapixels,
  cm.Price
FROM
  Photographs AS p
  JOIN Categories AS c ON p.CategoryId = c.Id
  JOIN Equipments AS e ON p.EquipmentId = e.Id
  JOIN Cameras AS cm ON e.CameraId = cm.Id
  JOIN Manufacturers AS m ON cm.ManufacturerId = m.Id
WHERE
  cm.Price = (SELECT
                MAX(cm1.Price)
			  FROM
			    Cameras AS cm1
				JOIN Equipments AS e1 ON cm1.Id = e1.CameraId
				JOIN Photographs AS p1 ON e1.Id = p1.EquipmentId
			  WHERE
			    p1.CategoryId = p.CategoryId)
ORDER BY 
  cm.Price DESC,
  p.Title ASC


-- 7. Camera where price is larger than the average
SELECT
  m.Name,
  c.Model,
  c.Price
FROM
  Manufacturers AS m
  JOIN Cameras AS c ON c.ManufacturerId = m.Id
WHERE 
  c.Price > (SELECT
		       AVG(cm1.Price)
			 FROM
			   Cameras AS cm1
			 WHERE 
			   cm1.Price IS NOT NULL)
ORDER BY
  c.Price DESC,
  c.Model ASC

-- 8.Total price
SELECT DISTINCT
  m.Name,
  (SELECT
     SUM(l1.Price)
   FROM
     Lenses AS l1
	 JOIN Manufacturers AS m1 ON l1.ManufacturerId = m1.Id
	WHERE 
	  m1.Id = m.Id AND
	  l1.Price IS NOT NULL) AS [Total Price]
FROM
  Manufacturers AS m
  JOIN Lenses AS l ON m.Id = l.ManufacturerId
ORDER BY
  m.Name ASC

-- 9.Users with old cameras
SELECT
  u.FullName,
  m.Name AS Manufacturer,
  c.Model AS [Camera Model],
  c.Megapixels
FROM
  Users AS u
  JOIN Equipments AS e ON u.EquipmentId = e.Id
  JOIN Cameras AS c ON e.CameraId = c.Id
  JOIN Manufacturers AS m ON c.ManufacturerId = m.Id
WHERE
  c.[Year] < 2015
ORDER BY
  u.FullName

-- 10.Count lenses
SELECT
  l.[Type],
  COUNT(l.Id) AS [Count]
FROM
  Lenses AS l
GROUP BY
  l.[Type]
ORDER BY 
  [Count] DESC,
  [Type] ASC

-- 11. Sort users
SELECT
  u.Username,
  u.FullName
FROM
  Users AS u
ORDER BY
  LEN(CONCAT(u.FullName, u.UserName)) ASC,
  u.BirthDate DESC

-- 12. Manufacturers without products
SELECT
  m.Name
FROM
  Manufacturers AS m
WHERE
  m.Id NOT IN (SELECT l.ManufacturerId FROM Lenses AS l) AND
  m.Id NOT IN (SELECT c.ManufacturerId FROM Cameras AS c)
ORDER BY
  m.Name ASC

-- 13. Cameras rise!
UPDATE 
	c
SET 
	c.Price = 
		c.Price + 
			(
				(SELECT AVG(Price) FROM Cameras WHERE ManufacturerId = c.ManufacturerId) 
					* (
						(SELECT LEN(Name)/100.00 FROM Manufacturers WHERE Id = c.ManufacturerId)
					  )
			)
FROM
	Cameras c

SELECT rs.Model,rs.Price,rs.ManufacturerId 
FROM (
    SELECT Model,Price,ManufacturerId, Rank() 
        over (Partition BY ManufacturerId
            ORDER BY Price DESC ) AS Rank
    FROM Cameras
    ) rs WHERE Rank <= 3 AND Price IS NOT NULL


-- 14. Most cameras for given cash
DECLARE @T TABLE(Id Int, ManufacturerId int, Model nvarchar(max), Year int, Price money, Megapixels int)
DECLARE @Money money = 54187
DECLARE CUR CURSOR FOR SELECT Id, ManufacturerId, Model, Year, Price, Megapixels FROM Cameras  WHERE Price IS NOT NULL ORDER BY Price ASC, Id DESC
OPEN CUR

DECLARE @Id int
DECLARE @ManId int
DECLARE @Model nvarchar(max)
DECLARE @Year int
DECLARE @Price money
DECLARE @Megapixels int

FETCH NEXT FROM CUR INTO @Id, @ManId, @Model, @Year, @Price, @Megapixels


WHILE (@Money >= 0 AND @@FETCH_STATUS = 0)
BEGIN
	IF (@Price > @Money)
		BREAK

	SET @Money = @Money - @Price

	INSERT INTO @T VALUES (@Id, @ManId, @Model, @Year, @Price, @Megapixels)
	FETCH NEXT FROM CUR INTO @Id, @ManId, @Model, @Year, @Price, @Megapixels
END

CLOSE CUR
DEALLOCATE CUR

SELECT * FROM @T ORDER BY Year DESC, ManufacturerId DESC, Id ASC

--15. Stored procedure for creating equipment
CREATE PROCEDURE dbo.usp_CreateEquipment @modelName VARCHAR(max)
AS BEGIN
    DECLARE CamerasCur CURSOR FOR SELECT Id, ManufacturerId, Model, Year, Price, Megapixels FROM Cameras WHERE Model = @modelName
    OPEN CamerasCur

	DECLARE @Id int
	DECLARE @ManId int
	DECLARE @Model nvarchar(max)
	DECLARE @Year int
	DECLARE @Price money
	DECLARE @Megapixels int

	DECLARE @MaxManId INT = 0;
	DECLARE ManCursor CURSOR FOR SELECT MAX(Id) FROM Manufacturers
	OPEN ManCursor
	FETCH NEXT FROM ManCursor INTO @MaxManId
	CLOSE ManCursor
	DEALLOCATE ManCursor

	FETCH NEXT FROM CamerasCur INTO @Id, @ManId, @Model, @Year, @Price, @Megapixels

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		DECLARE @CurrentManId INT = @ManId
		WHILE (@CurrentManId <= @MaxManId)
		BEGIN
			DECLARE LensesCurCount CURSOR FOR SELECT COUNT(*) FROM Lenses WHERE ManufacturerId = @CurrentManId
			OPEN LensesCurCount
			DECLARE @CNT int = 0
			FETCH NEXT FROM LensesCurCount INTO @CNT
			IF (@CNT <= 0)
			BEGIN
				SET @CurrentManId = @CurrentManId + 1
				CLOSE LensesCurCount
				DEALLOCATE LensesCurCount
				CONTINUE
			END
			CLOSE LensesCurCount
			DEALLOCATE LensesCurCount

			DECLARE LensesCur CURSOR FOR SELECT Id FROM Lenses WHERE ManufacturerId = @CurrentManId
			OPEN LensesCur
			DECLARE @LenseId int = 0
			FETCH NEXT FROM LensesCur INTO @LenseId

			DECLARE @ToExit BIT = 0;
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
				DECLARE @EquipExists int = 0;
				DECLARE EquipExistsCur CURSOR FOR SELECT COUNT(*) FROM Equipments WHERE CameraId = @Id AND LensId = @LenseId
				OPEN EquipExistsCur
				FETCH NEXT FROM EquipExistsCur INTO @EquipExists
				IF (@EquipExists > 0)
				BEGIN
					FETCH NEXT FROM LensesCur INTO @LenseId
					CLOSE EquipExistsCur
					DEALLOCATE EquipExistsCur
					CONTINUE
				END
				CLOSE EquipExistsCur
				DEALLOCATE EquipExistsCur

				INSERT INTO Equipments (CameraId, LensId) VALUES (@Id, @LenseId)

				SET @ToExit = 1
				FETCH NEXT FROM LensesCur INTO @LenseId
			END

			CLOSE LensesCur
			DEALLOCATE LensesCur

			IF (@ToExit > 0)
				BREAK

			SET @CurrentManId = @CurrentManId + 1
		END

		FETCH NEXT FROM CamerasCur INTO @Id, @ManId, @Model, @Year, @Price, @Megapixels
	END

	CLOSE CamerasCur
	DEALLOCATE CamerasCur
END

EXEC usp_CreateEquipment 'XG-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XG-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XG-1'
EXEC usp_CreateEquipment 'XG-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XH-1'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ2'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ2'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'XQ3'
EXEC usp_CreateEquipment 'X30'
EXEC usp_CreateEquipment 'X30'
EXEC usp_CreateEquipment 'X30'
EXEC usp_CreateEquipment 'X30'
EXEC usp_CreateEquipment 'X30'
EXEC usp_CreateEquipment 'X30'
EXEC usp_CreateEquipment 'X30'
EXEC usp_CreateEquipment 'X Vario'
EXEC usp_CreateEquipment 'X Vario'
EXEC usp_CreateEquipment 'NX30'
EXEC usp_CreateEquipment 'Alpha 7'

SELECT * FROM Equipments ORDER BY Id ASC
