/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [OrderId]
      ,[UserId]
      ,[OrderDate]
      ,[Status]
      ,[PO]
  FROM [OBG_].[dbo].[Order]