
-- テーブルの作成
CREATE TABLE employees (
    id INT PRIMARY KEY NOT NULL,
    firstname NVARCHAR(50) NOT NULL,
    lastname NVARCHAR(50) NOT NULL,
    age INT
);

-- データの挿入
INSERT INTO employees (id, firstname, lastname, age)
VALUES 
(1, 'Taro', 'Yamada', 25),
(2, 'Hanako', 'Tanaka', 30),
(3, 'Yuki', 'Suzuki', 28);
