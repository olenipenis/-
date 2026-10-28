-- Таблица: Category (категория товара)
CREATE TABLE dbo.Category (
    Id          INT IDENTITY(1,1) NOT NULL,
    Name        NVARCHAR(100) NOT NULL,
    ParentId    INT NULL,
    CONSTRAINT PK_Category PRIMARY KEY (Id),
    CONSTRAINT FK_Category_Parent
        FOREIGN KEY (ParentId) REFERENCES dbo.Category(Id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);
GO

-- Таблица: Product (товар)
CREATE TABLE dbo.Product (
    Id          INT IDENTITY(1,1) NOT NULL,
    Name        NVARCHAR(200) NOT NULL,
    Price       DECIMAL(10,2) NOT NULL,
    Description NVARCHAR(1000) NULL,
    CategoryId  INT NOT NULL,
    CONSTRAINT PK_Product PRIMARY KEY (Id),
    CONSTRAINT FK_Product_Category
        FOREIGN KEY (CategoryId) REFERENCES dbo.Category(Id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);
GO

-- Таблица: Buyer (покупатель)
CREATE TABLE dbo.Buyer (
    CardNumber VARCHAR(20) NOT NULL,
    Phone      VARCHAR(20) NOT NULL,
    Name       NVARCHAR(100) NULL,
    BirthDate  DATE NULL,
    Cashback   DECIMAL(10,2) NOT NULL CONSTRAINT DF_Buyer_Cashback DEFAULT (0.00),
    CONSTRAINT PK_Buyer PRIMARY KEY (CardNumber)
);
GO

-- Таблица: Order (заказ)
CREATE TABLE dbo.[Order] (
    Id           INT IDENTITY(1,1) NOT NULL,
    OrderDate    DATETIME2 NOT NULL CONSTRAINT DF_Order_OrderDate DEFAULT (SYSDATETIME()),
    BuyerCard VARCHAR(20) NULL,
    CONSTRAINT PK_Order PRIMARY KEY (Id),
    CONSTRAINT FK_Order_Buyer
        FOREIGN KEY (BuyerCard) REFERENCES dbo.Buyer(CardNumber)
        ON DELETE SET NULL
        ON UPDATE NO ACTION
);
GO

-- Таблица: OrderItem (состав заказа)
CREATE TABLE dbo.OrderItem (
    OrderId   INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity  INT NOT NULL CONSTRAINT DF_OrderItem_Quantity DEFAULT (1),
    CONSTRAINT PK_OrderItem PRIMARY KEY (OrderId, ProductId),
    CONSTRAINT FK_OrderItem_Order
        FOREIGN KEY (OrderId) REFERENCES dbo.[Order](Id)
        ON DELETE CASCADE
        ON UPDATE NO ACTION,
    CONSTRAINT FK_OrderItem_Product
        FOREIGN KEY (ProductId) REFERENCES dbo.Product(Id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);
GO

-- Категории товаров (7 записей)
SET IDENTITY_INSERT dbo.Category ON;
INSERT INTO dbo.Category (Id, Name, ParentId) VALUES
    (1, N'Электроника',    NULL),
    (2, N'Смартфоны',      1),
    (3, N'Ноутбуки',       1),
    (4, N'Одежда',         NULL),
    (5, N'Мужская одежда', 4),
    (6, N'Женская одежда', 4),
    (7, N'Книги',          NULL);
SET IDENTITY_INSERT dbo.Category OFF;
GO

-- Товары (9 записей)
SET IDENTITY_INSERT dbo.Product ON;
INSERT INTO dbo.Product (Id, Name, Price, Description, CategoryId) VALUES
    (1, N'iPhone 15',          89990.00, N'Смартфон Apple, 128 ГБ, чёрный',  2),
    (2, N'Samsung Galaxy S24', 74990.00, N'Смартфон Samsung, 256 ГБ, серый', 2),
    (3, N'MacBook Air M3',    129990.00, N'Ноутбук Apple, 13", 8/256 ГБ',     3),
    (4, N'Lenovo IdeaPad 5',   54990.00, NULL,                                 3),
    (5, N'Футболка хлопковая',  1490.00, N'Мужская футболка, размер M',        5),
    (6, N'Джинсы классические', 3990.00, N'Мужские джинсы, размер 32',         5),
    (7, N'Платье летнее',       4590.00, N'Женское платье, размер S',           6),
    (8, N'Война и мир',         1290.00, N'Л.Н. Толстой, 2 тома',              7),
    (9, N'Чистый код',          2490.00, N'Роберт Мартин, изд. Питер',         7);
SET IDENTITY_INSERT dbo.Product OFF;
GO

-- Покупатели (6 записей)
INSERT INTO dbo.Buyer (CardNumber, Phone, Name, BirthDate, Cashback) VALUES
    ('1000-0001', '+7-900-111-22-33', N'Иван Петров',    '1990-05-12', 1250.50),
    ('1000-0002', '+7-900-222-33-44', N'Мария Иванова',  '1985-11-03',  860.00),
    ('1000-0003', '+7-900-333-44-55', NULL,              NULL,            0.00),
    ('1000-0004', '+7-900-444-55-66', N'Алексей Смирнов','2000-02-28',  430.75),
    ('1000-0005', '+7-900-555-66-77', N'Ольга Кузнецова','1995-07-19', 2100.00),
    ('1000-0006', '+7-900-666-77-88', NULL,              '1988-09-01',  150.00);
GO

-- Заказы (6 записей, часть — гостевые)
SET IDENTITY_INSERT dbo.[Order] ON;
INSERT INTO dbo.[Order] (Id, OrderDate, BuyerCard) VALUES
    (1, '2024-11-01T10:15:00', '1000-0001'),
    (2, '2024-11-03T14:40:00', '1000-0002'),
    (3, '2024-11-05T09:05:00', NULL),
    (4, '2024-11-07T18:22:00', '1000-0004'),
    (5, '2024-11-10T12:00:00', '1000-0005'),
    (6, '2024-11-12T20:45:00', '1000-0001');
SET IDENTITY_INSERT dbo.[Order] OFF;
GO

-- Состав заказов (10 записей)
INSERT INTO dbo.OrderItem (OrderId, ProductId, Quantity) VALUES
    (1, 1, 1),
    (1, 8, 2),
    (2, 3, 1),
    (2, 9, 1),
    (3, 5, 3),
    (4, 2, 1),
    (4, 6, 1),
    (5, 7, 2),
    (5, 4, 1),
    (6, 9, 2);
GO