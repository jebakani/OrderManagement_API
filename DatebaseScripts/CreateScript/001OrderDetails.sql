Create Database OrderManagement
use [OrderManagement]
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='OrderDetail')
	CREATE TABLE [dbo].[OrderDetail](
		[OrderId] [int] IDENTITY(1,1) NOT NULL,
		[OrderNumber] [uniqueidentifier] NULL,
		[OrderDate] [datetime] NULL,
		[VendorId] [int] NULL,
		[ShopId] [int] NULL,		
		[CreatedOn] [datetime] NULL,
		[ModifiedOn] [datetime] NULL,
		[CreatedBy] [int] NULL,
		[ModifiedBy] [int] NULL,		
	PRIMARY KEY CLUSTERED 
	(
		[OrderId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO