--User
INSERT INTO [Shop].[dbo].[User]  ([Name], [Lastname], [Patronymic], [EMail], [Password],[Phone]) 
	VALUES (N'Ivan', N'Bogush', N'Olegovich', N'bogushI@mail.ru', CONVERT(binary,N'q1w2e3r4'),N'89963462537')
INSERT INTO [Shop].[dbo].[User]   ([Name], [Lastname], [Patronymic], [EMail], [Password],[Phone]) 
	VALUES (N'Oleg', N'Nesterov', N'Ivanovich', N'nesterovO@mail.ru', CONVERT(binary,N'q1w2e3r4'),N'89873462537')
INSERT INTO [Shop].[dbo].[User]   ([Name], [Lastname], [Patronymic], [EMail], [Password],[Phone]) 
	VALUES (N'Artem', N'Agapov', N'Erikovich', N'agapovE@mail.ru', CONVERT(binary,N'agapov123'),N'89913462537')
INSERT INTO [Shop].[dbo].[User]    ([Name], [Lastname], [Patronymic], [EMail], [Password],[Phone]) 
	VALUES (N'Nikita', N'Petrov', N'Dmitrievich', N'petrovN@gmail.com', CONVERT(binary,N'gryJys'),N'89193462537')
INSERT INTO [Shop].[dbo].[User]  ([Name], [Lastname], [Patronymic], [EMail], [Password],[Phone]) 
	VALUES (N'Artem', N'Elmolaev', N'Erikovich', N'elrmolaev@gmail.com', CONVERT(binary,N'alex1997'),N'89093462534')
INSERT INTO [Shop].[dbo].[User]  ([Name], [Lastname], [Patronymic], [EMail], [Password],[Phone]) 
	VALUES (N'Alex', N'Popov', N'Erikovich', N'Admin@mail.ru', CONVERT(binary,N'admin'),N'89093462537')

--City
INSERT INTO [Shop].[dbo].[City]  ( [NameCity]) VALUES ( N'Saratov')
INSERT INTO [Shop].[dbo].[City]  ( [NameCity]) VALUES ( N'Moscow')
INSERT INTO [Shop].[dbo].[City]  ( [NameCity]) VALUES ( N'Kazan')
INSERT INTO [Shop].[dbo].[City]  ( [NameCity]) VALUES ( N'Balakovo')

--Shop
INSERT INTO [Shop].[dbo].[Shop]  ( [NameShop], [Address], [IDCity], [Website], [DescriptionShop], [PhoneShop], [OpeningHours]) VALUES (N'Mango',N'Kirov street',1, N'mango.ru', N'Clothing',543344,N'9:00-21:00')
INSERT INTO [Shop].[dbo].[Shop]  ( [NameShop], [Address], [IDCity], [Website], [DescriptionShop], [PhoneShop], [OpeningHours]) VALUES ( N'Dns', N'Leninsky Hills', 1,N'dns.ru',N'Digital',232342,N'10:00-19:00')
INSERT INTO [Shop].[dbo].[Shop]  ( [NameShop], [Address], [IDCity], [Website], [DescriptionShop], [PhoneShop], [OpeningHours]) VALUES ( N'Walmart', N'ul. The Kremlin 18', 3, N'walmart.ru',N'Department store',864422,N'24 hours')
INSERT INTO [Shop].[dbo].[Shop]  ( [NameShop], [Address], [IDCity], [Website], [DescriptionShop], [PhoneShop], [OpeningHours]) VALUES ( N'Benefit', N'ul. Karl Marx, 29', 4, N'benefit.ru',N'Beauty',348756,N'10:00-19:00')

--CONVERT(binary,N'iVBORw0KGgoAAAANSUhEUgAAAyAAAAKKCAIAAABK4qgDAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNS1jMDIxIDc5LjE1NTc3MiwgMjAxNC8wMS8xMy0xOTo0NDowMCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6MzAxNTE5RjhEQjg0MTFFNDhFOTJDMTUwNjhFQUE1RkEiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6MzAxNTE5RjdEQjg0MTFFNDhFOTJDMTUwNjhFQUE1RkEiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTQgKFdpbmRvd3MpIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6RTk2MjcwRkNCQzUzMTFFNEE2N0FERjQ2NDg5MDEyNDMiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6RTk2MjcwRkRCQzUzMTFFNEE2N0FERjQ2NDg5MDEyNDMiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz46CkcGAAAmjklEQVR42uzd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')

--Role
INSERT INTO [Shop].[dbo].[Role]  ([Id], [DescriptionRole]) 
	VALUES (1, 'Admin')
INSERT INTO [Shop].[dbo].[Role]  ([Id], [DescriptionRole]) 
	VALUES (2, 'Moderator')
INSERT INTO [Shop].[dbo].[Role]  ([Id], [DescriptionRole]) 
	VALUES (3, 'Customer')

--UserRole
INSERT INTO [Shop].[dbo].[UserRole]  ([IdUser], [IdRole]) 
	VALUES (1, 1)
INSERT INTO [Shop].[dbo].[UserRole]  ([IdUser], [IdRole]) 
	VALUES (2, 2)
INSERT INTO [Shop].[dbo].[UserRole]  ([IdUser], [IdRole]) 
	VALUES (3, 2)
INSERT INTO [Shop].[dbo].[UserRole]  ([IdUser], [IdRole]) 
	VALUES (4, 3)
INSERT INTO [Shop].[dbo].[UserRole]  ([IdUser], [IdRole]) 
	VALUES (5, 3)

--Rating
INSERT INTO [Shop].[dbo].[Rating]  ([IDUser], [IDShop],[Rating]) 
	VALUES (1, 1, 3)
INSERT INTO [Shop].[dbo].[Rating]  ([IDUser], [IDShop],[Rating]) 
	VALUES (1, 2, 4)
INSERT INTO [Shop].[dbo].[Rating]  ([IDUser], [IDShop],[Rating]) 
	VALUES (1, 3, 3)
INSERT INTO [Shop].[dbo].[Rating]  ([IDUser], [IDShop],[Rating]) 
	VALUES (2, 3, 4)
INSERT INTO [Shop].[dbo].[Rating]  ([IDUser], [IDShop],[Rating]) 
	VALUES (3, 1, 5)
INSERT INTO [Shop].[dbo].[Rating]  ([IDUser], [IDShop],[Rating]) 
	VALUES (4, 1, 5)

--Comment
INSERT INTO [Shop].[dbo].[Comment]  ([IDUser], [IDShop], [Text], [Date]) 
	VALUES (1, 3,N'bad',N'24-08-2018')
INSERT INTO [Shop].[dbo].[Comment]  ([IDUser], [IDShop], [Text], [Date]) 
	VALUES (1, 1,N'bad',N'11-09-2018')
INSERT INTO [Shop].[dbo].[Comment]  ([IDUser], [IDShop], [Text], [Date]) 
	VALUES (4, 1,N'excelent',N'11-09-2018')

