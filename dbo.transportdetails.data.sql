SET IDENTITY_INSERT [dbo].[transportdetails] ON
INSERT INTO dbo.TransportDetails (Name, Phone, Address, Email, VehicleType, LoadType, AvailableDate)
VALUES ('John Doe', '1234567890', '123 Main St', 'john.doe@example.com', 'Heavy', 'Soft Goods', '2024-10-16');
SET IDENTITY_INSERT TransportDetails ON;
