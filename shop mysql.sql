-- Таблица: категория товара
CREATE TABLE category (
    id              INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    name            VARCHAR(100) NOT NULL,
    parent_id       INT UNSIGNED NULL,
    CONSTRAINT fk_category_parent
        FOREIGN KEY (parent_id) REFERENCES category(id)
        ON DELETE SET NULL
        ON UPDATE CASCADE
) ENGINE=InnoDB;

-- Таблица: товар
CREATE TABLE product (
    id              INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    name            VARCHAR(200) NOT NULL,
    price           DECIMAL(10, 2) NOT NULL,
    description     VARCHAR(1000) NULL,
    category_id     INT UNSIGNED NOT NULL,
    CONSTRAINT fk_product_category
        FOREIGN KEY (category_id) REFERENCES category(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
) ENGINE=InnoDB;

-- Таблица: покупатель
CREATE TABLE buyer (
    card_number     VARCHAR(20) PRIMARY KEY,
    phone           VARCHAR(20) NOT NULL,
    name            VARCHAR(100) NULL,
    birth_date      DATE NULL,
    cashback        DECIMAL(10, 2) NOT NULL DEFAULT 0.00
) ENGINE=InnoDB;

-- Таблица: заказ
CREATE TABLE `order` (
    id              INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    order_date      DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    buyer_card   VARCHAR(20) NULL,
    CONSTRAINT fk_order_buyer
        FOREIGN KEY (buyer_card) REFERENCES buyer(card_number)
        ON DELETE SET NULL
        ON UPDATE CASCADE
) ENGINE=InnoDB;

-- Таблица: состав заказа
CREATE TABLE order_item (
    order_id        INT UNSIGNED NOT NULL,
    product_id      INT UNSIGNED NOT NULL,
    quantity        INT UNSIGNED NOT NULL DEFAULT 1,
    PRIMARY KEY (order_id, product_id),
    CONSTRAINT fk_item_order
        FOREIGN KEY (order_id) REFERENCES `order`(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT fk_item_product
        FOREIGN KEY (product_id) REFERENCES product(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
) ENGINE=InnoDB;

-- Категории товаров (7 записей, включая подкатегории)
INSERT INTO category (id, name, parent_id) VALUES
    (1, 'Электроника',          NULL),
    (2, 'Смартфоны',            1),
    (3, 'Ноутбуки',             1),
    (4, 'Одежда',               NULL),
    (5, 'Мужская одежда',       4),
    (6, 'Женская одежда',       4),
    (7, 'Книги',                NULL);

-- Товары (9 записей)
INSERT INTO product (id, name, price, description, category_id) VALUES
    (1, 'iPhone 15',            89990.00, 'Смартфон Apple, 128 ГБ, чёрный',       2),
    (2, 'Samsung Galaxy S24',   74990.00, 'Смартфон Samsung, 256 ГБ, серый',      2),
    (3, 'MacBook Air M3',      129990.00, 'Ноутбук Apple, 13", 8/256 ГБ',         3),
    (4, 'Lenovo IdeaPad 5',     54990.00, NULL,                                   3),
    (5, 'Футболка хлопковая',    1490.00, 'Мужская футболка, размер M',           5),
    (6, 'Джинсы классические',   3990.00, 'Мужские джинсы, размер 32',            5),
    (7, 'Платье летнее',         4590.00, 'Женское платье, размер S',             6),
    (8, 'Война и мир',           1290.00, 'Л.Н. Толстой, 2 тома',                 7),
    (9, 'Чистый код',            2490.00, 'Роберт Мартин, изд. Питер',            7);

-- Покупатели (6 записей)
INSERT INTO buyer (card_number, phone, name, birth_date, cashback) VALUES
    ('1000-0001', '+7-900-111-22-33', 'Иван Петров',    '1990-05-12', 1250.50),
    ('1000-0002', '+7-900-222-33-44', 'Мария Иванова',  '1985-11-03',  860.00),
    ('1000-0003', '+7-900-333-44-55', NULL,             NULL,            0.00),
    ('1000-0004', '+7-900-444-55-66', 'Алексей Смирнов','2000-02-28',  430.75),
    ('1000-0005', '+7-900-555-66-77', 'Ольга Кузнецова','1995-07-19', 2100.00),
    ('1000-0006', '+7-900-666-77-88', NULL,             '1988-09-01',  150.00);

-- Заказы (6 записей; часть — без покупателя / гостевые)
INSERT INTO `order` (id, order_date, buyer_card) VALUES
    (1, '2024-11-01 10:15:00', '1000-0001'),
    (2, '2024-11-03 14:40:00', '1000-0002'),
    (3, '2024-11-05 09:05:00', NULL),
    (4, '2024-11-07 18:22:00', '1000-0004'),
    (5, '2024-11-10 12:00:00', '1000-0005'),
    (6, '2024-11-12 20:45:00', '1000-0001');

-- Состав заказов (10 записей)
INSERT INTO order_item (order_id, product_id, quantity) VALUES
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